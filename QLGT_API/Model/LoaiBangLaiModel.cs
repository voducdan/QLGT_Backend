using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Models
{
    public class LoaiBangLaiModel
    {
        [Key]
        public int MA_LOAI_BANG_LAI { get; set; }
        [Required]
        public string TEN_LOAI_BANG_LAI { get; set; }
        public string MO_TA { get; set; }
    }
}
