using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace ShuaDanPingTai.Models
{
    public class AppDbContext:DbContext
    {
        //public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 
        public AppDbContext()
            : base("DefaultConnection")
        {
        }
        public IDbSet<AppBaseSetting> AppBaseSettings { get; set; }
    }
}
