using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz
{
    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDetailImpl jobDetail = (JobDetailImpl)context.JobDetail;
            Console.WriteLine(string.Format("--------------{0}----------------", context.FireTimeUtc));
            Console.WriteLine("Job->Name：" + jobDetail.FullName);
            Console.WriteLine("Job->Group：" + jobDetail.Group);
            Console.WriteLine("Trigger类型->：" + context.Trigger.GetType());
            Console.WriteLine("任务执行->：" + ((ICronTrigger)context.Trigger).CronExpressionString);
        }
    }
}
