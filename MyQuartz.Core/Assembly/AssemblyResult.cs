using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Core
{
    public class AssemblyResult
    {
        /// <summary>  
        /// 类名  
        /// </summary>  
        public List<string> ClassName { get; set; }

        /// <summary>  
        /// 类的属性  
        /// </summary>  
        public List<string> Properties { get; set; }
        /// <summary>  
        /// 类的方法  
        /// </summary>  
        public List<string> Methods { get; set; }
        /// <summary>  
        /// 类的方法XML描述 
        /// </summary>  
        public List<string> Desc { get; set; }
    }
}
