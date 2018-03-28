namespace Sure.Quartz.NET.Web.Controllers
{
    using global::Quartz;
    using global::Quartz.Impl;
    using global::Quartz.Impl.Matchers;
    using global::Quartz.Impl.Triggers;
    using Sure.Quartz.NET.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.ComponentModel.Composition;
    using IRepository;
    using EFBase;
    using Newtonsoft.Json;
    using Common;
    using System.Linq.Expressions;

    [Export]
    public class QuartzManagerController : Controller
    {
        IScheduler scheduler = null;
        readonly object Locker = new object();
        const string channelType = "tcp";
        const string localIp = "localhost";
        const string port = "555";
        const string bindName = "QuartzScheduler";

        [Import("JobInfo_Repository")]
        private JobInfo_IRepository jobInfo_IRepository { get; set; }

        [Import("JobHelper")]
        private JobHelper jbHelper { get; set; }

        /// <summary>
        /// 无参构造
        /// </summary>
        public QuartzManagerController()
        {
            if (scheduler == null)
            {
                lock (Locker)
                {
                    var properties = new NameValueCollection();
                    properties["quartz.scheduler.proxy"] = "true";
                    properties["quartz.scheduler.proxy.Address"] = $"{channelType}://{localIp}:{port}/{bindName}";
                    scheduler = (new StdSchedulerFactory(properties)).GetScheduler();
                    scheduler.Start();
                }
            }
        }

        //默认页
        public ActionResult Default() { return View(); }

        //首页，任务展示 Job
        public ActionResult QuartzHome() { return View(); }

        //首页，任务展示 Job持久化
        public ActionResult QuartzDurableHome() { return View(); }

        #region CURD Durable

        //加载数据
        public ActionResult LoadDurable()
        {
            try
            {
                var jobQueryable = jobInfo_IRepository.Load(x => x.Id, false, x => x.Id > 0, 1, 10);
                var jobList = jobQueryable.Item1.ToList().Select(x => new
                {
                    x.Id,
                    x.JobName,
                    x.JobGroupName,
                    x.TriggerName,
                    x.TriggerGroupName,
                    x.Cron,
                    StartTime = x.StartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                    PreTime = x.PreTime.HasValue ? Convert.ToDateTime(x.PreTime).ToString("yyyy-MM-dd hh:mm:ss") : "",
                    NextTime = x.NextTime.HasValue ? Convert.ToDateTime(x.NextTime).ToString("yyyy-MM-dd hh:mm:ss") : "",
                    Deleted = x.Deleted == true ? "是" : "否",
                    x.Description,
                    State = GetState(x.State),
                });
                return Json(jobList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception($"查询数据失败,错误:{ex.Message}");
            }
        }

        //新增数据
        public ActionResult AddDurable(string jobs)
        {
            var jobInfo = JsonConvert.DeserializeObject<SURE_QRTZ_JOBINFO>(jobs);
            var dllName = "";
            var fullJobName = "Sure.Quartz.NET.JobBase.JobBase";
            jobInfo.State = (int)JobState.NOTRUNNIG; //待运行
            jobInfo.Deleted = false;
            if (!string.IsNullOrEmpty(jobInfo.FullJobName.Trim())) { dllName = $"{jobInfo.FullJobName.Split('.')[0]}.dll"; }
            else { dllName = $"Sure.Quartz.NET.JobBase.dll"; jobInfo.FullJobName = fullJobName; }
            jobInfo.DLLName = dllName;

            var jobId = jobInfo_IRepository.Add(jobInfo);
            if (jobId > 0)
            {
                return Json(new AjaxResponseData { StausCode = "success", Message = "添加成功", Data = null });
            }
            else
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "添加失败", Data = null });
            }
        }

        //运行
        public ActionResult RunJobDurable(string jobs)
        {
            var jobInfo = JsonConvert.DeserializeObject<SURE_QRTZ_JOBINFO>(jobs);
            var jobInfoNew = jobInfo_IRepository.Load(x => x.Id, false, x => x.Id == jobInfo.Id, 1, 10).Item1.FirstOrDefault();
            try
            {
                if (jbHelper.RunJob(jobInfoNew))
                {
                    jobInfoNew.State = (int)JobState.NORMAL;  //正常
                    jobInfoNew.Deleted = false;
                    jobInfo_IRepository.Update(jobInfoNew);
                    return Json(new AjaxResponseData { StausCode = "success", Message = "运行成功", Data = null });
                }
                return Json(new AjaxResponseData { StausCode = "fail", Message = "运行失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "运行失败", Data = null });
            }
        }

        //暂停
        public ActionResult PauseJobDurable(string jobs)
        {
            var jobInfo = JsonConvert.DeserializeObject<SURE_QRTZ_JOBINFO>(jobs);
            var jobInfoNew = jobInfo_IRepository.Load(x => x.Id, false, x => x.Id == jobInfo.Id, 1, 10).Item1.FirstOrDefault();
            try
            {
                jobInfoNew.State = (int)JobState.PAUSED; //暂停
                if (jbHelper.PauseJob(jobInfoNew))
                {
                    jobInfo_IRepository.Update(jobInfoNew);
                    return Json(new AjaxResponseData { StausCode = "success", Message = "暂停成功", Data = null });
                }
                return Json(new AjaxResponseData { StausCode = "fail", Message = "暂停失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "暂停失败", Data = null });
            }
        }

        //恢复
        public ActionResult ResumeJobDurable(string jobs)
        {
            var jobInfo = JsonConvert.DeserializeObject<SURE_QRTZ_JOBINFO>(jobs);
            var jobInfoNew = jobInfo_IRepository.Load(x => x.Id, false, x => x.Id == jobInfo.Id, 1, 10).Item1.FirstOrDefault();
            try
            {
                jobInfoNew.State = (int)JobState.NORMAL; //正常
                if (jbHelper.ResumeJob(jobInfoNew))
                {
                    jobInfo_IRepository.Update(jobInfoNew);
                    return Json(new AjaxResponseData { StausCode = "success", Message = "恢复成功", Data = null });
                }
                return Json(new AjaxResponseData { StausCode = "fail", Message = "恢复失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "恢复失败", Data = null });
            }
        }

        //删除
        public ActionResult DeleteJobDurable(string jobs)
        {
            var jobInfo = JsonConvert.DeserializeObject<SURE_QRTZ_JOBINFO>(jobs);
            var jobInfoNew = jobInfo_IRepository.Load(x => x.Id, false, x => x.Id == jobInfo.Id, 1, 10).Item1.FirstOrDefault();
            try
            {
                jobInfoNew.State = (int)JobState.DELETE;  //已删除
                if (jbHelper.DeleteJob(jobInfoNew))
                {
                    jobInfo_IRepository.Delete(jobInfoNew.Id);
                    return Json(new AjaxResponseData { StausCode = "success", Message = "删除成功", Data = null });
                }
                return Json(new AjaxResponseData { StausCode = "fail", Message = "删除失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "删除失败", Data = null });
            }
        }

        //当前任务是否存在Scheduler中
        public ActionResult CheckExists(string triggerName, string triggerGroupName)
        {
            try
            {
                bool bl = jbHelper.CheckExists(triggerName, triggerGroupName);
                return Json(new AjaxResponseData
                {
                    StausCode = "fail",
                    Message = "获取失败",
                    Data = JsonConvert.SerializeObject(bl)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "获取失败", Data = null }, JsonRequestBehavior.AllowGet);
            }
        }

        //同步数据
        public void SyncJob()
        {
            Expression<Func<QRTZ_TRIGGERS, string>> OrderBy = x => x.SCHED_NAME;
            Expression<Func<QRTZ_TRIGGERS, bool>> where = x => !string.IsNullOrEmpty(x.SCHED_NAME);
            Expression<Func<QRTZ_CRON_TRIGGERS, string>> OrderByCron = x => x.SCHED_NAME;
            Expression<Func<QRTZ_CRON_TRIGGERS, bool>> whereCron = x => !string.IsNullOrEmpty(x.SCHED_NAME);
            var jobQueryable = jobInfo_IRepository.Load(OrderBy, false, where, 1, 10);
            var jobList = jobQueryable.Item1.ToList().Select(x => new
            {
                x.TRIGGER_STATE,
                x.JOB_NAME,
                x.JOB_GROUP,
                x.TRIGGER_NAME,
                x.TRIGGER_GROUP,
                x.PREV_FIRE_TIME,
                x.NEXT_FIRE_TIME
            });

            var jobQueryableCron = jobInfo_IRepository.Load(OrderByCron, false, whereCron, 1, 10);
            var jobListCron = jobQueryableCron.Item1.ToList().Select(x => new
            {
                x.TRIGGER_NAME,
                x.TRIGGER_GROUP,
                x.CRON_EXPRESSION
            });

            foreach (var job in jobList)
            {
                Expression<Func<SURE_QRTZ_JOBINFO, int>> OrderByJob = x => x.Id;
                Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereJob = x => x.JobName == job.JOB_NAME && x.JobGroupName == job.JOB_GROUP
                  && x.TriggerName == job.TRIGGER_NAME && x.TriggerGroupName == job.TRIGGER_GROUP;
                var jobInfoNew = jobInfo_IRepository.Load(OrderByJob, false, whereJob, 1, 10).Item1.FirstOrDefault();
                var jobCron = jobListCron.Where(x => x.TRIGGER_NAME == job.TRIGGER_NAME && x.TRIGGER_GROUP == job.TRIGGER_GROUP).Select(x => new { x.CRON_EXPRESSION }).FirstOrDefault();
                jobInfoNew.State = GetStateJob(job.TRIGGER_STATE);
                jobInfoNew.Cron = jobCron.CRON_EXPRESSION;
                jobInfo_IRepository.Update(jobInfoNew);
            }
        }

        #endregion

        #region CURD Job

        //Upload DLL
        public ActionResult Upload()
        {
            var uploadPath = Request.MapPath("~/bin");
            var file = Request.Files["Filedata"];
            try
            {
                if (file != null)
                {
                    if (!System.IO.Directory.Exists(uploadPath)) { System.IO.Directory.CreateDirectory(uploadPath); }
                    file.SaveAs(System.IO.Path.Combine(uploadPath, file.FileName));
                }
                return Json(new AjaxResponseData { StausCode = "success", Message = "上传成功", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "上传失败", Data = null });
            }
        }

        //Load Job
        public JsonResult LoadJobInfoData()
        {
            try
            {
                int index = 1;
                List<JobDetailImpl> jobList = new List<JobDetailImpl>();
                List<CronTriggerImpl> triggerList = new List<CronTriggerImpl>();
                List<JobInfoModel> jobInfoList = new List<JobInfoModel>();

                var jobKeySet = scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());
                var triggerKeys = scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup());

                foreach (var jobKey in jobKeySet) { var jobDetail = (JobDetailImpl)scheduler.GetJobDetail(jobKey); jobList.Add(jobDetail); }
                foreach (var triggerkey in triggerKeys) { var triggerDetail = (CronTriggerImpl)scheduler.GetTrigger(triggerkey); triggerList.Add(triggerDetail); }

                foreach (var job in jobList)
                {
                    JobInfoModel jobInfo = new JobInfoModel();
                    jobInfo.JobId = index++;
                    jobInfo.JobName = job.Name;
                    jobInfo.JobGroupName = job.Group;
                    //jobInfo.IsDurable = job.Durable;
                    //jobInfo.JobDescription = job.Description;

                    var trigger = string.Join(",", scheduler.GetTriggersOfJob(new JobKey(job.Name, job.Group)).Select(m => m.Key.ToString()));

                    var triggerInfo = triggerList.Where(i => i.FullName.Equals(trigger.ToString()) && i.FullJobName.Equals($"{job.Group}.{job.Name}")).Select(i => new JobInfoModel
                    {
                        TriggerName = i.Name,
                        TriggerGroupName = i.Group,
                        //TriggerDescription = i.Description,
                        StartTime = i.StartTimeUtc.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        PrevFireTime = i.GetPreviousFireTimeUtc()?.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        NextFireTime = i.GetNextFireTimeUtc()?.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        Cron = i.CronExpressionString,
                        //Priority = i.Priority,
                        Status = scheduler.GetTriggerState(new TriggerKey(i.Name, i.Group)).ToString(),
                        //JobClassName = scheduler.GetJobDetail(i.JobKey).JobType.FullName
                    }).FirstOrDefault();

                    jobInfo.TriggerName = triggerInfo.TriggerName;
                    jobInfo.TriggerGroupName = triggerInfo.TriggerGroupName;
                    //jobInfo.TriggerDescription = triggerInfo.TriggerDescription;
                    jobInfo.StartTime = triggerInfo.StartTime;
                    jobInfo.PrevFireTime = triggerInfo.PrevFireTime;
                    jobInfo.NextFireTime = triggerInfo.NextFireTime;
                    jobInfo.Cron = triggerInfo.Cron;
                    //jobInfo.Priority = triggerInfo.Priority;
                    jobInfo.Status = GetState(triggerInfo.Status);
                    //jobInfo.JobClassName = triggerInfo.JobClassName;

                    jobInfoList.Add(jobInfo);
                }

                return Json(jobInfoList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Add Job
        public ActionResult AddJob(string jobName, string jobGroupName, string fullJobName, string jobDescription, string triggerName, string triggerGroupName, string cron, string triggerDescription)
        {
            try
            {
                if (scheduler.CheckExists(new JobKey(jobName, jobGroupName)))
                    return Json(new AjaxResponseData { StausCode = "fail", Message = "已存在相同的任务名称", Data = null });

                var assemblyName = fullJobName.Split('.')[0];
                var dllpath = Request.MapPath(string.Format("~/bin/{0}.dll", assemblyName));

                if (!System.IO.File.Exists(dllpath))
                    return Json(new AjaxResponseData { StausCode = "fail", Message = "没有找到执行类名所对应的文件，请先上传", Data = null });
                if (scheduler.CheckExists(new TriggerKey(triggerName, triggerGroupName)))
                    return Json(new AjaxResponseData { StausCode = "fail", Message = "已存在相同的触发器名称", Data = null });

                var jobClassName = Assembly.LoadFile(dllpath).CreateInstance(fullJobName);

                var job = JobBuilder.Create(jobClassName.GetType())
                                          .StoreDurably(true)
                                          .WithIdentity(jobName, jobGroupName)
                                          .WithDescription(jobDescription)
                                          .Build();

                var trigger = TriggerBuilder.Create().ForJob(jobName, jobGroupName)
                                            .WithIdentity(triggerName, triggerGroupName).StartNow()
                                            .WithCronSchedule(cron)
                                            .WithDescription(triggerDescription)
                                            .Build();

                scheduler.ScheduleJob(job, trigger);
                return Json(new AjaxResponseData { StausCode = "success", Message = "创建成功", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "创建失败", Data = null });
            }
        }

        //Pause Job:同时暂停Job，Trigger
        public JsonResult PauseJob(string jobName, string jobGroupName, string triggerName, string triggerGroupName)
        {
            try
            {
                scheduler.PauseJob(new JobKey(jobName, jobGroupName));
                scheduler.PauseTrigger(new TriggerKey(triggerName, triggerGroupName));
                return Json(new AjaxResponseData { StausCode = "success", Message = "暂停失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "暂停失败", Data = null });
            }
        }

        //Resume Job:同时恢复Job，Trigger
        public JsonResult ResumeJob(string jobName, string jobGroupName, string triggerName, string triggerGroupName)
        {
            try
            {
                scheduler.ResumeJob(new JobKey(jobName, jobGroupName));
                scheduler.ResumeTrigger(new TriggerKey(triggerName, triggerGroupName));
                return Json(new AjaxResponseData { StausCode = "success", Message = "暂停失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "恢复失败", Data = null });
            }
        }

        //Delete Job:同时删除Job，Trigger
        public JsonResult DeleteJob(string jobName, string jobGroupName, string triggerName, string triggerGroupName)
        {
            try
            {
                scheduler.PauseTrigger(new TriggerKey(triggerName, triggerGroupName));
                scheduler.UnscheduleJob(new TriggerKey(triggerName, triggerGroupName));
                scheduler.DeleteJob(new JobKey(jobName, jobGroupName));
                return Json(new AjaxResponseData { StausCode = "success", Message = "成功失败", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "删除失败", Data = null });
            }
        }

        //Edit Job:新的Trigger替换老的Trigger
        public JsonResult EditJob(string triggerName, string triggerGroupName, string triggerCron)
        {
            try
            {
                var triggerKey = new TriggerKey(triggerName, triggerGroupName);
                var trigger = TriggerBuilder.Create()
                                            .WithIdentity(triggerName, triggerGroupName).StartNow()
                                            .WithCronSchedule(triggerCron)
                                            .Build();
                scheduler.RescheduleJob(triggerKey, trigger);
                return Json(new AjaxResponseData { StausCode = "success", Message = "修改成功", Data = null });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResponseData { StausCode = "fail", Message = "修改失败", Data = null });
            }
        }

        #endregion

        #region private

        /// <summary>
        /// 任务状态
        /// </summary>
        /// <param name="stateIndex">状态ID</param>
        /// <returns>状态名</returns>
        public string GetState(int stateIndex)
        {
            string stateName = "";
            switch (stateIndex)
            {
                case 6:
                    stateName = "待运行";
                    break;
                case 5:
                    stateName = "已删除";
                    break;
                case 1:
                    stateName = "已暂停";
                    break;
                case 0:
                    stateName = "正常";
                    break;
                case 2:
                    stateName = "完成";
                    break;
                default:
                    break;
            }
            return stateName;
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        /// <param name="stateIndex">状态ID</param>
        /// <returns>状态名</returns>
        public string GetState(string state)
        {
            string stateName = "";
            switch (state)
            {
                case "Normal":
                    stateName = "正常";
                    break;
                case "Paused":
                    stateName = "已暂停";
                    break;
                case "Complete":
                    stateName = "完成";
                    break;
                case "Error":
                    stateName = "错误";
                    break;
                case "Blocked":
                    stateName = "阻塞";
                    break;
                case "None":
                    stateName = "不存在";
                    break;
                default:
                    break;
            }
            return stateName;
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        /// <param name="stateIndex">状态ID</param>
        /// <returns>状态名</returns>
        public int GetStateJob(string state)
        {
            int stateName = 0;
            switch (state)
            {
                case "Normal":
                    stateName = 0;
                    break;
                case "Paused":
                    stateName = 1;
                    break;
                case "Complete":
                    stateName = 2;
                    break;
                case "Error":
                    stateName = 3;
                    break;
                case "Blocked":
                    stateName = 4;
                    break;
                case "None":
                    stateName = 1;
                    break;
                default:
                    break;
            }
            return stateName;
        }

        #endregion
    }
}