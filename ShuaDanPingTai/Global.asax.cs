using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using ShuaDanPingTai.Common;
using System.Diagnostics;
using System.Timers;

namespace ShuaDanPingTai
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //定义定时器
            System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
            myTimer.AutoReset = true;
            Log.WriteTextLog(myTimer.ToString() + "定时器", "定时器已启动", DateTime.Now);
        }

        void myTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                ExecuteQueuedJobs();
            }
            catch (Exception ex)
            {
                Log.WriteTextLog("异常", ex.Message, DateTime.Now);
            }
        }

        public static List<TaskJob> jobs = new List<TaskJob>();
        private void ExecuteQueuedJobs()
        {
            if (jobs.Count > 0)
            {
                foreach (TaskJob job in jobs)
                {
                    if (job.ExecutionTime <= DateTime.Now)
                    {
                        lock (jobs)
                        {
                            jobs.Remove(job);
                        }
                        job.Execute();
                    }
                }
            }

        }
    }
}