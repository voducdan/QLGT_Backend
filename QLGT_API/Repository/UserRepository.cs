using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public UserRepository(QLGTDBContext context) : base(context)
        {
        }
    }
}
