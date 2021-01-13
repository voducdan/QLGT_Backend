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
        public BangLaiController(IBangLaiData bangLaiData)
        {
            this._banglaiData = bangLaiData;
        }

        // GET: api/lisence
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] PageCommand pageCommand)
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
        public async Task<IActionResult> Create([FromBody] BangLaiModel bl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var maKhachHang = await _banglaiData.Create(bl);
                if (bl.MA_BANG_LAI.ToString() != null)
                {
                    return Ok(new
                    {
                        success = true,
                        data = bl
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
