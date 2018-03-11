using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Collections.Specialized;

namespace Sure.Quartz.NET.RemoteServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "RemoteServer";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "10"; //线程池
            properties["quartz.threadPool.threadPriority"] = "Normal";

            //远程配置
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter,Quartz";
            properties["quartz.scheduler.exporter.port"] = "555";//端口号
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";//名称

            //通道类型
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";
            properties["quartz.scheduler.exporter.rejectRemoteRequests"] = "true";

            //集群配置
            properties["quartz.jobStore.clustered"] = "true";
            properties["quartz.scheduler.instanceId"] = "AUTO";

            //数据库
            properties["quartz.dataSource.myDS.provider"] = "SqlServer-20";
            properties["quartz.dataSource.myDS.connectionString"] = @"server=.;uid=sa;pwd=sasa;database=Sure.Quartz.NET";
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            properties["quartz.jobStore.dataSource"] = "myDS";
            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz";
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";

            var schedulerFactory = new StdSchedulerFactory(properties);
            var scheduler = schedulerFactory.GetScheduler();
            scheduler.ListenerManager.AddJobListener(new JobListener(), GroupMatcher<JobKey>.AnyGroup());
            scheduler.Start();
        }
    }
}
