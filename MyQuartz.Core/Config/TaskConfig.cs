using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz.Core.Config
{
    public class TaskConfig
    {
        public static TaskConfig Instance { get; set; }
        static TaskConfig()
        {
            try
            {
                Instance =
                    JsonConvert.DeserializeObject<TaskConfig>(
                        File.ReadAllText(Path.Combine(Environment.CurrentDirectory, ConfigurationManager.AppSettings["QuartzTaskConfig"])));
            }
            catch(Exception ex)
            {
                Instance = null;
            }
        }
        public List<JobItem> Jobs { get; set; }
        public List<TriggerItem> Triggers { get; set; }

    }
}

