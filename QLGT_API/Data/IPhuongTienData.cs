using QLGT_API.Model;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace QLGT_API.Data
{
    public interface IPhuongTienData
    {
        //Task<IEnumerable<PhuongTienModel>> GetAll();
        Task<IEnumerable<PhuongTienViewModel>> GetAll(int? PageSize, int? PageIndex);
        Task<PhuongTienViewModel> Get(int id);
        Task<int> Create(PhuongTienModel phuongtien);
        //Task<int> Delete(PhuongTienModel phuongtien);
     
        Task<int> Delete(int id);
        Task<int> Update(PhuongTienModel phuongtien);
        //Task<int> Update(KhachHangModel khachhang);
        //Task<KhachHangModel> Delete(string id);
    }
}
