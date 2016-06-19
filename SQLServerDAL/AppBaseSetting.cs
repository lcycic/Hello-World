using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuaDanPingTai.IDAL;
using ShuaDanPingTai.Models;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;

namespace ShuaDanPingTai.SQLServerDAL
{
    public class AppBaseSetting : IAppBaseSetting
    {
        public ShuaDanPingTai.Models.AppBaseSetting GetAppBaseSetting()
        {
            using (var db = new AppDbContext())
            {
                var query = (from a in db.AppBaseSettings select a).FirstOrDefault();
                return query;
            }
        }
        public string SetAppBaseSetting(Models.AppBaseSetting appSet)
        {
            using (var db = new AppDbContext())
            {
                var appBaseSetting = (from a in db.AppBaseSettings select a).Single();
                appBaseSetting.AppName = appSet.AppName;
                appBaseSetting.IsDisplayValidateCodeWithLogin = appSet.IsDisplayValidateCodeWithLogin;
                appBaseSetting.IsDisplayValidateCodeWithRegister = appSet.IsDisplayValidateCodeWithRegister;
                appBaseSetting.IsAllowLoginAndRegister = appSet.IsAllowLoginAndRegister;
                appBaseSetting.FootInfo = appSet.FootInfo;
                if (db.SaveChanges()>0)
                {
                    return "数据保存成功.";
                }
                else
                {
                    return "数据保存失败.";
                }             
            }
        }

        public string CreateUser(string userName, string passWord)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            var user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new IdentityUser(userName);
                IdentityResult result = userManager.Create(user, passWord);
                //result = userManager.SetLockoutEnabled(user.Id, false);
                if (result.Succeeded)
                {
                    return "用户名" + userName + "创建成功。";
                }
                else
                {
                    return result.Errors.FirstOrDefault();
                }
            }
            else
            {
                return "用户名已经存在";
            }
        }

        public string CreateRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var result = roleManager.Create(role);
                if (result.Succeeded)
                {
                    return "角色名" + roleName + "创建成功。";
                }
                else
                {
                    return result.Errors.FirstOrDefault();
                }
            }
            else
            {
                return "角色名已经存在";
            }
        }

        public IList<IdentityUser> GetAllUser(ShuaDanPingTai.Models.Pager pager)
        {
            using (var db = new IdentityDbContext())
            {
                pager.Count = (from a in db.Users select a).Count();
                var query = (from a in db.Users orderby a.UserName select a).Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                return query;
            }
        }

        public IList<IdentityRole> GetAllRoles()
        {
            using (var db = new IdentityDbContext())
            {
                var query = (from a in db.Roles select a).ToList();
                return query;
            }
        }



    }
}
