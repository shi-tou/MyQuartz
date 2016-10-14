using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz
{
    /// <summary>
    /// Quartz.Net服务
    /// </summary>
    public class QuartzService
    {
        /// <summary>
        /// 作业调度池
        /// </summary>
        public static IScheduler Scheduler;
        static QuartzService()
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

        #region 创建Trigger
        /// <summary>
        /// 创建SimpleTrigger
        /// </summary>
        /// /// <param name="intervalType">间隔时间单位（1-秒 2-分 3-小时）</param>
        /// <param name="intervalSeconds">间隔时间(秒)</param>
        /// <returns></returns>
        public ISimpleTrigger CreateSimpleTrigger(IntervalType intervalType, int intervalValue)
        {
            return CreateSimpleTrigger(null, null, intervalType, intervalValue);
        }
        /// <summary>
        /// 创建SimpleTrigger
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// /// <param name="intervalType">间隔时间单位（1-秒 2-分 3-小时）</param>
        /// <param name="intervalSeconds">间隔时间(秒)</param>
        /// <returns></returns>
        public ISimpleTrigger CreateSimpleTrigger(DateTime? startTime, DateTime? endTime, IntervalType intervalType, int intervalValue)
        {
            TriggerBuilder builder = TriggerBuilder.Create();
            if (startTime != null)
                builder.StartAt(DateBuilder.NextGivenSecondDate(startTime, ((DateTime)startTime).Second));
            if (endTime != null)
                builder.StartAt(DateBuilder.NextGivenSecondDate(endTime, ((DateTime)endTime).Second));
            //指定间隔时间
            switch (intervalType)
            {
                case IntervalType.Second:
                    builder.WithSimpleSchedule(x => x.WithIntervalInSeconds(intervalValue));
                    break;
                case IntervalType.Minute:
                    builder.WithSimpleSchedule(x => x.WithIntervalInMinutes(intervalValue));
                    break;
                case IntervalType.Hour:
                    builder.WithSimpleSchedule(x => x.WithIntervalInHours(intervalValue));
                    break;
                default:
                    break;
            }
            return (ISimpleTrigger)builder;
        }
       

        /// <summary>
        /// 创建CronTrigger
        /// </summary>
        /// <returns></returns>
        public ICronTrigger CreateCronTrigger()
        {
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create();
            return trigger;
        }
        #endregion

    }
}
