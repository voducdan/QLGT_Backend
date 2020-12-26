using BT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Data
{
    public class SqlKhachHangData: IKhachHangData
    {
        private readonly QLGTDBContext _db;

        public SqlKhachHangData(QLGTDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<KhachHangModel>> GetAll()
        {
            var query = await _db.KHACH_HANG.FromSqlRaw("select * from KHACH_HANG").ToListAsync();
            return query;
        }
    }
}
