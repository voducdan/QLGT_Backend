using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class CreateKhachHangCommand
    {
        public CreateKhachHangCommand(string tEN_KHACH_HANG, string eMAIL, string dIA_CHI, string sDT, int tUOI, string gIOI_TINH, string cMND, string qUOC_TICH, DateTime nGAY_CAP_NHAT, int hOAT_DONG, DateTime nGAY_TAO)
        {
            TEN_KHACH_HANG = tEN_KHACH_HANG;
            EMAIL = eMAIL;
            DIA_CHI = dIA_CHI;
            SDT = sDT;
            TUOI = tUOI;
            GIOI_TINH = gIOI_TINH;
            CMND = cMND;
            QUOC_TICH = qUOC_TICH;
            NGAY_CAP_NHAT = nGAY_CAP_NHAT;
            HOAT_DONG = hOAT_DONG;
            NGAY_TAO = nGAY_TAO;
        }

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
