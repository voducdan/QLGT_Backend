using QLGT_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Repository
{
    public class BaseService
    {
        protected QLGTDBContext context;
        public BaseService(QLGTDBContext context)
        {
            this.context = context;
        }
    }
}
