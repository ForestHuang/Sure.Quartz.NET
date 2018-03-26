namespace Sure.Quartz.NET.RemoteServer
{
    using global::Quartz;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Job 监听
    /// </summary>
    public class JobListener : IJobListener
    {
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
            var requestURL = context.JobDetail.JobDataMap["requestUrl"].ToString();
            var fullName = context.JobDetail.JobDataMap["fullJobName"].ToString();
            string jobRecord = "";
            if (!string.IsNullOrEmpty(requestURL))
                jobRecord = $",requstURL:{requestURL}";
            if (!string.IsNullOrEmpty(fullName))
                jobRecord += $",fullName:{fullName}";

            string message = $"JobName:[{jobName}],JobGroupName:[{jobGroupName}]{jobRecord},耗时:[{elapsed}ms]";
            log.Info(message);
        }
    }
}
