using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace QLGT_API.Data
{
    public interface IKhachHangData
    {
        Task<IEnumerable<KhachHangModel>> GetAll();
        Task<int> Create(KhachHangModel khachhang);
        Task<KhachHangModel> Get(int id);
        Task<int> Update(KhachHangModel khachhang);
        Task<KhachHangModel> Delete(int id);
    }
}
