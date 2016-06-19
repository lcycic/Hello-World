using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaDanPingTai.Common
{
    public class TaskJob
    {
        public string Title { get; }
        public DateTime ExecutionTime;

        public TaskJob(string title, DateTime executionTime)
        {
            this.Title = title;
            this.ExecutionTime = executionTime;
        }

        public void Execute()
        {
            //Debug.WriteLine(DateTime.Now+"开始执行");
            //Debug.WriteLine(this.Title);
            //Debug.WriteLine(this.ExecutionTime);
            Log.WriteTextLog("执行任务", Title, DateTime.Now);
        }
    }
}
