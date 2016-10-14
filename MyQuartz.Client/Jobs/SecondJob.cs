using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Client.Jobs
{
    public class SecondJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDetailImpl jobDetail = (JobDetailImpl)context.JobDetail;
            Console.WriteLine(string.Format("--------------SecondJob:{0}----------------", context.FireTimeUtc));
            //Console.WriteLine("SecondJob->Name：" + jobDetail.FullName);
            //Console.WriteLine("SecondJob->Group：" + jobDetail.Group);
            //Console.WriteLine("Trigger类型->：" + context.Trigger.GetType());
        }
    }
}
