using NUnit.Framework;
using QLGT_API.Repository;
using QLGT_API.Data;
using QLGT_API.Controllers;
using System.Collections.Generic;
using QLGT_API.Models;
using Moq;
using System.Linq;
using System;
using QLGT_API.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class LoiViPhamTests
    {
        LoiViPhamService offend_service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("LoiViPhamList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                context.LOI_VI_PHAM.Add(new QLGT_API.Model.LoiViPhamModel()
                {
                    MA_LOI_VI_PHAM = 1,
                    MA_NHOM_VI_PHAM = 1,
                    MA_LOAI_PHUONG_TIEN = 1,
                    TEN_LOI_VI_PHAM = "Vuot den do",
                    NOI_DUNG = "vuot den do",
                    MUC_PHAT_TOI_THIEU = 200000,
                    MUC_PHAT_TOI_DA = 300000,
                    DIEU_LUAT = "Dieu 3",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.LOI_VI_PHAM.Add(new QLGT_API.Model.LoiViPhamModel()
                {
                    MA_LOI_VI_PHAM = 2,
                    MA_NHOM_VI_PHAM = 1,
                    MA_LOAI_PHUONG_TIEN = 1,
                    TEN_LOI_VI_PHAM = "Qua toc do",
                    NOI_DUNG = "Qua toc do",
                    MUC_PHAT_TOI_THIEU = 200000,
                    MUC_PHAT_TOI_DA = 300000,
                    DIEU_LUAT = "Dieu 3",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.LOI_VI_PHAM.Add(new QLGT_API.Model.LoiViPhamModel()
                {
                    MA_LOI_VI_PHAM = 3,
                    MA_NHOM_VI_PHAM = 1,
                    MA_LOAI_PHUONG_TIEN = 1,
                    TEN_LOI_VI_PHAM = "Khong mu bao hiem",
                    NOI_DUNG = "Khong doi mu",
                    MUC_PHAT_TOI_THIEU = 200000,
                    MUC_PHAT_TOI_DA = 300000,
                    DIEU_LUAT = "Dieu 3",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase(2)]
        [TestCase(6)]
        public void GetListTest_ReturnList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("LoiViPhamList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                LoiViPhamRepository offend_repo = new LoiViPhamRepository(context);
                var result = offend_repo.GetList(1, context.LOI_VI_PHAM.Count(), m => m.HOAT_DONG == 1);
                Assert.AreEqual(result.Data.Count(), number);
            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetOffendIDTest_WithValidOffend_ReturnValidModel(int MaVP)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("LoiViPhamList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                LoiViPhamRepository offend_repo = new LoiViPhamRepository(context);
                offend_service = new LoiViPhamService(context);
                var result = offend_service.GetLoiViPham_id(MaVP);
                Assert.AreEqual(MaVP, result.MA_LOI_VI_PHAM);
            }
        }
        [Test]
        [TestCase("do")]
        [TestCase("toc do")]
        public void GetOffendNameTest_WithValidName_ReturnList(string TenLoiVP)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("LoiViPhamList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                LoiViPhamRepository offend_repo = new LoiViPhamRepository(context);
                offend_service = new LoiViPhamService(context);
                var result = offend_service.GetName(TenLoiVP);
                Assert.AreEqual(2, result.Count());
            }
        }
        [Test]
        [TestCase("dolkkkkkkkkkkkkkkkkkkkk")]
        [TestCase("toc doggggggggggggggggggggggggg")]
        public void GetOffendNameTest_WithInvalidName_ReturnZeroObject(string TenLoiVP)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("LoiViPhamList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                LoiViPhamRepository offend_repo = new LoiViPhamRepository(context);
                offend_service = new LoiViPhamService(context);
                var result = offend_service.GetName(TenLoiVP);
                Assert.AreEqual(0, result.Count());
            }
        }
        [Test]
        [TestCase("123441211")]
        [TestCase("123441213")]
        [TestCase("123441213")]
        public void AddTrafficOffendTest_ReturnOkObject(string CMND)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("LoiViPhamList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                LoiViPhamRepository offend_repo = new LoiViPhamRepository(context);
                offend_service = new LoiViPhamService(context);
                CreateLoiViPhamCommand command = new CreateLoiViPhamCommand();
                command.MA_LOI_VI_PHAM = 1;
                command.MA_NHOM_VI_PHAM = 1;
                command.MA_LOAI_PHUONG_TIEN = 2;
                command.TEN_LOI_VI_PHAM = "khong du tuoi";
                command.NOI_DUNG = "k du tuoi";
                command.MUC_PHAT_TOI_THIEU = 200000;
                command.MUC_PHAT_TOI_DA = 500000;
                command.DIEU_LUAT = "Dieu 3";
                command.HOAT_DONG = 1;
                LoiViPhamController offend_controller = new LoiViPhamController(offend_repo,offend_service);
                var result = offend_controller.Create(command) as OkObjectResult;
                Assert.AreEqual("{ success = True, data = QLGT_API.Model.LoiViPhamModel }", result.Value.ToString());
            }
        }
       
    }
}