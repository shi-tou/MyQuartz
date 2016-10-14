using MyQuartz.Core;
using MyQuartz.Core.Config;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading;

namespace MyQuartz.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            #region 配置式任务
            TaskService.Init();
            #endregion

            #region 测试
            ////第一步：通过调度工厂创建一个作业调度池
            //ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            //IScheduler scheduler = schedulerFactory.GetScheduler();
            ////第二步：创建出来一个具体的作业
            //IJobDetail jobDetail = JobBuilder.Create<FirstJob>().Build();
            ////第三步：创建并配置一个触发器
            //DateTime time = DateTime.Now;
            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(time, 0);
            //DateTimeOffset endTime = DateBuilder.NextGivenSecondDate(time.AddMinutes(3), 0);
            //ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5)//指定间隔时间为3s
            //    .WithRepeatCount(int.MaxValue))//指定重复次数为int的最大值
            //    .StartAt(startTime)//开始于【当前时间往后推迟5秒的时间点】
            //    .EndAt(endTime)//结束于【当前时间往后推迟1分的时间点】
            //    .Build();
            //ICronTrigger cronTrigger = TaskService.CreateCronTrigger();
            ////第四步：将具体作业及触发器加入作业调度池中
            //scheduler.ScheduleJob(jobDetail, cronTrigger);
            ////第五步：开始执行
            //scheduler.Start();
            //Thread.Sleep(300000);
            ////结束
            //scheduler.Shutdown();
            #endregion

            Console.ReadKey();
        }
    }
}
