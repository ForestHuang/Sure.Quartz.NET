using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sure.Quartz.NET.Web.Models
{
    public class JobInfoModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// Job名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Job分组名称
        /// </summary>
        public string JobGroupName { get; set; }

        /// <summary>
        /// 是否持久化
        /// </summary>
        public bool IsDurable { get; set; }

        /// <summary>
        /// Trigger名称
        /// </summary>
        public string TriggerName { get; set; }

        /// <summary>
        /// Trigger分组名称
        /// </summary>
        public string TriggerGroupName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public string Cron { get; set; }

        /// <summary>
        /// 启动时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 执行接口
        /// </summary>
        public string JobClassName { get; set; }
        
        /// <summary>
        /// 本次执行时间
        /// </summary>
        public string PrevFireTime { get; set; }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public string NextFireTime { get; set; }

        /// <summary>
        /// Job描述
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// Trigger描述
        /// </summary>
        public string TriggerDescription { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
    }

    public class JobInfoModelRespone {
        public List<JobInfoModel> aaData { get; set; }
    }
}