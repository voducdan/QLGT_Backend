using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLGT_API.Data
{
    public interface IBangLaiData
    {
        Task<IEnumerable<KhachHang_BangLaiModel>> GetAll();
        Task<KhachHang_BangLaiModel> Get(string id);
        //Task<KhachHang_BangLaiModel> Delete(string id);
    }
}
