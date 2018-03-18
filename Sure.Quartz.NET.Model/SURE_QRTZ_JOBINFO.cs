using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sure.Quartz.NET.Model
{
    /// <summary>
    /// Job_Info
    /// </summary>
    public class SURE_QRTZ_JOBINFO
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// 任务分组名称
        /// </summary>
        public string JobGroupName { set; get; }

        /// <summary>
        /// 触发器名称
        /// </summary>
        public string TriggerName { set; get; }

        /// <summary>
        /// 触发器分组名称
        /// </summary>
        public string TriggerGroupName { set; get; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public int State { set; get; }

        /// <summary>
        /// 执行周期（Cron表达式）
        /// </summary>
        public string Cron { set; get; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public System.Nullable<DateTimeOffset> StartTime
        {
            set
            {
                if (StartTime.Value == null)
                {
                    StartTime = new DateTimeOffset(Convert.ToDateTime(DateTimeOffset.UtcNow.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss")));
                }
            }
            get { return StartTime; }
        }

        /// <summary>
        /// 任务结束时间
        /// </summary>
        public System.Nullable<DateTimeOffset> EndTime { set; get; }

        /// <summary>
        /// 本次执行时间
        /// </summary>
        public System.Nullable<DateTimeOffset> PreTime { set; get; }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public System.Nullable<DateTimeOffset> NextTime { set; get; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 执行DLL文件名称
        /// </summary>
        public string DLLName { set; get; }

        /// <summary>
        /// 执行类名
        /// </summary>
        public string FullJobName { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { set; get; }

        /// <summary>
        /// 访问地址
        /// </summary>
        public string RequestUrl { set; get; }
    }
}
