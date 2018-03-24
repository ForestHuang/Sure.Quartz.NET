using Quartz;
using Quartz.Impl;
using Sure.Quartz.NET.EFBase;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Sure.Quartz.NET.Common
{
    [Export("JobHelper", typeof(JobHelper))]
    public class JobHelper
    {
        IScheduler scheduler = null;
        readonly object Locker = new object();
        const string channelType = "tcp";
        const string localIp = "localhost";
        const string port = "555";
        const string bindName = "QuartzScheduler";

        /// <summary>
        /// 无参构造
        /// </summary>
        public JobHelper()
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

        /// <summary>
        /// 运行任务，以及创建Job
        /// </summary>
        /// <param name="jobInfo">任务信息</param>
        /// <returns>是否成功</returns>
        public bool RunJob(SURE_QRTZ_JOBINFO jobInfo)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + $"bin/{jobInfo.DLLName}");
                JobKey jobKey = new JobKey(jobInfo.JobName, jobInfo.JobGroupName);
                //只需判断Job是否存在
                if (!scheduler.CheckExists(jobKey))
                {
                    //Create Job
                    IJobDetail job = JobBuilder.Create(assembly.GetType(jobInfo.FullJobName))
                        .WithIdentity(jobKey)
                        .UsingJobData(createJobDataMap("jobId", jobInfo.Id))
                        .UsingJobData(createJobDataMap("requestUrl", jobInfo.RequestUrl))
                        .UsingJobData(createJobDataMap("fullJobName", jobInfo.FullJobName))
                        .Build();
                    //Create Tigger
                    CronScheduleBuilder scheduleBuilder = CronScheduleBuilder.CronSchedule(jobInfo.Cron);
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity(jobInfo.TriggerName, jobInfo.TriggerGroupName)
                        .StartAt(jobInfo.StartTime)
                        .EndAt(jobInfo.EndTime)
                        .ForJob(jobKey)
                        .WithSchedule(scheduleBuilder.WithMisfireHandlingInstructionDoNothing())
                        .Build();

                    scheduler.ScheduleJob(job, trigger);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"运行任务失败,错误:{ex.Message}");
            }
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="jobInfo">任务信息</param>
        /// <returns>是否成功</returns>
        public bool PauseJob(SURE_QRTZ_JOBINFO jobInfo)
        {
            try
            {
                var jobKey = new JobKey(jobInfo.JobName, jobInfo.JobGroupName);
                scheduler.PauseJob(jobKey);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"暂停任务失败,错误:{ex.Message}");
            }
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="jobInfo">任务信息</param>
        /// <returns>是否成功</returns>
        public bool DeleteJob(SURE_QRTZ_JOBINFO jobInfo)
        {
            try
            {
                var jobKey = new JobKey(jobInfo.JobName, jobInfo.JobGroupName);
                var triggerKey = new TriggerKey(jobInfo.TriggerName, jobInfo.TriggerGroupName);
                scheduler.PauseTrigger(triggerKey);
                scheduler.UnscheduleJob(triggerKey);
                scheduler.DeleteJob(jobKey);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"删除任务失败,错误:{ex.Message}");
            }
        }

        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="jobInfo">任务信息</param>
        /// <returns>是否成功</returns>
        public bool ResumeJob(SURE_QRTZ_JOBINFO jobInfo)
        {
            try
            {
                var jobKey = new JobKey(jobInfo.JobName, jobInfo.JobGroupName);
                scheduler.ResumeJob(jobKey);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"恢复任务失败,错误:{ex.Message}");
            }
        }

        /// <summary>
        /// 更改触发器以及执行周期
        /// </summary>
        /// <param name="jobInfo">任务信息</param>
        /// <returns>是否成功</returns>
        public bool ModifyJobCron(SURE_QRTZ_JOBINFO jobInfo)
        {
            CronScheduleBuilder scheduleBuilder = CronScheduleBuilder.CronSchedule(jobInfo.Cron);
            var triggerKey = new TriggerKey(jobInfo.TriggerName, jobInfo.TriggerGroupName);
            ITrigger trigger = TriggerBuilder.Create()
                       .WithIdentity(jobInfo.TriggerName, jobInfo.TriggerGroupName)
                       .StartAt(jobInfo.StartTime)
                       .EndAt(jobInfo.EndTime)
                       .ForJob(new JobKey(jobInfo.JobName, jobInfo.JobGroupName))
                       .WithSchedule(scheduleBuilder.WithMisfireHandlingInstructionDoNothing())
                       .Build();
            scheduler.RescheduleJob(triggerKey, trigger);

            return true;
        }

        #region private

        private JobDataMap createJobDataMap<T>(string propertyName, T propertyValue)
        {
            return new JobDataMap(new Dictionary<string, T>() { { propertyName, propertyValue } });
        }

        #endregion
    }
}
