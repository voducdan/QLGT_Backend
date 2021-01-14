using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLGT_API.Commands;
using QLGT_API.Data;
using QLGT_API.Models;
using QLGT_API.Repository;

namespace QLGT_API.Controllers
{
    [Route("api/lisence")]
    [ApiController]
    public class BangLaiController : ControllerBase
    {
        private readonly IBangLaiData _banglaiData;
        private readonly KhachHangService khachhangService;
        public BangLaiController(IBangLaiData bangLaiData, KhachHangService khachhangService)
        {
            this._banglaiData = bangLaiData;
            this.khachhangService = khachhangService;
        }

        // GET: api/lisence
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageCommand pageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var banglai = await _banglaiData.GetAll(pageCommand.PageSize, pageCommand.PageIndex);
                if (banglai == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any lisence"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = banglai
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        //GET: api/lisence/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Lisence id not found"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var banglai = await _banglaiData.Get(id);
                if (banglai == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Lisence not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = banglai
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("lisencetype")]
        public async Task<IActionResult> GetLisenceType()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var loaibanglai = await _banglaiData.GetLisenceType();
                if (loaibanglai == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Could not find any lisence type"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = loaibanglai
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/lisence
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BangLaiModel bl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _banglaiData.Update(bl);
                if (result == 1)
                {
                    return Ok(new
                    {
                        success = true,
                        data = bl
                    });
                }
                return NotFound(new
                {
                    success = false,
                    error = "Lisence not found"
                });
            }
            catch (IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/BangLai
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBangLaiCommand cbl)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                BangLaiModel blm = new BangLaiModel();
                var kh = khachhangService.GetKhachHang(cbl.CMND);
                if (kh != null)
                {
                    blm.MA_LOAI_BANG_LAI = cbl.MA_LOAI_BANG_LAI;
                    blm.NOI_CAP_NCK = cbl.NOI_CAP_NCK;
                    blm.THOI_HAN_SU_DUNG = cbl.THOI_HAN_SU_DUNG;
                    blm.NGAY_CAP_NCK = DateTime.Now;
                    blm.NGAY_CAP_NHAT = DateTime.Now;
                    blm.NGAY_TAO = DateTime.Now;
                    blm.HOAT_DONG = 1;
                    blm.MA_KHACH_HANG = kh.MA_KHACH_HANG;
                    blm.MA_LOAI_BANG_LAI = cbl.MA_LOAI_BANG_LAI;
                    var result = await _banglaiData.Create(blm);
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            success = true,
                            data = blm
                        });
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //DELETE: api/lisence/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BangLaiModel>> Delete(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest(new
                {
                    success = false,
                    error = "Lesence id not found"
                });
            }
            try
            {
                var banglai = await _banglaiData.Delete(id);
                if (banglai == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        error = "Lisence not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    data = banglai
                });
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //private bool BangLaiModelExists(string id)
        //{
        //    return _banglaiData.BANG_LAI.Any(e => e.MA_BANG_LAI == id);
        //}
    }
}
