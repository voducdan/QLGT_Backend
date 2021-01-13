using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class NhomLoiViPhamModel
    {
        public int MA_NHOM_VI_PHAM { get; set; }
        public string TEN_NHOM_VI_PHAM { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
        
    }
}
