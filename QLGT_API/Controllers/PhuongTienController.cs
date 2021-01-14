using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;
using QLGT_API.Data;
using System.IO;
using System.Runtime.InteropServices;
using QLGT_API.Repository;
using QLGT_API.Commands;


namespace QLGT_API.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class PhuongTienController : ControllerBase
    {
        private readonly IPhuongTienData _phuongtienData;
        private KhachHangService _khachHangService;
        public PhuongTienController(IPhuongTienData phuongTienData, KhachHangService khachHangService)
        {
            this._phuongtienData = phuongTienData;
            this._khachHangService = khachHangService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageCommand pageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var phuongtien = await _phuongtienData.GetAll(pageCommand.PageSize, pageCommand.PageIndex);
                if (phuongtien == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any vehicle"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = phuongtien
                });
            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Vehicles id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var phuongtien = await _phuongtienData.Get(id);
                if (phuongtien == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Vehicles not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = phuongtien
                });
            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PhuongTienModel phuongtien)
        {
    
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
               
                    var result = await _phuongtienData.Update(phuongtien);
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            success = true,
                            data = phuongtien
                        });
                    }
                    return NotFound(new
                    {
                        success = false,
                        error = " not found"
                    });
                
            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  CreatePhuongTienCommand command)
        {
            PhuongTienModel phuongTien = new PhuongTienModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var khachhang = this._khachHangService.GetKhachHang(command.CMND);
                if (khachhang != null)
                {
                    phuongTien.MA_KHACH_HANG = khachhang.MA_KHACH_HANG;
                    phuongTien.MA_LOAI_PHUONG_TIEN = command.MA_LOAI_PHUONG_TIEN;
                    phuongTien.HOAT_DONG = 1;
                    phuongTien.MAU_SON = command.MAU_SON;
                    phuongTien.SO_PHUONG_TIEN = command.SO_PHUONG_TIEN;
                    phuongTien.SO_MAY = command.SO_MAY;
                    phuongTien.NHAN_HIEU = command.NHAN_HIEU;
                    phuongTien.BIEN_SO_XE = command.BIEN_SO_XE;
                    phuongTien.DUNG_TICH = command.DUNG_TICH;
                    phuongTien.GHI_CHU = command.GHI_CHU;
                    phuongTien.NGAY_CAP_NHAT = DateTime.Now;
                    phuongTien.NGAY_DANG_KY = DateTime.Now;
                    phuongTien.NGAY_DAU_DANG_KY = DateTime.Now;
                    phuongTien.NGAY_TAO = DateTime.Now;
                    var result = await _phuongtienData.Create(phuongTien);
                    if (result==1)
                    {
                        return Ok(new
                        {
                            success = true,
                            data = phuongTien
                        });
                    }
                }
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });

            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PhuongTienModel>> Delete(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Vehicles id not found"
                });
            }
            try
            {
                var phuongtien = await _phuongtienData.Delete(id);
                if (phuongtien == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Vehicles not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = phuongtien
                });
            }
            catch (IOException e)
            {
                return NotFound(new
                {
                    success = false,
                    error = " not found"
                });
            }
        }
       

    }

}