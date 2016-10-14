using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Core.Config
{
    /// <summary>
    /// 作业配置项
    /// </summary>
    public class JobItem
    {
        /// <summary>
        /// 作业名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作业分组
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 作业对应类型（如MyQuartz.Jobs.FirstJob）
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 触发器
        /// </summary>
        public string Trigger { get; set; }
    }
}
