using QLGT_API.Data;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class KhachHangService : BaseService
    {
        public KhachHangService(QLGTDBContext context) : base(context)
        {
        }

        public KhachHangModel GetKhachHang(string cmnd)
        {
            return context.KHACH_HANG.FirstOrDefault(ww => ww.CMND == cmnd);
        }

        public KhachHangModel GetKhachHang_id(int id)
        {
            return context.KHACH_HANG.FirstOrDefault(ww => ww.MA_KHACH_HANG == id);
        }
    }
}
