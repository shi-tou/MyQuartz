using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Client.Jobs
{
    public class FirstJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDetailImpl jobDetail = (JobDetailImpl)context.JobDetail;
            Console.WriteLine(string.Format("--------------FirstJob:{0}----------------", context.FireTimeUtc));
            //Console.WriteLine("FirstJob->Name：" + jobDetail.FullName);
            //Console.WriteLine("FirstJob->Group：" + jobDetail.Group);
            //Console.WriteLine("Trigger类型->：" + context.Trigger.GetType());
        }
    }
}
