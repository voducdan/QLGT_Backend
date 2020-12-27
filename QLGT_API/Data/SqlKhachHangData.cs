﻿using QLGT_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using QLGT_API.Utils;

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
        public async Task<KhachHangModel> Get(string id)
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
        public async Task<string> Create(KhachHangModel khachhang)
        {
            var id = CreateHashString.GetHashString(khachhang.CMND);

            khachhang.MA_KHACH_HANG = id;
            khachhang.NGAY_TAO = DateTime.Now;
            khachhang.NGAY_CAP_NHAT = DateTime.Now;
            if (_db != null)
            {
                await _db.KHACH_HANG.AddAsync(khachhang);
                await _db.SaveChangesAsync();
                return khachhang.MA_KHACH_HANG;
            }
            return "";
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
        public async Task<KhachHangModel> Delete(string id)
        {
            if (_db != null)
            {
                var khachhang = await Get(id);
                if (khachhang != null)
                {
                    _db.KHACH_HANG.Remove(khachhang);
                    await _db.SaveChangesAsync();
                    return khachhang;
                }
            }
            return null;
        }

    }
}
