using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Core.Config
{
    /// <summary>
    /// 触发器配置项
    /// </summary>
    public class TriggerItem
    {
        /// <summary>
        /// 触发器名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 触发器分组
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpression { get; set; }
        /// <summary>
        /// 开始执行时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束执行时间
        /// </summary>
        public string EndTime { get; set; }
    }
}
