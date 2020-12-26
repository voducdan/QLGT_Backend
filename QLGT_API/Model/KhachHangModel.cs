using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BT2.Models
{
    public class KhachHangModel
    {
        [Key]
        public string MA_KHACH_HANG { get; set; }
        [Required]
        public string TEN_KHACH_HANG { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string DIA_CHI { get; set; }
        public string SDT { get; set; }
        [Required]
        public int TUOI { get; set; }
        public string GIOI_TINH { get; set; }
        [Required]
        public string CMND { get; set; }
        [Required]
        public string QUOC_TICH { get; set; }
        [Required]
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        [Required]
        public bool HOAT_DONG { get; set; }
    }
}
