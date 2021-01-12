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
    public class SqlPhuongTienData : IPhuongTienData
    {
        private readonly QLGTDBContext _db;

        public SqlPhuongTienData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<PhuongTienModel>> GetAll()
        {
            if (_db != null)
            {
                var query = await _db.PHUONG_TIEN.FromSqlRaw("select * from PHUONG_TIEN").ToListAsync();
                return query;
            }
            return null;
        }
        public async Task<PhuongTienModel> Get(int id)
        {
        if (_db != null)
        {
            var query = await (
                            from pt in _db.PHUONG_TIEN
                            where pt.MA_PHUONG_TIEN == id
                            select new PhuongTienModel
                            {
                                MA_PHUONG_TIEN = pt.MA_PHUONG_TIEN,
                                MA_KHACH_HANG = pt.MA_KHACH_HANG,
                                MA_LOAI_PHUONG_TIEN = pt.MA_LOAI_PHUONG_TIEN,
                                SO_PHUONG_TIEN = pt.SO_PHUONG_TIEN,
                                SO_MAY = pt.SO_MAY,
                                NGAY_DANG_KY = pt.NGAY_DANG_KY,
                                MAU_SON = pt.MAU_SON,
                                NHAN_HIEU = pt.NHAN_HIEU,
                                DUNG_TICH = pt.DUNG_TICH,
                                BIEN_SO_XE=pt.BIEN_SO_XE,
                                NGAY_DAU_DANG_KY=pt.NGAY_DAU_DANG_KY
                            }).FirstOrDefaultAsync();
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

        public Task<PhuongTienModel> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
