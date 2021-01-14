using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLGT_API.Commands;
using QLGT_API.Model;
using QLGT_API.Repository;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [Route("api/laws")]
    [ApiController]
    public class LoiViPhamController : ControllerBase
    {
        private readonly LoiViPhamRepository loiViPhamRepository;
        private readonly LoiViPhamService loiViPhamService;
        public LoiViPhamController(LoiViPhamRepository loiViPhamRepository, LoiViPhamService loiViPhamService)
        {
            this.loiViPhamRepository = loiViPhamRepository;
            this.loiViPhamService = loiViPhamService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PageCommand pageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ListView<LoiViPhamModel> loivipham = this.loiViPhamRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, m => m.HOAT_DONG == 1);
                if (loivipham == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any law"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = loivipham
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Law id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var loivipham = this.loiViPhamRepository.Get(w => w.MA_LOI_VI_PHAM == id);
                if (loivipham == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Law not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = loivipham
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpGet("Name")]
        [Route("test")]
        public IActionResult Get([FromBody] TestCommand test) { 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var loivipham = this.loiViPhamRepository.Get(w => w.TEN_LOI_VI_PHAM.Contains(test.NAME) == true);
                if (loivipham == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Law not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = loivipham
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLoiViPhamCommand command)
        {
            LoiViPhamModel lvp = new LoiViPhamModel();
            lvp.MA_NHOM_VI_PHAM = command.MA_NHOM_VI_PHAM;
            lvp.MA_LOAI_PHUONG_TIEN = command.MA_LOAI_PHUONG_TIEN;
            lvp.TEN_LOI_VI_PHAM = command.TEN_LOI_VI_PHAM;
            lvp.NOI_DUNG = command.NOI_DUNG;
            lvp.MUC_PHAT_TOI_THIEU = command.MUC_PHAT_TOI_THIEU;
            lvp.MUC_PHAT_TOI_DA = command.MUC_PHAT_TOI_DA;
            lvp.DIEU_LUAT = command.DIEU_LUAT;
            lvp.NGAY_TAO = DateTime.Now;
            lvp.NGAY_CAP_NHAT = DateTime.Now;
            lvp.HOAT_DONG = command.HOAT_DONG;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                this.loiViPhamRepository.Create(lvp);
                return Ok(new
                {
                    success = true,
                    data = lvp
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] LoiViPhamModel loivipham)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var LoiViPham = this.loiViPhamService.GetLoiViPham_id(loivipham.MA_LOI_VI_PHAM);

                if (LoiViPham != null)
                {
                    loivipham.NGAY_CAP_NHAT = DateTime.Now;
                    loivipham.NGAY_TAO = DateTime.Now;
                    loiViPhamRepository.Update(loivipham);
                }
                return Ok(new
                {
                    success = true

                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Law id not found"
                });
            }
            try
            {
                var loivipham = loiViPhamService.GetLoiViPham_id(id);
                if (loivipham == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Law not found"
                    });
                }
                this.loiViPhamRepository.Delete(loivipham);
                return Ok(new
                {
                    success = true,
                    data = loivipham
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
