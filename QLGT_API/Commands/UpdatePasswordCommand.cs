using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class UpdatePasswordCommand
    {
        public string Cmnd { get; set; }
        public string CurrPassWord { get; set; }
        public string NewPassWord { get; set; }
    }
}
