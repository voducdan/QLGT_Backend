using Microsoft.AspNetCore.Mvc;
using QLGT_API.Commands;
using QLGT_API.Models;
using QLGT_API.Repository;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private KhachHangRepository khachHangRepository;

        public UserController(KhachHangRepository khachHangRepository)
        {
            this.khachHangRepository = khachHangRepository;
        }

        public ListView<KhachHangModel> GetListUser([FromQuery] PageCommand pageCommand)
        {
           
                var list = khachHangRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, ww => ww.HOAT_DONG ==0);

            return list;
        }
    }
}
