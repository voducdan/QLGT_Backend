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
    class BienBanTests
    {
        LoiViPhamService offend_service;
        BienBangService doc_service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BienBanList")
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
                context.DANH_SACH_LOI_VI_PHAM.Add(new QLGT_API.Model.DanhSachLoiViPhamModel()
                {
                    MA_BIEN_BANG = 1,
                    MA_LOI_VI_PHAM = 1,
                    GIA_PHAT = 200000
                });
                context.BIEN_BANG.Add(new QLGT_API.Model.BienBangModel()
                {
                    MA_BIEN_BANG = 1,
                    MA_KHACH_HANG = 1,
                    MA_SO_CONG_AN = 1,


                    NGAY_LAP = System.Convert.ToDateTime("12/12/2020"),
                    NOI_LAP = "TPHCM",

                    DON_VI_LAP_BIEN_BANG = "CA TPHCM",

                    NGAY_YC_NOP_PHAT = System.Convert.ToDateTime("12/12/2020"),

                    DON_VI_YC_NOP_PHAT = "CA TPHCM",
                    TONG_TIEN = 300000,

                    TRANG_THAI = "ok",
                    GHI_CHU = "ok",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),

                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),

                    HOAT_DONG = 1,
                    Y_KIEN_BO_XUNG = "Khong"
                });
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
                context.CONG_AN.Add(new QLGT_API.Model.CongAnModel()
                {
                    MA_SO_CONG_AN = 1,
                    TEN_CONG_AN = "Vu Van Dat",
                    CAP_BAC__CHUC_VU = "Thieu Tuong",
                    NGAY_TAO = System.Convert.ToDateTime("12/12/2020"),
                    NGAY_CAP_NHAT = System.Convert.ToDateTime("12/12/2020"),
                    HOAT_DONG = 1
                });
                context.SaveChangesAsync();
            }
        }
        [Test]
        [TestCase(1)]
        public void GetDocumentTest_WithValidID_ReturnValidBienBanModel(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BienBanList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                doc_service = new BienBangService(context);
                var result = doc_service.GetBienBang_id(number);
                Assert.AreEqual(number, result.MA_BIEN_BANG);
            }
        }
        [Test]
        [TestCase(1)]
        public void GetDocumentListTest_WithValidID_ReturnValidDocumentList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BienBanList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                doc_service = new BienBangService(context);
                var result = doc_service.GetDanhSachLoiViPham(number);
                Assert.AreEqual(number, result.FirstOrDefault(m => m.MA_BIEN_BANG == number).MA_BIEN_BANG);
                //Assert.IsTrue(result.FirstOrDefault() == null);
            }

        }
        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void GetDocumentListTest_WithInvalidID_ReturnNullDocumentList(int number)
        {
            var options = new DbContextOptionsBuilder<QLGTDBContext>()
            .UseInMemoryDatabase("BienBanList")
            .Options;
            using (var context = new QLGTDBContext(options))
            {
                doc_service = new BienBangService(context);
                var result = doc_service.GetDanhSachLoiViPham(number);
                //Assert.AreEqual(number, result.FirstOrDefault(m => m.MA_BIEN_BANG == number).MA_BIEN_BANG);
                Assert.IsTrue(result.FirstOrDefault() == null);
            }

        }
    }
}