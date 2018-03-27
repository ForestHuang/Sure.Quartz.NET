using log4net;
using Quartz;
using System;
using System.Net.Http;

namespace Sure.Quartz.NET.JobBase
{
    public class JobBase : IJob
    {
        /// <summary>
        /// Log4net 配置
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Execute(IJobExecutionContext context)
        {
            JobKey jobKey = null;
            try
            {
                jobKey = context.JobDetail.Key;
                HttpClient hc = new HttpClient();
                hc.GetAsync(context.JobDetail.JobDataMap["requestUrl"].ToString());
            }
            catch (Exception ex)
            {
                string requestURL = context.JobDetail.JobDataMap["requestUrl"].ToString();
                string fullName = context.JobDetail.JobDataMap["fullJobName"].ToString();
                string jobRecord = "";
                if (!string.IsNullOrEmpty(requestURL))
                    jobRecord = $",requstURL:{requestURL}";
                if (!string.IsNullOrEmpty(fullName))
                    jobRecord += $",fullName:{fullName}";
                string message = $"JobName:[{jobKey.Name}],JobGroupName:[{jobKey.Group}]{jobRecord}";
                log.Error($"{message},错误信息:{ex.Message}");
            }
        }

    }
}
