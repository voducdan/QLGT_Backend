using Microsoft.EntityFrameworkCore;
using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Views;
using QLGT_API.Commands;

namespace QLGT_API.Repository
{
    public class BienBangService : BaseService
    {
        public BienBangService(QLGTDBContext context) : base(context)
        {
        }

        public BienBangModel GetBienBang_id(int id)
        {
            var bienbang = context.BIEN_BANG.FirstOrDefault(ww => ww.MA_BIEN_BANG == id);
            context.Entry(bienbang).State = EntityState.Detached;
            return bienbang;
        }
        public List<DanhSachLoiViPhamView> GetDanhSachLoiViPham(int MA_BIEN_BANG)
        {
            var danhSachLoiViPham = context.DANH_SACH_LOI_VI_PHAM.Join(context.LOI_VI_PHAM, ds => ds.MA_LOI_VI_PHAM, lvp => lvp.MA_LOI_VI_PHAM, (ds, lvp) => new DanhSachLoiViPhamView
            {
                MA_BIEN_BANG = ds.MA_BIEN_BANG,
                LOI_VI_PHAM = lvp.TEN_LOI_VI_PHAM,
                GIA_PHAT = ds.GIA_PHAT

            }).Where(w => w.MA_BIEN_BANG == MA_BIEN_BANG).ToList();
            return danhSachLoiViPham;
        }
    }
}
