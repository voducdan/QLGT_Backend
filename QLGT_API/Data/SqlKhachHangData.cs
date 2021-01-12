using QLGT_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using QLGT_API.Utils;
using System.IO;

namespace QLGT_API.Data
{
    public class SqlKhachHangData : IKhachHangData
    {
        private readonly QLGTDBContext _db;

        public SqlKhachHangData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<KhachHangModel>> GetAll()
        {
            if (_db != null)
            {
                var query = await _db.KHACH_HANG.FromSqlRaw("select * from KHACH_HANG").ToListAsync();
                return query;
            }
            return null;
        }
        public async Task<KhachHangModel> Get(int id)
        {
            if (_db != null)
            {
                var query = await (
                                from kh in _db.KHACH_HANG
                                where kh.MA_KHACH_HANG == id
                                select new KhachHangModel
                                {
                                    MA_KHACH_HANG = kh.MA_KHACH_HANG,
                                    TEN_KHACH_HANG = kh.TEN_KHACH_HANG,
                                    DIA_CHI = kh.DIA_CHI,
                                    EMAIL = kh.EMAIL,
                                    QUOC_TICH = kh.QUOC_TICH,
                                    GIOI_TINH = kh.GIOI_TINH,
                                    TUOI = kh.TUOI,
                                    SDT = kh.SDT,
                                    CMND = kh.CMND
                                }).FirstOrDefaultAsync();
                return query;
            }
            return null;
        }
        public async Task<int> Create(KhachHangModel khachhang)
        {
            //var id = CreateHashString.GetHashString(khachhang.CMND);
            if (Validate.ValidateEmail(khachhang.EMAIL) == 0)
            {
                return 10;
            }
            khachhang.MA_KHACH_HANG = 1;
            khachhang.NGAY_TAO = DateTime.Now;
            khachhang.NGAY_CAP_NHAT = DateTime.Now;
            if (_db != null)
            {
                await _db.KHACH_HANG.AddAsync(khachhang);
                await _db.SaveChangesAsync();
                return khachhang.MA_KHACH_HANG;
            }
            return 1;
        }
        public async Task<int> Update(KhachHangModel khachhang)
        {
            if (_db != null)
            {
                khachhang.NGAY_CAP_NHAT = DateTime.Now;
                khachhang.NGAY_TAO = (DateTime)khachhang.NGAY_TAO;
                _db.KHACH_HANG.Update(khachhang);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        public async Task<KhachHangModel> Delete(int id)
        {
            if (_db != null)
            {
                
               
                var khachhang = await Get(id);
                if (khachhang != null)
                {
                    _db.BANG_LAI.RemoveRange(_db.BANG_LAI.Where(bl => bl.MA_KHACH_HANG == id));
                    await _db.SaveChangesAsync();
                    _db.KHACH_HANG.Remove(khachhang);
                    await _db.SaveChangesAsync();
                    return khachhang;
                }
            }
            return null;
        }

    }
}
