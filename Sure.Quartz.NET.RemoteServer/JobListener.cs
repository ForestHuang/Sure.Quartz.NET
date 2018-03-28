namespace Sure.Quartz.NET.RemoteServer
{
    using global::Quartz;
    using log4net;
    using IRepository;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using Repository;
    using System.Linq.Expressions;
    using EFBase;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Job 监听
    /// </summary>
    [Export]
    public class JobListener : IJobListener
    {
        [Import("JobInfo_Repository")]
        private JobInfo_IRepository jobInfo_IRepository { get; set; }

        /// <summary>
        /// Log4net 配置
        /// </summary>
        private static ILog log = LogManager.GetLogger(typeof(JobListener));

        private Dictionary<string, Stopwatch> stopwatches = new Dictionary<string, Stopwatch>();

        public string Name
        {
            get { return "JobListener"; }
        }

        //Scheduler在JobDetail将要被执行时调用这个方法。
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            // Do nothing
        }

        //cheduler在JobDetail即将被执行，但又被TriggerListener否决了时调用这个方法。
        public void JobToBeExecuted(IJobExecutionContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatches.Add(context.FireInstanceId, stopwatch);
        }

        //Scheduler在JobDetail被执行之后调用这个方法。
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            var elapsed = stopwatches[context.FireInstanceId].ElapsedMilliseconds;
            var jobName = context.JobDetail.Key.Name;
            var jobGroupName = context.JobDetail.Key.Group;
            var triggerName = context.Trigger.Key.Name;
            var triggerGroup = context.Trigger.Key.Group;
            var PrevFireTime = context.Trigger.GetPreviousFireTimeUtc()?.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            var NextFireTime = context.Trigger.GetNextFireTimeUtc()?.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            var requestURL = context.JobDetail.JobDataMap["requestUrl"].ToString();
            var fullName = context.JobDetail.JobDataMap["fullJobName"].ToString();
            string jobRecord = "";
            if (!string.IsNullOrEmpty(requestURL))
                jobRecord = $",requstURL:{requestURL}";
            if (!string.IsNullOrEmpty(fullName))
                jobRecord += $",fullName:{fullName}";

            #region 更新数据库数据

            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                var tainer = new CompositionContainer(catalog);
                jobInfo_IRepository = tainer.GetExportedValue<JobInfo_IRepository>("JobInfo_Repository");
                Expression<Func<SURE_QRTZ_JOBINFO, int>> OrderByJob = x => x.Id;
                Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereJob = x => x.JobName == jobName && x.JobGroupName == jobGroupName
                  && x.TriggerName == triggerName && x.TriggerGroupName == triggerGroup;
                var jobInfoNew = jobInfo_IRepository.Load(OrderByJob, false, whereJob, 1, 10).Item1.FirstOrDefault();
                jobInfoNew.NextTime = Convert.ToDateTime(NextFireTime);
                jobInfoNew.PreTime = Convert.ToDateTime(PrevFireTime);
                string message = $"JobName:[{jobName}],JobGroupName:[{jobGroupName}]{jobRecord},耗时:[{elapsed}ms]";

                jobInfo_IRepository.Update(jobInfoNew);

                log.Info(message);
            }
            catch (Exception ex)
            {
                Thread.Sleep(2000);
                log.Error($"JobName:[{jobName}],JobGroupName:[{jobGroupName}]{jobRecord},JobListener 错误信息：{ex.Message}");
            }

            #endregion
        }
    }
}
