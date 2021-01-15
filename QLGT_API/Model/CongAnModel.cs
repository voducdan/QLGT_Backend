using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class CongAnModel
    {
        [Key]
        public int MA_SO_CONG_AN { get; set; }
        public string? TEN_CONG_AN { get; set; }
        public string? CAP_BAC__CHUC_VU { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
    }
}