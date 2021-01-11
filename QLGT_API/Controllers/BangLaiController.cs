using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLGT_API.Data;
using QLGT_API.Models;

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

        // GET: api/BangLai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang_BangLaiModel>>> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var banglai = await this._banglaiData.GetAll();
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


        // GET: api/BangLai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang_BangLaiModel>> Get(string id)
        {
            if (id == null)
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
                var banglai = await this._banglaiData.Get(id);
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
            catch( IOException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //// PUT: api/BangLai/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBangLaiModel(string id, BangLaiModel bangLaiModel)
        //{
        //    if (id != bangLaiModel.MA_BANG_LAI)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bangLaiModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BangLaiModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/BangLai
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<BangLaiModel>> PostBangLaiModel(BangLaiModel bangLaiModel)
        //{
        //    _context.BANG_LAI.Add(bangLaiModel);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (BangLaiModelExists(bangLaiModel.MA_BANG_LAI))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetBangLaiModel", new { id = bangLaiModel.MA_BANG_LAI }, bangLaiModel);
        //}

        // DELETE: api/lisence/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<KhachHang_BangLaiModel>> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest(new
        //        {
        //            success = false,
        //            error = "Lesence id not found"
        //        });
        //    }
        //    try
        //    {
        //        var banglai = await _banglaiData.Delete(id);
        //        if (banglai == null)
        //        {
        //            return NotFound(new
        //            {
        //                success = false,
        //                error = "Lisence not found"
        //            });
        //        }
        //        return Ok(new
        //        {
        //            success = true,
        //            data = banglai
        //        });
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //private bool BangLaiModelExists(string id)
        //{
        //    return _banglaiData.BANG_LAI.Any(e => e.MA_BANG_LAI == id);
        //}
    }
}
