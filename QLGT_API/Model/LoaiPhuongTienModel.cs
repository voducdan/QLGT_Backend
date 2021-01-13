using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Models
{
    public class LoaiPhuongTienModel
    {
        [Key]
        public string MA_LOAI_PHUONG_TIEN { get; set; }
        [Required]
        public string TEN_LOAI_PHUONG_TIEN { get; set; }

    }
}
