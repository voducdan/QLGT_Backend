using Microsoft.EntityFrameworkCore;
using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class BienBangService: BaseService
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
    }
}
