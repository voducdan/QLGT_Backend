using QLGT_API.Data;
using QLGT_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class UserService : BaseService
    {
        public UserService(QLGTDBContext context) : base(context)
        {
        }

        public UserModel GetUser(string cmnd)
        {
            return context.ACCOUNT.FirstOrDefault(ww => ww.CMND == cmnd);
        }

        public UserModel GetUser_id(int id)
        {
            return context.ACCOUNT.FirstOrDefault(ww => ww.ID_ACCOUNT == id);
        }
    }
}
