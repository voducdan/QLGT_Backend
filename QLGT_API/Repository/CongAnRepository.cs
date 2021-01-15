using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class CongAnRepository:BaseRepository<CongAnModel>
    {
        public CongAnRepository(QLGTDBContext context) : base(context)
        {
        }
    }
}
