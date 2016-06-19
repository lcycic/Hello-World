using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuaDanPingTai.IDAL;
using ShuaDanPingTai.Models;

namespace ShuaDanPingTai.BLL
{
    public class AppBaseSetting
    {
        private static readonly IAppBaseSetting dal = DALFactory.DataAccess.CreateAppBaseSetting(); 

        public static Models.AppBaseSetting GetAppBaseSetting()
        {
            return dal.GetAppBaseSetting();
        }

        public static string SetAppBaseSetting(Models.AppBaseSetting appSet)
        {
            return dal.SetAppBaseSetting(appSet);
        }
        public static string CreateUser(string userName, string passWord)
        {
            return dal.CreateUser(userName, passWord);
        }

        public static string CreateRole(string roleName)
        {
            return dal.CreateRole(roleName);
        }

        public static IList<IdentityUser> GetAllUser(Pager pager)
        {
            return dal.GetAllUser(pager);
        }

        public static IList<IdentityRole> GetAllRoles()
        {
            return dal.GetAllRoles();
        }
    }
}
