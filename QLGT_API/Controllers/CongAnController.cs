using Microsoft.AspNetCore.Mvc;
using QLGT_API.Model;
using QLGT_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [Route("api/congan")]
    [ApiController]
    public class CongAnController : ControllerBase
    {
        private CongAnRepository congAnRepository;
        private CongAnService congAnService;

        public CongAnController(CongAnRepository congAnRepository, CongAnService congAnService)
        {
            this.congAnRepository = congAnRepository;
            this.congAnService = congAnService;
        }
        [HttpGet]
        public List<CongAnModel> GetAll()
        {
            return congAnRepository.GetAll(m => m.HOAT_DONG == 1);
        }
    }
}
