
using MyQuartz.Core.Config;
using Quartz;
using Quartz.Impl;
using System;
using System.Reflection;
using System.Linq;

namespace MyQuartz.Core
{
    /// <summary>
    /// Task服务
    /// </summary>
    public class TaskService
    {

        /// <summary>
        /// 作业调度池
        /// </summary>
        public static IScheduler Scheduler;
        static TaskService()
        {
            //用调度工厂创建作业调度池
            Scheduler = new StdSchedulerFactory().GetScheduler();
        }

        #region 作业调度管理
        /// <summary>
        /// 开始执行
        /// </summary>
        public static void Start()
        {
            Scheduler.Start();
        }
        /// <summary>
        /// 停止执行
        /// </summary>
        public static void Pause()
        {
            Scheduler.PauseAll();
        }
        /// <summary>
        /// 恢复执行
        /// </summary>
        public static void Resume()
        {
            Scheduler.ResumeAll();
        }
        /// <summary>
        /// 线束执行
        /// </summary>
        public static void Stop()
        {
            Scheduler.Shutdown();
        }
        #endregion

        #region 创建Job

        public static void Init()
        {
            try
            {
                if (TaskConfig.Instance != null)
                {
                    Type[] types = AssemblyHandler.GetJobClass();
                    foreach (JobItem item in TaskConfig.Instance.Jobs)
                    {
                        IJobDetail jobDetail = CreateJob(item, types);
                        ICronTrigger trigger = CreateCronTrigger(TaskConfig.Instance.Triggers.Where(a => a.Name == item.Trigger).FirstOrDefault());
                        Scheduler.ScheduleJob(jobDetail, trigger);
                        Scheduler.Start();
                    }
                }
                else
                {
                    throw new Exception("找不到配置信息！");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static IJobDetail CreateJob(JobItem jobItem, Type[] types)
        {
            JobDetailImpl job = new JobDetailImpl(jobItem.Name, types.Where(t => t.FullName == jobItem.Type).FirstOrDefault());
            return job;
        }


        #endregion

        #region 创建Trigger
        /// <summary>
        /// 创建CronTrigger
        /// </summary>
        /// <returns></returns>
        public static ICronTrigger CreateCronTrigger(TriggerItem triggerItem)
        {
            TriggerBuilder triggerBuilder = TriggerBuilder.Create();
            if (!string.IsNullOrEmpty(triggerItem.StartTime))
            {
                triggerBuilder = triggerBuilder.StartAt(Convert.ToDateTime(triggerItem.StartTime));
            }
            if (!string.IsNullOrEmpty(triggerItem.EndTime))
            {
                triggerBuilder = triggerBuilder.EndAt(Convert.ToDateTime(triggerItem.EndTime));
            }
            triggerBuilder = triggerBuilder.WithCronSchedule(triggerItem.CronExpression);
            ICronTrigger trigger = (ICronTrigger)triggerBuilder
                .WithCronSchedule(triggerItem.CronExpression)
                .WithIdentity(triggerItem.Name, triggerItem.Group)
                .Build();
            return trigger;
        }
        #endregion



    }
}
