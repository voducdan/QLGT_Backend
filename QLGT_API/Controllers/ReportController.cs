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
    [Route("api/agg/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService reportService;
        public ReportController(ReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        public IActionResult BangLaiReport()
        {
            try
            {
                var data = reportService.BienBangReport();
                return Ok(new
                {
                    success = true,
                    data = data
                });
            }
            catch (IOException e)
            {
                return Ok(new
                {
                    success = false,
                    error = "Error when aggregating"
                });
            }
        }
        [Route("danhsachloivipham")]
        [HttpGet]
        public IActionResult DanhSachLoiViPham()
        {
            try
            {
                var data = reportService.DanhSachLoiViPham();
                return Ok(new
                {
                    success = true,
                    data = data
                });
            }
            catch (IOException e)
            {
                return Ok(new
                {
                    success = false,
                    error = "Error when aggregating"
                });
            }
        }
    }
}
