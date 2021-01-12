﻿using Microsoft.EntityFrameworkCore;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Utils;
using QLGT_API.Commands;
using Microsoft.AspNetCore.Mvc;

namespace QLGT_API.Data
{
    public class SqlBangLaiData : IBangLaiData
    {
        private readonly QLGTDBContext _db;

        public SqlBangLaiData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<KhachHang_BangLaiModel>> GetAll(int? PageSize, int? PageIndex)
        {
            if (_db != null)
            {
                if (PageSize.HasValue && PageIndex.HasValue)
                {
                    int to = PageSize.Value * PageIndex.Value;
                    int from = PageSize.Value * (PageIndex.Value - 1);
                    var query = await _db.BANGLAI_KHACHHANG.FromSqlRaw($@"WITH DerTable AS(
					SELECT
						MA_BANG_LAI,MA_LOAI_BANG_LAI,MA_KHACH_HANG, NGAY_CAP_NCK, NOI_CAP_NCK, THOI_HAN_SU_DUNG, NGAY_TAO, HOAT_DONG, NGAY_CAP_NHAT,
						ROW_NUMBER() OVER(ORDER BY MA_BANG_LAI) AS RowNumber
						FROM 
							BANG_LAI
				)
                    select KH.MA_KHACH_HANG, KH.TEN_KHACH_HANG, KH.QUOC_TICH, KH.GIOI_TINH, KH.CMND, KH.TUOI, KH.DIA_CHI, BL.MA_BANG_LAI, BL.MA_LOAI_BANG_LAI, BL.NGAY_CAP_NCK, BL.NOI_CAP_NCK, BL.THOI_HAN_SU_DUNG, BL.NGAY_CAP_NHAT, BL.NGAY_TAO, BL.HOAT_DONG, LBL.TEN_LOAI_BANG_LAI
                    from DerTable BL
                    join KHACH_HANG KH on KH.MA_KHACH_HANG = BL.MA_KHACH_HANG 
                    join LOAI_BANG_LAI LBL on LBL.MA_LOAI_BANG_LAI = BL.MA_LOAI_BANG_LAI
                    WHERE RowNumber BETWEEN {from} AND {to}").ToListAsync();
                    return query;
                }
               
            }
            return null;
        }
        public async Task<KhachHang_BangLaiModel> Get(int id)
        {
            if (_db != null)
            {
                var temp = $@"select KH.MA_KHACH_HANG, KH.TEN_KHACH_HANG, KH.QUOC_TICH, KH.GIOI_TINH, KH.CMND, KH.TUOI, KH.DIA_CHI, BL.MA_BANG_LAI, BL.MA_LOAI_BANG_LAI, BL.NGAY_CAP_NCK, BL.NOI_CAP_NCK, BL.THOI_HAN_SU_DUNG, BL.NGAY_TAO, BL.NGAY_CAP_NHAT, BL.HOAT_DONG, LBL.TEN_LOAI_BANG_LAI from KHACH_HANG KH join BANG_LAI BL on KH.MA_KHACH_HANG = BL.MA_KHACH_HANG join LOAI_BANG_LAI LBL on LBL.MA_LOAI_BANG_LAI = BL.MA_LOAI_BANG_LAI where MA_BANG_LAI = '{id}'";
                var query = await _db.BANGLAI_KHACHHANG.FromSqlRaw(temp).FirstOrDefaultAsync();
                return query;
            }
            return null;
        }

        public async Task<int> Create(BangLaiModel bl)
        {
            bl.NGAY_TAO = DateTime.Now;
            bl.NGAY_CAP_NHAT = DateTime.Now;
            if (_db != null)
            {
                await _db.BANG_LAI.AddAsync(bl);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

    public async Task<int> Update(BangLaiModel bl)
        {
            if (_db != null)
            {
                bl.NGAY_CAP_NHAT = DateTime.Now;
                bl.NGAY_TAO = (DateTime)bl.NGAY_TAO;
                _db.BANG_LAI.Update(bl);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            if (_db != null)
            {
                var banglai = await Get(id);
                if (banglai != null)
                {
                    _db.BANG_LAI.RemoveRange(_db.BANG_LAI.Where(delBl => delBl.MA_BANG_LAI == id));
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
    }
}
