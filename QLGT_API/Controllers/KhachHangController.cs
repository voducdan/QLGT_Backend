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

namespace QLGT_API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangData _khachhangData;

        public KhachHangController(IKhachHangData khachHangData)
        {
            this._khachhangData = khachHangData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var khachhang = await this._khachhangData.GetAll();
                if (khachhang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any customer"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = khachhang
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Customer id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var khachhang = await this._khachhangData.Get(id);
                if (khachhang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Customer not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = khachhang
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]KhachHangModel khachhang)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var maKhachHang = await _khachhangData.Create(khachhang);
                if (maKhachHang != "")
                {
                    return Ok(new
                    {
                        success = true,
                        MA_KHACH_HANG = maKhachHang
                    });
                }
                if (maKhachHang == "EmailErr")
                {
                    return BadRequest(new
                    {
                        success = false,
                        error = "Email is not valid"
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]KhachHangModel khachhang)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _khachhangData.Update(khachhang);
                if (result == 1)
                {
                    return Ok(new
                    {
                        success = true,
                        data = khachhang
                    });
                }
                return NotFound(new
                {
                    success = false,
                    error = "Customer not found"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Customer id not found"
                });
            }
            try
            {
                var khachhang = await _khachhangData.Delete(id);
                if (khachhang == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Customer not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = khachhang
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
