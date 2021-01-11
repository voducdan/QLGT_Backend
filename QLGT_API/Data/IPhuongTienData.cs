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
        Task<IEnumerable<PhuongTienModel>> GetAll();
        //Task<string> Create(KhachHangModel khachhang);
        Task<PhuongTienModel> Get(string id);
        Task<int> Update(PhuongTienModel phuongtien);
        //Task<int> Update(KhachHangModel khachhang);
        //Task<KhachHangModel> Delete(string id);
    }
}
