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
        private PhuongTienRepository phuongTienRepository;
      
        public PhuongTienController(PhuongTienRepository phuongTienRepository)
        {
            this.phuongTienRepository = phuongTienRepository;
        }

        [HttpGet]
        public IActionResult GetListPhuongTien([FromBody] PageCommand pageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var phuongtien = this.phuongTienRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, ww => ww.HOAT_DONG == 0);
               
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
        IActionResult Get(int id)
        {
            if (id.ToString() == null)
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
                var phuongTien = this.phuongTienRepository.Get(w => w.MA_PHUONG_TIEN == id);
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
        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] PhuongTienModel phuongtien)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result =  phuongTienRepository.Update(phuongtien);
        //        if (result == 1)
        //        {
        //            return Ok(new
        //            {
        //                success = true,
        //                data = phuongtien
        //            });
        //        }
        //        return NotFound(new
        //        {
        //            success = false,
        //            error = "Vehicle not found"
        //        });
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

    } 

}