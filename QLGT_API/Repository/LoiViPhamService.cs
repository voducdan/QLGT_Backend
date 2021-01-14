using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class LoiViPhamService : BaseService
    {
        public LoiViPhamService(QLGTDBContext context) : base(context)
        {
        }

        public LoiViPhamModel GetLoiViPham_id(int id)
        {
            var loivipham = context.LOI_VI_PHAM.FirstOrDefault(ww => ww.MA_LOI_VI_PHAM == id);
            context.Entry(loivipham).State = EntityState.Detached;
            return loivipham;
        }

        public List<LoiViPhamModel> GetName(string Name)
        {
            var nameLaw = from m in context.LOI_VI_PHAM
                          select m;
            if (!String.IsNullOrEmpty(Name))
            {
                nameLaw = nameLaw.Where(s => s.TEN_LOI_VI_PHAM.Contains(Name));
            }
            return nameLaw.ToList();
        }
    }
}
