using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Core
{
    /// <summary>
    /// 程序集处理类  
    /// </summary>
    public class AssemblyHandler
    {
        /// <summary>  
        /// 获取程序集中的继承了IJob接口的类
        /// </summary>  
        /// <param name="assemblyName">程序集</param>  
        public static Type[] GetJobClass()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IJob))))
                .ToArray();
            return types;
        }
    }
}
