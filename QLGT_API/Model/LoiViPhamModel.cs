using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class LoiViPhamModel
    {
        [Key]
        public int MA_LOI_VI_PHAM { get; set; }
        public int MA_NHOM_VI_PHAM { get; set; }
        public int MA_LOAI_PHUONG_TIEN { get; set; }
        public string TEN_LOI_VI_PHAM { get; set; }
        public string NOI_DUNG { get; set; }
        public Double MUC_PHAT_TOI_THIEU { get; set; }
        public Double MUC_PHAT_TOI_DA { get; set; }
        public string DIEU_LUAT { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
        
    }
}
