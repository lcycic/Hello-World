using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaDanPingTai.Models
{
    public class AppBaseSetting
    {
        public int id { get; set; }
        public bool IsDisplayValidateCodeWithLogin { get; set; }
        public bool IsDisplayValidateCodeWithRegister { get; set; }
        public string AppName { get; set; }
        public bool IsAllowLoginAndRegister { get; set; }
        public string FootInfo { get; set; }
    }
}
