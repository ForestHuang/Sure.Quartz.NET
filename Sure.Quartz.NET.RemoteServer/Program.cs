using log4net.Config;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Specialized;
using System.IO;

namespace Sure.Quartz.NET.RemoteServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Log4net 配置
            /// </summary>
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\log4net.config")));

            var properties = new NameValueCollection();
            //线程池配置
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "10";
            properties["quartz.threadPool.threadPriority"] = "Normal";

            //远程配置
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter,Quartz";
            properties["quartz.scheduler.exporter.port"] = "555";//端口号
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";//名称

            //通道类型
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";
            properties["quartz.scheduler.exporter.rejectRemoteRequests"] = "true";

            //数据库
            properties["quartz.dataSource.sqlserver.provider"] = "SqlServer-20";
            properties["quartz.dataSource.sqlserver.connectionString"] = @"server=.;uid=sa;pwd=sasa;database=Sure.Quartz.NET";

            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            properties["quartz.jobStore.dataSource"] = "sqlserver";
            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";

            //集群配置
            properties["quartz.jobStore.clustered"] = "true";
            properties["quartz.scheduler.instanceId"] = "AUTO";

            var schedulerFactory = new StdSchedulerFactory(properties);
            var scheduler = schedulerFactory.GetScheduler();

            //加入JobListener，监听
            scheduler.ListenerManager.AddJobListener(new JobListener(), GroupMatcher<JobKey>.AnyGroup());
            scheduler.Start();
        }
    }
}
