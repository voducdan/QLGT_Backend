using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class CreateKhachHangCommand
    {
        public string TEN_KHACH_HANG { get; set; }
        public string EMAIL { get; set; }
      
        public string DIA_CHI { get; set; }
     
        public string SDT { get; set; }
      
        public int TUOI { get; set; }
        
        public string GIOI_TINH { get; set; }
       
        public string CMND { get; set; }
       
        public string QUOC_TICH { get; set; }
        
        public DateTime NGAY_CAP_NHAT { get; set; } = DateTime.Now;
        public int HOAT_DONG { get; set; } = 1;
        public DateTime NGAY_TAO { get; set; } = DateTime.Now;
    }
}
