using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuaDanPingTai.Models;

namespace ShuaDanPingTai.IDAL
{
    public interface IAppBaseSetting
    {
        AppBaseSetting GetAppBaseSetting();
        string SetAppBaseSetting(AppBaseSetting appSet);
        string CreateUser(string userName, string passWord);

        string CreateRole(string roleName);

        IList<IdentityUser> GetAllUser(ShuaDanPingTai.Models.Pager pager);

        IList<IdentityRole> GetAllRoles();
    }
}
