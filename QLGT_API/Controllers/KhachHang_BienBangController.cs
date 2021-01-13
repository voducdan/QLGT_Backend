using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLGT_API.Repository;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{

    [Route("api/KhachHang_BienBang")]
    [ApiController]
    public class KhachHang_BienBangController : ControllerBase
    {
        //private BienBangService bienBangService;
        private BienBangRepository bienBangRepository;

        public KhachHang_BienBangController(BienBangRepository bienBangRepository)
        {
            this.bienBangRepository = bienBangRepository;
        }

        [HttpGet("{id}")]
        public ListBienBangKHView Get(int id)
        {
            ListBienBangKHView list = new ListBienBangKHView();
            try
            {
                list.Data = bienBangRepository.GetAll(w => w.MA_KHACH_HANG == id);
                list.MaKH = id;
                
            }
            catch (IOException e)
            {
                list.Data = null;
                list.MaKH = id;                
            }
            return list;
        }
    }
}

