using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BT2.Models
{
    public class BangLaiModel
    {
        [Key]
        public string MA_BANG_LAI { get; set; }
        [Required]
        public string MA_LOAI_BANG_LAI { get; set; }
        [Required]
        public string MA_KHACH_HANG { get; set; }
        [Required]
        public DateTime NGAY_CAP_NCK { get; set; }
        [Required]
        public string NOI_CAP_NCK { get; set; }
        public int THOI_HAN_SU_DUNG { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        [Required]
        public bool HOAT_DONG { get; set; }
    }
}
