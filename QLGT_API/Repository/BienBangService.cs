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
            var danhSachLoiViPham = context.DANH_SACH_LOI_VI_PHAM.Join(context.LOI_VI_PHAM, ds => ds.MA_LOI_VI_PHAM, lvp => lvp.MA_LOI_VI_PHAM, (ds, lvp) => new
            {
                MA_BIEN_BANG = ds.MA_BIEN_BANG,
                LOI_VI_PHAM = lvp.TEN_LOI_VI_PHAM,
                GIA_PHAT = ds.GIA_PHAT

            }).Where(w => w.MA_BIEN_BANG == MA_BIEN_BANG).Join(context.BIEN_BANG, a => a.MA_BIEN_BANG, bb => bb.MA_BIEN_BANG, (a, bb) => new
            {
                MA_BIEN_BANG = a.MA_BIEN_BANG,
                LOI_VI_PHAM = a.LOI_VI_PHAM,
                GIA_PHAT = a.GIA_PHAT,
                MA_SO_CONG_AN = bb.MA_SO_CONG_AN,
                MA_KHACH_HANG = bb.MA_KHACH_HANG
            }).Join(context.KHACH_HANG, a => a.MA_KHACH_HANG, kh => kh.MA_KHACH_HANG, (a, kh) => new
            {
                MA_BIEN_BANG = a.MA_BIEN_BANG,
                LOI_VI_PHAM = a.LOI_VI_PHAM,
                GIA_PHAT = a.GIA_PHAT,
                MA_SO_CONG_AN = a.MA_SO_CONG_AN,
                MA_KHACH_HANG = a.MA_KHACH_HANG,
                TEN_KHACH_HANG = kh.TEN_KHACH_HANG
            }).Join(context.CONG_AN,a=>a.MA_SO_CONG_AN, ca=>ca.MA_SO_CONG_AN,(a,ca)=>new DanhSachLoiViPhamView
            {
                MA_BIEN_BANG = a.MA_BIEN_BANG,
                LOI_VI_PHAM = a.LOI_VI_PHAM,
                GIA_PHAT = a.GIA_PHAT,
                MA_SO_CONG_AN = a.MA_SO_CONG_AN,
                TEN_KHACH_HANG = a.TEN_KHACH_HANG,
                TEN_CONG_AN = ca.TEN_CONG_AN
            }).ToList();
            return danhSachLoiViPham;
        }
    }
}
