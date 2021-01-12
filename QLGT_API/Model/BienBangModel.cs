using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Model
{
    public class BienBangModel
    {
        public int MA_BIEN_BANG { get; set; }
        public int MA_KHACH_HANG { get; set; }
        public int MA_SO_CONG_AN { get; set; }
        public DateTime NGAY_LAP { get; set; }
        public string NOI_LAP { get; set; }
        public string DON_VI_LAP_BIEN_BANG { get; set; }
        public float TONG_TIEN { get; set; }
        public string TRANG_THAI { get; set; }
        public string GHI_CHU { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
        public int HOAT_DONG { get; set; }
        public string Y_KIEN_BO_XUNG { get; set; }
        
    }
}
