﻿using System;
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
using QLGT_API.Model;
using QLGT_API.Views;

namespace QLGT_API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class KhachHangController : ControllerBase
    {
        private KhachHangRepository khachHangRepository;
        private KhachHangService khachHangService;

        public KhachHangController(KhachHangRepository khachHangRepository, KhachHangService khachHangService)
        {
            this.khachHangRepository = khachHangRepository;
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
                ListView<KhachHangModel> khachhang = this.khachHangRepository.GetList(pageCommand.PageIndex, pageCommand.PageSize, m => m.HOAT_DONG == 1);
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
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = "Fail"
                });
            }
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    if (id.ToString() == null)
        //    {
        //        return BadRequest(new
        //        {
        //            success = false,
        //            error = "Customer id not found"
        //        });
        //    }
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var khachhang =  this.khachHangRepository.Get(w=>w.MA_KHACH_HANG == id);
        //        if (khachhang == null)
        //        {
        //            return NotFound(new
        //            {
        //                success = false,
        //                error = "Customer not found"
        //            });
        //        }
        //        return Ok(new
        //        {
        //            success = true,
        //            data = khachhang
        //        });
        //    }
        //    catch
        //    {
        //        return NotFound(new
        //        {
        //            success = false,
        //            error = "Fail"
        //        });
        //    }
        //}

        [HttpGet("{cmnd}")]
        public IActionResult Get_cmnd(string cmnd)
        {
            Console.WriteLine(cmnd);
            if (cmnd.ToString() == null)
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
                KhachHangModel data = new KhachHangModel();
                var khachhang = this.khachHangRepository.Get(w => w.CMND == cmnd);
                
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
                    data = new { data = khachhang},
                    success = true
                    
                });
            }
            catch
            {
                return NotFound(new
                {
                    success = false,
                    error = "Fail"
                });
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateKhachHangCommand command)
        {
            KhachHangModel kh = new KhachHangModel();
            kh.TEN_KHACH_HANG = command.TEN_KHACH_HANG;
            kh.EMAIL = command.EMAIL;
            kh.DIA_CHI = command.DIA_CHI;
            kh.SDT = command.SDT;
            kh.TUOI = command.TUOI;
            kh.GIOI_TINH = command.GIOI_TINH;
            kh.CMND = command.CMND;
            kh.NGAY_TAO = command.NGAY_TAO;
            kh.QUOC_TICH = command.QUOC_TICH;
            kh.NGAY_CAP_NHAT = command.NGAY_CAP_NHAT;
            kh.HOAT_DONG = command.HOAT_DONG;
                       
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var KhachHang = this.khachHangService.GetKhachHang(command.CMND);
                if (KhachHang != null)
                {
                    return Ok(new
                    {
                        success = false,
                        error = "CMND is exist"
                    });
                }

                if (KhachHang == null)
                {
                    this.khachHangRepository.Create(kh);                    
                }
                return Ok(new
                {
                    success = true

                });

            }
            catch 
            {
                return NotFound(new
                {
                    success = false,
                    error = "Fail"
                });
            }
        }

        [HttpPut]
        public Repon Update([FromBody] KhachHangModel khachhang)
        {
            Repon repo = new Repon();
            try
            {              

                var kh = this.khachHangService.GetKhachHang_id(khachhang.MA_KHACH_HANG);                

                if (kh == null)
                {
                    repo.code = 400;
                    repo.err = "Ma KH is not exists";
                    
                }                    
                if(kh != null)
                {
                    //kh = khachhang;
                    kh.DIA_CHI = khachhang.DIA_CHI;
                    kh.EMAIL = khachhang.EMAIL;
                    kh.SDT = khachhang.SDT;
                    kh.TEN_KHACH_HANG = khachhang.TEN_KHACH_HANG;
                    kh.HOAT_DONG = khachhang.HOAT_DONG;
                    kh.CMND = khachhang.CMND;
                    khachHangRepository.Update(kh);

                    repo.code = 200;
                    repo.err = "Success";
                }               
            }
            catch
            {
                repo.code = 400;
                repo.err = "Fail";
            }
            return repo;
        }
    }
}
