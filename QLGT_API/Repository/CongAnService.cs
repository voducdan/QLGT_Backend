﻿using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class CongAnService : BaseService
    {
        public CongAnService(QLGTDBContext context) : base(context)
        {
        }

        //public List<CongAnModel> GetAllCongAn()
        //{
        //    return context.Set<CongAnModel>().Where(m=> m.HOAT_DONG == 1).ToList();
        //}
    }
}