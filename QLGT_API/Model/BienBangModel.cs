using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QLGT_API.Model
{
    public class BienBangModel
    {
        [Key]
        public int MA_BIEN_BANG { get; set; }
        public int MA_KHACH_HANG { get; set; }
        public int MA_SO_CONG_AN { get; set; }
        [Required]
        public DateTime NGAY_LAP { get; set; }
        [Required]
        public string? NOI_LAP { get; set; }
        [Required]
        public string? DON_VI_LAP_BIEN_BANG { get; set; }
        [Required]
        public DateTime NGAY_YC_NOP_PHAT { get; set; }
        [Required]
        public string? DON_VI_YC_NOP_PHAT { get; set; }
        [Required]
        public double TONG_TIEN { get; set; }
        [Required]
        public string? TRANG_THAI { get; set; }
        public string? GHI_CHU { get; set; }
        [Required]
        public DateTime NGAY_TAO { get; set; }
        [Required]
        public DateTime NGAY_CAP_NHAT { get; set; }
        [Required]
        public int HOAT_DONG { get; set; }
        public string? Y_KIEN_BO_XUNG { get; set; }

    }
}
