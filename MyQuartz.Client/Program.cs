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
            Console.WriteLine("任务开始，输入【q+回车】退出程序");
            TaskService.Init();
        }
    }
}
