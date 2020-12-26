using BT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Data
{
    public interface IKhachHangData
    {
        Task<IEnumerable<KhachHangModel>> GetAll();
    }
}
