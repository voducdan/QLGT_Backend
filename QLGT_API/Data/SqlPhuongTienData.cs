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
using QLGT_API.Model;
using QLGT_API.Views;

namespace QLGT_API.Data
{
    public class SqlPhuongTienData : IPhuongTienData
    {
        private readonly QLGTDBContext _db;

        public SqlPhuongTienData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<ListView<PhuongTienViewModel>> GetAll(int? PageSize, int? PageIndex)
        {
            if (_db != null)
            {
                if (PageSize.HasValue && PageIndex.HasValue)
                {
                    int? PagePrev = PageIndex - 1;
                    int? PageNext = PageIndex + 1;
                    
                    int to = PageSize.Value * PageIndex.Value;
                    int from = PageSize.Value * (PageIndex.Value - 1);
                    var query = await _db.PHUONG_TIEN_VIEW.FromSqlRaw($@"WITH DerTable AS(
					SELECT MA_PHUONG_TIEN,MA_KHACH_HANG,MA_LOAI_PHUONG_TIEN,SO_PHUONG_TIEN,SO_MAY,NGAY_DANG_KY ,MAU_SON,NHAN_HIEU,DUNG_TICH,BIEN_SO_XE,NGAY_DAU_DANG_KY,GHI_CHU,NGAY_TAO,NGAY_CAP_NHAT,HOAT_DONG,

					ROW_NUMBER() OVER(ORDER BY MA_PHUONG_TIEN) AS RowNumber
						FROM 
							PHUONG_TIEN 
				)
                   select pt.MA_PHUONG_TIEN,kh.TEN_KHACH_HANG,lpt.TEN_LOAI_PHUONG_TIEN,pt.SO_PHUONG_TIEN,pt. SO_MAY,NGAY_DANG_KY ,pt. MAU_SON,NHAN_HIEU,pt.DUNG_TICH,BIEN_SO_XE,pt.NGAY_DAU_DANG_KY,GHI_CHU,pt.NGAY_TAO,pt.NGAY_CAP_NHAT,pt.HOAT_DONG
					 from DerTable pt
                    join KHACH_HANG kh on KH.MA_KHACH_HANG = PT.MA_KHACH_HANG 
                    join LOAI_PHUONG_TIEN lpt on lpt.MA_LOAI_PHUONG_TIEN = PT.MA_LOAI_PHUONG_TIEN
                    WHERE RowNumber BETWEEN {from} AND {to}").ToListAsync();
                    int maxsize = query.Count();
                    if (PageNext > (maxsize / PageSize) + 1) PageNext = 0;
                    return new ListView<PhuongTienViewModel>() { Data = query, PrePage=PagePrev,NextPage=PageNext ,CurrPage=PageIndex,LastPage= (maxsize /PageSize)+1};
                }
            }
            return null;
        }
        public async Task<PhuongTienViewModel> Get(int id)
        {
            if (_db != null)
            {
                var temp = $@"select pt.MA_PHUONG_TIEN,kh.TEN_KHACH_HANG,lpt.TEN_LOAI_PHUONG_TIEN,pt.SO_PHUONG_TIEN,pt. SO_MAY,NGAY_DANG_KY ,pt. MAU_SON,NHAN_HIEU,pt.DUNG_TICH,BIEN_SO_XE,pt.NGAY_DAU_DANG_KY,GHI_CHU,pt.NGAY_TAO,pt.NGAY_CAP_NHAT,pt.HOAT_DONG
					 from PHUONG_TIEN pt
                    join KHACH_HANG kh on KH.MA_KHACH_HANG = PT.MA_KHACH_HANG 
                    join LOAI_PHUONG_TIEN lpt on lpt.MA_LOAI_PHUONG_TIEN = PT.MA_LOAI_PHUONG_TIEN
					Where pt.MA_PHUONG_TIEN='{id}'";
                var query = await _db.PHUONG_TIEN_VIEW.FromSqlRaw(temp).FirstOrDefaultAsync();
                return query;
            }
            return null;
        }
            public async Task<int> Update(PhuongTienModel phuongtien)
        {
            if (_db != null)
            {
                phuongtien.NGAY_CAP_NHAT = DateTime.Now;
                phuongtien.NGAY_TAO = (DateTime)phuongtien.NGAY_TAO;
                _db.PHUONG_TIEN.Update(phuongtien);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            if (_db != null)
            {
                var phuongtien = await Get(id);
                if (phuongtien != null)
                {
                    _db.PHUONG_TIEN.RemoveRange(_db.PHUONG_TIEN.Where(delPhuongTien => delPhuongTien.MA_PHUONG_TIEN == id));
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
        public async Task<int> Create(PhuongTienModel phuongtien)
        {
            phuongtien.NGAY_TAO = DateTime.Now;
            phuongtien.NGAY_CAP_NHAT = DateTime.Now;
            if (_db != null)
            {
                await _db.PHUONG_TIEN.AddAsync(phuongtien);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
