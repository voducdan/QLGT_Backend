using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class PhuongTienModel
    {
        [Key]
        public string MA_PHUONG_TIEN { get; set; }
        [Required]
        public string MA_KHACH_HANG { get; set; }
        [Required]
        public int MA_LOAI_PHUONG_TIEN { get; set; }

        public string SO_PHUONG_TIEN { get; set; }
        public string SO_MAY { get; set; }
        public DateTime NGAY_DANG_KY { get; set; }
        public string MAU_SON { get; set; }
        public string NHAN_HIEU { get; set; }
        public int DUNG_TICH { get; set; }
        public string BIEN_SO_XE { get; set; }
        public DateTime NGAY_DAU_DANG_KY { get; set; }
        public string GHI_CHU { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
    }
}
