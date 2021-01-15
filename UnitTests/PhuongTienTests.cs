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
    class PhuongTienTests
    {
        PhuongTienService vehicle_service;
        KhachHangService customer_service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("PhuongTienList")
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
                context.Add(new PhuongTienModel()
                {
                    MA_PHUONG_TIEN = 1,
                    MA_KHACH_HANG = 1,
                    MA_LOAI_PHUONG_TIEN = 2,
                    SO_PHUONG_TIEN = "a",
                    SO_MAY = "A",
                    NGAY_DANG_KY = System.Convert.ToDateTime("12/12/2020"),
                    MAU_SON = "DD",
                    NHAN_HIEU = "HONDA",
                    DUNG_TICH = 150,
                    BIEN_SO_XE = "ADAD",
                    NGAY_DAU_DANG_KY = System.Convert.ToDateTime("12/12/2020"),
                    GHI_CHU = "DDDA",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase("12344", 2)]
        [TestCase("12345", 3)]
        [TestCase("12346", 4)]
        [TestCase("12346", 5)]
        public void AddVehicleTest_ReturnOkObject(string CMND, int count)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("PhuongTienList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                PhuongTienRepository vehicle_repo = new PhuongTienRepository(context);
                var test_lisense = new CreatePhuongTienCommand()
                {
                    SO_PHUONG_TIEN = "ABC",
                    SO_MAY = "ABC",
                    MAU_SON = "RED",
                    NHAN_HIEU = "HONDA",
                    DUNG_TICH = 150,
                    BIEN_SO_XE = "49AA",
                    GHI_CHU = "aaa",
                    CMND = CMND,
                    MA_LOAI_PHUONG_TIEN = 2
                };
                vehicle_service = new PhuongTienService(context);
                customer_service = new KhachHangService(context);
                SqlPhuongTienData sqlPhuongTien = new SqlPhuongTienData(context);
                PhuongTienController vehicle_controller = new PhuongTienController(sqlPhuongTien, customer_service);
                CreatePhuongTienCommand command = new CreatePhuongTienCommand();
                command.SO_PHUONG_TIEN = test_lisense.SO_PHUONG_TIEN;
                command.SO_MAY = test_lisense.SO_MAY;
                command.MAU_SON = test_lisense.MAU_SON;
                command.NHAN_HIEU = test_lisense.NHAN_HIEU;
                command.DUNG_TICH = test_lisense.DUNG_TICH;
                command.BIEN_SO_XE = test_lisense.BIEN_SO_XE;
                command.GHI_CHU = test_lisense.GHI_CHU;
                command.CMND = test_lisense.CMND;
                command.MA_LOAI_PHUONG_TIEN = test_lisense.MA_LOAI_PHUONG_TIEN;
                var result = vehicle_controller.Create(command) as IActionResult;
                Assert.AreEqual(context.PHUONG_TIEN.Count(), count);
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase(5)]
        [TestCase(2)]
        public void GetListTest_ReturnList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("PhuongTienList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                PhuongTienRepository vehicle_repo = new PhuongTienRepository(context);
                var result = vehicle_repo.GetList(1, context.PHUONG_TIEN.Count(), m => m.HOAT_DONG == 1);
                Assert.AreEqual(result.Data.Count(), number);
            }
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetLisenseTest_ReturnList(int MaPT)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
                .UseInMemoryDatabase("PhuongTienList")
                .Options;
            using (var context = new QLGTDBContext(options))
            {
                PhuongTienRepository vehicle_repo = new PhuongTienRepository(context);
                var result = vehicle_repo.Get(m => m.MA_PHUONG_TIEN == MaPT);
                Assert.AreEqual(MaPT, result.MA_PHUONG_TIEN);
            }
        }

    }
}
