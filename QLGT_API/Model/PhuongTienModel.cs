using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace QLGT_API.Models
{
    public class PhuongTienModel
    {

        [Key]

        public int MA_PHUONG_TIEN { get; set; }
        [Required]
        public int MA_KHACH_HANG { get; set; }
        [Required]

        public int MA_LOAI_PHUONG_TIEN { get; set; }
        [Required]
        public string SO_PHUONG_TIEN { get; set; }
        [Required]
        public string SO_MAY { get; set; }
        [Required]
        public DateTime NGAY_DANG_KY { get; set; }
        [Required]
        public string MAU_SON { get; set; }
        [Required]
        public string NHAN_HIEU { get; set; }
        [Required]
        public int DUNG_TICH { get; set; }
        [Required]
        public string BIEN_SO_XE { get; set; }
        [Required]
        public DateTime NGAY_DAU_DANG_KY { get; set; }

        public string GHI_CHU { get; set; }
        [Required]
        public DateTime NGAY_TAO { get; set; }
        [Required]
        public DateTime NGAY_CAP_NHAT { get; set; }
        [Required]
        public int HOAT_DONG { get; set; }

    }
}
