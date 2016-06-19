using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShuaDanPingTai.App_Code;
using ShuaDanPingTai.Common;

namespace ShuaDanPingTai.Admin
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WorkingDirectory = "c:\\";
            startInfo.CreateNoWindow = false;
            process.StartInfo = startInfo;
            try
            {
                process.Start();
                process.StandardInput.WriteLine("dir");
                process.StandardInput.WriteLine("exit");
                var s = process.StandardOutput.ReadToEnd();
                Response.Write(s);
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

            Response.Write("增加一个任务");
            Dojob();

        }

        public void Dojob()
        {
            TaskJob newJob = new TaskJob("我的任务1" + DateTime.Now,
                                  DateTime.Now.AddSeconds(60));
            lock (Global.jobs)
            {
                Global.jobs.Add(newJob);
            }
        }

    }
}