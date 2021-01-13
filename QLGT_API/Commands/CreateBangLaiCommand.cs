using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class CreateBangLaiCommand
    {
        public string? CMND { get; set; }
        public int MA_LOAI_BANG_LAI { get; set; }
        public string? NOI_CAP_NCK { get; set; }
        public int THOI_HAN_SU_DUNG { get; set; }
    }
}
