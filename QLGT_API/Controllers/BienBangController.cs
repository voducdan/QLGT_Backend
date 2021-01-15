using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLGT_API.Commands;
using QLGT_API.Model;
using QLGT_API.Models;
using QLGT_API.Repository;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class BienBangController : ControllerBase
    {
        private readonly BienBangRepository bienBangRepository;
        private readonly BienBangService bienBangService;
        private readonly KhachHangService khachHangService;

        public BienBangController(BienBangRepository bienBangRepository, BienBangService bienBangService, KhachHangService khachHangService)
        {
            this.bienBangRepository = bienBangRepository;
            this.bienBangService = bienBangService;
            this.khachHangService = khachHangService;
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
                ListView<BienBangModel> bienbang = this.bienBangRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, m => m.HOAT_DONG == 1);
                if (bienbang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any report"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = bienbang
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
                    error = "Report id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var bienbang = this.bienBangRepository.Get(w => w.MA_BIEN_BANG == id);
                if (bienbang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Report not found"
                    });
                }
                var danhSachLoiViPham = this.bienBangService.GetDanhSachLoiViPham(bienbang.MA_BIEN_BANG);
                return Ok(new
                {
                    success = true,
                    data = danhSachLoiViPham
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBienBangCommand command)
        {
            KhachHangModel khachHangModel = new KhachHangModel();
            khachHangModel = khachHangService.GetKhachHang(command.CMND);

            BienBangModel bb = new BienBangModel();
            if (khachHangModel!= null)
            {               
                bb.MA_KHACH_HANG = khachHangModel.MA_KHACH_HANG;
                bb.MA_SO_CONG_AN = command.MA_SO_CONG_AN;
                bb.NOI_LAP = command.NOI_LAP;
                bb.DON_VI_LAP_BIEN_BANG = command.DON_VI_LAP_BIEN_BANG;
                bb.DON_VI_YC_NOP_PHAT = command.DON_VI_YC_NOP_PHAT;
                bb.TONG_TIEN = command.TONG_TIEN;
                bb.NGAY_YC_NOP_PHAT = command.NGAY_YC_NOP_PHAT;
                bb.TRANG_THAI = command.TRANG_THAI;
                bb.GHI_CHU = command.GHI_CHU;
                bb.HOAT_DONG = command.HOAT_DONG;
                bb.Y_KIEN_BO_XUNG = command.Y_KIEN_BO_XUNG;
                bb.NGAY_TAO = DateTime.Now;
                bb.NGAY_LAP = DateTime.Now;
                bb.NGAY_CAP_NHAT = DateTime.Now;
                

                this.bienBangRepository.Create(bb);
                return Ok(new
                {
                    success = true,
                    data = bb
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    error = "CMND is not exists and Fail"
                });
            }     
        }

        [HttpPut]
        public IActionResult Update([FromBody] BienBangModel bienbang)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var BienBang = this.bienBangService.GetBienBang_id(bienbang.MA_BIEN_BANG);

                if (BienBang != null)
                {
                    bienBangRepository.Update(bienbang);
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
                    error = "Report id not found"
                });
            }
            try
            {
                var bienbang = bienBangService.GetBienBang_id(id);
                if (bienbang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Report not found"
                    });
                }
                this.bienBangRepository.Delete(bienbang);
                return Ok(new
                {
                    success = true,
                    data = bienbang
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
