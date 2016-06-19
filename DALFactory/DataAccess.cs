using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace ShuaDanPingTai.DALFactory
{
    public class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        public static ShuaDanPingTai.IDAL.IAppBaseSetting CreateAppBaseSetting()
        {
            string className = path + ".AppBaseSetting";
            return (ShuaDanPingTai.IDAL.IAppBaseSetting)Assembly.Load(path).CreateInstance(className);
        }
        
    }
}
