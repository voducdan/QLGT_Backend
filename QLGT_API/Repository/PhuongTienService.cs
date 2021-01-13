using QLGT_API.Data;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class PhuongTienService : BaseService
    {
        public PhuongTienService(QLGTDBContext context) : base(context)
        {
        }
        public PhuongTienModel GetPhuongTien_id(int id)
        {
            return context.PHUONG_TIEN.FirstOrDefault(ww => ww.MA_PHUONG_TIEN == id);
        }
    }
}