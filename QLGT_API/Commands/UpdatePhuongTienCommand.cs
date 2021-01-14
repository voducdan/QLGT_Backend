using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class UpdatePhuongTienCommand
    {
        public int MA_PHUONG_TIEN { get; set; }
        public string? SO_PHUONG_TIEN { get; set; }

        public string? SO_MAY { get; set; }


        public string? MAU_SON { get; set; }

        public string? NHAN_HIEU { get; set; }

        public int? DUNG_TICH { get; set; }

        public string? BIEN_SO_XE { get; set; }


        public string? GHI_CHU { get; set; }


    }
}
