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
    [Route("api/vehicles")]
    public class PhuongTienController : ControllerBase
    {
        private readonly IPhuongTienData _phuongTienData;

        public PhuongTienController(IPhuongTienData phuongTienData)
        {
            this._phuongTienData = phuongTienData;
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
                var phuongtien = await this._phuongTienData.GetAll();
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
                    error = "Vehicle id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var phuongTien = await this._phuongTienData.Get(id);
                if (phuongTien == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Vehicle not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = phuongTien
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
                var result = await _phuongTienData.Update(phuongtien);
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
                    error = "Vehicle not found"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}