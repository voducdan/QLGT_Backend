using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BT2.Models
{
    public class LoaiBangLaiModel
    {
        [Key]
        public string MA_LOAI_BANG_LAI { get; set; }
        [Required]
        public string TEN_LOAI_BANG_LAI { get; set; }
        public string MO_TA { get; set; }
    }
}
