using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class CreateLoiViPhamCommand
    {
        public int MA_LOI_VI_PHAM { get; set; }
        public int MA_NHOM_VI_PHAM { get; set; }
        public int MA_LOAI_PHUONG_TIEN { get; set; }
        public string? TEN_LOI_VI_PHAM { get; set; }
        public string? NOI_DUNG { get; set; }
        public double MUC_PHAT_TOI_THIEU  { get; set; }
        public double MUC_PHAT_TOI_DA { get; set; }
        public string? DIEU_LUAT { get; set; }
        public int HOAT_DONG { get; set; }
    }
}
