using QLGT_API.Data;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class KhachHangRepository : BaseRepository<KhachHangModel>
    {
        public KhachHangRepository(QLGTDBContext context) : base(context)
        {
        }
        public KhachHangModel Get(int id)
        {
            return context.Set<KhachHangModel>().FirstOrDefault(m => m.MA_KHACH_HANG == id);
        }
    }
}
