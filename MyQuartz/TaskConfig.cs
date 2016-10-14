using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartz
{
    public class TaskConfig
    {
        public static TaskConfig Instance { get; set; }
        static TaskConfig()
        {
            Instance =
                JsonConvert.DeserializeObject<TaskConfig>(
                    File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "task.json")));
        }
        public List<Job> Jobs { get; set; }
        public List<Trigger> Triggers { get; set; }

    }
    public class Job
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
    }
    public class Trigger
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string RepeatInterval { get; set; }
        public string IntervalValue { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}

