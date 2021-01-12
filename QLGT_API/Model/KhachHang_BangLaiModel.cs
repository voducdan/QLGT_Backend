using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Models
{
    public class KhachHang_BangLaiModel
    {
        [Key]
        public int MA_BANG_LAI { get; set; }
        [Required]
        public int MA_LOAI_BANG_LAI { get; set; }
        [Required]
        public int TEN_LOAI_BANG_LAI { get; set; }
        [Required]
        public int MA_KHACH_HANG { get; set; }
        [Required]
        public string TEN_KHACH_HANG { get; set; }
        [Required]
        public DateTime NGAY_CAP_NCK { get; set; }
        [Required]
        public string NOI_CAP_NCK { get; set; }
        public int THOI_HAN_SU_DUNG { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        [Required]
        public int HOAT_DONG { get; set; }
        public string CMND { get; set; }
    }
}
