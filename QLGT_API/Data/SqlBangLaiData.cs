using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Data
{
    public class SqlBangLaiData : IBangLaiData
    {
        private readonly QLGTDBContext _db;
        public SqlBangLaiData(QLGTDBContext db)
        {
            _db = db;  
        }
    }
}
