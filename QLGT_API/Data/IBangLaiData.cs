using QLGT_API.Models;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLGT_API.Data
{
    public interface IBangLaiData
    {
        Task<ListView<KhachHang_BangLaiModel>> GetAll(int? pageSize, int? pageIndex);
        Task<KhachHang_BangLaiModel> Get(int id);
        Task<int> Update(BangLaiModel kh_bl);
        Task<int> Delete(int id);
        Task<int> Create(BangLaiModel bl);
        Task<List<LoaiBangLaiModel>> GetLisenceType();
    }
}
