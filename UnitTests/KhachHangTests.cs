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
        public void GetListTest_ReturnList()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("KhachHangList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                context.KHACH_HANG.Add(new KhachHangModel()
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
                context.SaveChanges();
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                PageCommand pageCommand = new PageCommand(1, 1);
                var result = cus_repo.GetList(1, 3, m => m.HOAT_DONG == 1);
                Assert.AreEqual(result.Count, 3);
            }
        }
        [Test]
        public void GetCustomerTest_ReturnList()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("KhachHangList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var result = cus_repo.Get(1);
                Assert.AreEqual(1, result.MA_KHACH_HANG);
            }
        }
        [Test]
        public void AddCustomerTest_ReturnBoolean()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("KhachHangList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                KhachHangRepository cus_repo = new KhachHangRepository(context);
                var test_cus = new KhachHangModel()
                {
                    MA_KHACH_HANG = 4,
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
                };
                cus_repo.Create(test_cus);
                Assert.AreEqual(4, cus_repo.Get(4).MA_KHACH_HANG);
            }
        }
    }
}