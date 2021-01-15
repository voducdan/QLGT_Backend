using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Models;
using Microsoft.EntityFrameworkCore;
using QLGT_API.Model;

namespace QLGT_API.Data
{
    public class QLGTDBContext : DbContext
    {
        public QLGTDBContext(DbContextOptions<QLGTDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DanhSachLoiViPhamModel>().HasKey(table => new
            {
                table.MA_BIEN_BANG,
                table.MA_LOI_VI_PHAM
            });
        }
        public DbSet<BangLaiModel> BANG_LAI { get; set; }
        public DbSet<KhachHangModel> KHACH_HANG { get; set; }
        public DbSet<LoaiBangLaiModel> LOAI_BANG_LAI { get; set; }

        public DbSet<LoaiPhuongTienModel> LOAI_PHUONG_TIEN { get; set; }
        public DbSet<PhuongTienModel> PHUONG_TIEN { get; set; }
        public DbSet<PhuongTienViewModel> PHUONG_TIEN_VIEW { get; set; }          

        public DbSet<KhachHang_BangLaiModel> BANGLAI_KHACHHANG { get; set; }
   
        public DbSet<BienBangModel> BIEN_BANG { get; set; }
        public DbSet<UserModel> ACCOUNT { get; set; }
        public DbSet<DanhSachLoiViPhamModel> DANH_SACH_LOI_VI_PHAM { get; set; }
        public DbSet<LoiViPhamModel> LOI_VI_PHAM { get; set; }
        public DbSet<CongAnModel> CONG_AN { get; set; }
    }
}
