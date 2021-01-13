using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class PhieuNopPhatModel
    {
        [Key]
        public int MA_GIAO_DICH { get; set; }
        public int MA_BIEN_BANG { get; set; }
        public DateTime NGAY_LAP { get; set; }
        public string? HINH_THUC_THANH_TOAN { get; set; }
        public float TONG_TIEN { get; set; }
        public string? NGAN_HANG {get; set; }
        public string? SO_THE_SO_TAI_KHOAN { get; set; }
        public float PHI_GIAO_DICH { get; set; }
        public string? GHI_CHU { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
      
    }
}
