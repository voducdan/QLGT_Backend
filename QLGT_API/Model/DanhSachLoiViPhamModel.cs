using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class DanhSachLoiViPhamModel
    {
        [Key]
        public int MA_BIEN_BANG { get; set; }
        
        public int MA_LOI_VI_PHAM { get; set; }
        public double GIA_PHAT { get; set; }
    }
}
