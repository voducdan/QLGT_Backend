﻿using Microsoft.EntityFrameworkCore;
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

        //public LoiViPhamModel GetName(string Name)
        //{
        //    var nameLaw = from m in _context.Movie
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    return View(await movies.ToListAsync());
        //}
    }
}
