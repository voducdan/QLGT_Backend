using QLGT_API.Data;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLGT_API.Repository
{
    public class BangLaiRepository : BaseRepository<KhachHang_BangLaiModel>
    {
        public BangLaiRepository(QLGTDBContext context) : base(context)
        {
        }
    }
}
