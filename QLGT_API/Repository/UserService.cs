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

        public UserModel GetUser(string username)
        {
            return context.USER.FirstOrDefault(ww => ww.Username == username);
        }
    }
}
