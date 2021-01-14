using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Views
{
    public class DanhSachLoiViPhamView
    {
        public int MA_BIEN_BANG { get; set; }
        public int MA_SO_CONG_AN { get; set; }
        public string? TEN_CONG_AN { get; set; }
        public string? TEN_KHACH_HANG { get; set; }
        public string? LOI_VI_PHAM { get; set; }
        public double GIA_PHAT { get; set; }
    }
}
