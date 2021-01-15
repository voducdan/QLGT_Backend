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
    public class KhachHangTests
    {
        KhachHangService cus_service;

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void GetListTest_ReturnList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("KhachHangList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                /*context.KHACH_HANG.Add(new KhachHangModel()
                {
                    MA_KHACH_HANG = 1,
                    TEN_KHACH_HANG = "ABC",
                    EMAIL = "ABC@gmail.com",
                    DIA_CHI = "Quan 1",
                    SDT = "036547854",
                    TUOI = 11,
                    GIOI_TINH = "Nam",
                    CMND = "262626226",
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.Add(new KhachHangModel()
                {
                    MA_KHACH_HANG = 2,
                    TEN_KHACH_HANG = "ABCD",
                    EMAIL = "ABC@gmail.com",
                    DIA_CHI = "Quan 1",
                    SDT = "036547854",
                    TUOI = 11,
                    GIOI_TINH = "Nam",
                    CMND = "262626226",
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.Add(new KhachHangModel()
                {
                    MA_KHACH_HANG = 3,
                    TEN_KHACH_HANG = "ABCD",
                    EMAIL = "ABC@gmail.com",
                    DIA_CHI = "Quan 1",
                    SDT = "036547854",
                    TUOI = 11,
                    GIOI_TINH = "Nam",
                    CMND = "262626226",
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                //context.SaveChanges();*/
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var result = cus_repo.GetList(1, context.KHACH_HANG.Count(), m => m.HOAT_DONG == 1);
                Assert.AreEqual(result.Data.Count(), number);
            }
           // string logPath = @"C:\Tests\Logs\";
           // Driver.Log.Save(logPath + "log.mht", Log.Format.Mht);
        }
        [Test]
        [TestCase(1)]
        public void GetCustomerTest_ReturnList(int MaKH)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("KhachHangList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var result = cus_repo.Get(m => m.MA_KHACH_HANG == MaKH);
                Assert.AreEqual(1, result.MA_KHACH_HANG);
            }
        }
        [Test]
        [TestCase("123441211")]
        [TestCase("123441213")]
        [TestCase("123441213")]
        public void AddCustomerTest_ReturnOkObject(string CMND)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("KhachHangList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var test_cus = new KhachHangModel()
                {
                    MA_KHACH_HANG = 5,
                    TEN_KHACH_HANG = "ABCD",
                    EMAIL = "ABC@gmail.com",
                    DIA_CHI = "Quan 1",
                    SDT = "036547854",
                    TUOI = 11,
                    GIOI_TINH = "Nam",
                    CMND = CMND,
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                };
                cus_service = new KhachHangService(context);
                KhachHangController cus_controller = new KhachHangController(cus_repo, cus_service);
                CreateKhachHangCommand command = new CreateKhachHangCommand();
                command.TEN_KHACH_HANG = test_cus.TEN_KHACH_HANG;
                command.EMAIL = test_cus.EMAIL;
                command.DIA_CHI = test_cus.DIA_CHI;
                command.SDT = test_cus.SDT;
                command.TUOI = test_cus.TUOI;
                command.GIOI_TINH = test_cus.GIOI_TINH;
                command.CMND = test_cus.CMND;
                command.NGAY_TAO = test_cus.NGAY_TAO;
                command.QUOC_TICH = test_cus.QUOC_TICH;
                command.NGAY_CAP_NHAT = test_cus.NGAY_CAP_NHAT;
                command.HOAT_DONG = test_cus.HOAT_DONG;
                var result = cus_controller.Create(command) as OkObjectResult;
                Assert.AreEqual("{ success = True }", result.Value.ToString());
            }
        }
        [Test]
        [TestCase(2)]
        public void UpdateCustomerTest_ReturnRepo(int MaKH)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("KhachHangList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var test_cus = new KhachHangModel()
                {
                    MA_KHACH_HANG = MaKH,
                    TEN_KHACH_HANG = "ABCD",
                    EMAIL = "ABC@gmail.com",
                    DIA_CHI = "Quan 1",
                    SDT = "036547854",
                    TUOI = 11,
                    GIOI_TINH = "Nam",
                    CMND = "45623",
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                };
                cus_service = new KhachHangService(context);
                KhachHangController cus_controller = new KhachHangController(cus_repo, cus_service);
                CreateKhachHangCommand command = new CreateKhachHangCommand();
                command.TEN_KHACH_HANG = test_cus.TEN_KHACH_HANG;
                command.EMAIL = test_cus.EMAIL;
                command.DIA_CHI = test_cus.DIA_CHI;
                command.SDT = test_cus.SDT;
                command.TUOI = test_cus.TUOI;
                command.GIOI_TINH = test_cus.GIOI_TINH;
                command.CMND = test_cus.CMND;
                command.NGAY_TAO = test_cus.NGAY_TAO;
                command.QUOC_TICH = test_cus.QUOC_TICH;
                command.NGAY_CAP_NHAT = test_cus.NGAY_CAP_NHAT;
                command.HOAT_DONG = test_cus.HOAT_DONG;
                var result = cus_controller.Update(test_cus);
                Assert.AreEqual(200, result.code);
            }
        }
    }
}