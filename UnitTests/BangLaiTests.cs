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
    public class BangLaiTests
    {
        BangLaiService lisense_service;
        KhachHangService customer_service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BangLaiList")
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
                    CMND = "12344",
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
                    CMND = "12345",
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
                    CMND = "12346",
                    QUOC_TICH = "VN",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.Add(new BangLaiModel()
                {
                    MA_BANG_LAI = 1,
                    MA_LOAI_BANG_LAI = 2,
                    MA_KHACH_HANG = 2,
                    NGAY_CAP_NCK = System.Convert.ToDateTime("12/12/2020"),
                    NOI_CAP_NCK = "TPHCM",
                    THOI_HAN_SU_DUNG = 1,
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.Add(new KhachHang_BangLaiModel()
                {
                    MA_BANG_LAI = 1,
                    MA_LOAI_BANG_LAI = 2,
                    TEN_LOAI_BANG_LAI = "A2",
                    MA_KHACH_HANG = 2,
                    TEN_KHACH_HANG = "DAT",
                    NGAY_CAP_NCK = System.Convert.ToDateTime("12/12/2020"),
                    NOI_CAP_NCK = "TPHCM",
                    THOI_HAN_SU_DUNG = 1,
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1,
                    CMND = "12345"
                });
                context.SaveChangesAsync();
            } 
        }
        
        [Test]
        [TestCase("12344",2)]
        [TestCase("12345",3)]
        [TestCase("12346",4)]
        [TestCase("12346",5)]
        public void AddLisenseTest_ReturnOkObject(string CMND, int count)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("BangLaiList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                BangLaiRepository lisense_repo = new BangLaiRepository(context);
                var test_lisense = new CreateBangLaiCommand()
                {
                    CMND = CMND,
                    MA_LOAI_BANG_LAI = 2,
                    NOI_CAP_NCK = "TPHCM",
                    THOI_HAN_SU_DUNG = 3
                };
                lisense_service = new BangLaiService(context);
                customer_service = new KhachHangService(context);
                SqlBangLaiData sqlBangLai = new SqlBangLaiData(context);
                BangLaiController lisense_controller = new BangLaiController(sqlBangLai,customer_service);
                CreateBangLaiCommand command = new CreateBangLaiCommand();
                command.CMND= test_lisense.CMND;
                command.MA_LOAI_BANG_LAI= test_lisense.MA_LOAI_BANG_LAI;
                command.NOI_CAP_NCK = test_lisense.NOI_CAP_NCK;
                command.THOI_HAN_SU_DUNG = test_lisense.THOI_HAN_SU_DUNG;

                var result = lisense_controller.Create(command) as IActionResult;
                
                Assert.AreEqual(context.BANG_LAI.Count(), count);
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetListTest_ReturnList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BangLaiList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                BangLaiRepository lisense_repo = new BangLaiRepository(context);
                var result = lisense_repo.GetList(1, context.BANG_LAI.Count(), m => m.HOAT_DONG == 1);
                Assert.AreEqual(result.Data.Count(), number);
            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(0)]
        public void GetLisenseTest_ReturnList(int MaHD)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("BangLaiList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                BangLaiRepository lisense_repo = new BangLaiRepository(context);
                var result = lisense_repo.Get(m => m.HOAT_DONG == MaHD);
                Assert.AreEqual(1, result.MA_BANG_LAI);
            }
        }

    }
}