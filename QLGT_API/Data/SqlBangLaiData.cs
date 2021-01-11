using Microsoft.EntityFrameworkCore;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Utils;

namespace QLGT_API.Data
{
    public class SqlBangLaiData : IBangLaiData
    {
        private readonly QLGTDBContext _db;
        public SqlBangLaiData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<KhachHang_BangLaiModel>> GetAll()
        {
            if(_db != null)
            {
                var query = await _db.BANGLAI_KHACHHANG.FromSqlRaw($@"select KH.MA_KHACH_HANG, KH.TEN_KHACH_HANG, KH.QUOC_TICH, KH.GIOI_TINH, KH.CMND, KH.TUOI, KH.DIA_CHI, BL.MA_BANG_LAI, BL.MA_LOAI_BANG_LAI, BL.NGAY_CAP_NCK, BL.NOI_CAP_NCK, BL.THOI_HAN_SU_DUNG, BL.NGAY_TAO, BL.NGAY_CAP_NHAT, BL.HOAT_DONG, LBL.TEN_LOAI_BANG_LAI from KHACH_HANG KH join BANG_LAI BL on KH.MA_KHACH_HANG = BL.MA_KHACH_HANG join LOAI_BANG_LAI LBL on LBL.MA_LOAI_BANG_LAI = BL.MA_LOAI_BANG_LAI").ToListAsync();
                return query;
            }
            return null;
        }
        public async Task<KhachHang_BangLaiModel> Get(string id)
        {
            if (_db != null)
            {
                var temp = $@"select KH.MA_KHACH_HANG, KH.TEN_KHACH_HANG, KH.QUOC_TICH, KH.GIOI_TINH, KH.CMND, KH.TUOI, KH.DIA_CHI, BL.MA_BANG_LAI, BL.MA_LOAI_BANG_LAI, BL.NGAY_CAP_NCK, BL.NOI_CAP_NCK, BL.THOI_HAN_SU_DUNG, BL.NGAY_TAO, BL.NGAY_CAP_NHAT, BL.HOAT_DONG, LBL.TEN_LOAI_BANG_LAI from KHACH_HANG KH join BANG_LAI BL on KH.MA_KHACH_HANG = BL.MA_KHACH_HANG join LOAI_BANG_LAI LBL on LBL.MA_LOAI_BANG_LAI = BL.MA_LOAI_BANG_LAI where MA_BANG_LAI = '{id}'";
                var query = await _db.BANGLAI_KHACHHANG.FromSqlRaw(temp).FirstOrDefaultAsync();
                return query;
            }
            return null;
        }
        //public async Task<string> Create(KhachHang_BangLaiModel banglai)
        //{
        //    var id = CreateHashString.GetHashString(banglai.CMND);
        //    banglai.
        //    return "";
        //}

        //public async Task<int> Update(KhachHang_BangLaiModel banglai)
        //{
        //    if (_db != null)
        //    {
        //        banglai.NGAY_CAP_NHAT = DateTime.Now;
        //        banglai.NGAY_TAO = (DateTime)KhachHang_BangLaiModel.NGAY_TAO;
        //        _db.BANGLAI_KHACHHANG.Update(banglai);
        //    }
        //}

        //public async Task<KhachHang_BangLaiModel> Delete(string id)
        //{
        //    if(_db != null)
        //    {
        //        var banglai = await Get(id);
        //        if (banglai != null)
        //        {
        //            _db.BANGLAI_KHACHHANG.RemoveRange(_db.BANGLAI_KHACHHANG.Where(bl_kh => bl_kh.MA_BANG_LAI == id));
        //            await _db.SaveChangesAsync();
        //            return banglai;
        //        }
        //    }
        //    return null;
        //}
    }
}
