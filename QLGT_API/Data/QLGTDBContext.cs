﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace QLGT_API.Data
{
    public class QLGTDBContext : DbContext
    {
        public QLGTDBContext(DbContextOptions<QLGTDBContext> options) : base(options)
        {

        }
        public DbSet<BangLaiModel> BANG_LAI { get; set; }
        public DbSet<KhachHangModel> KHACH_HANG { get; set; }
        public DbSet<LoaiBangLaiModel> LOAI_BANG_LAI { get; set; }
        public DbSet<LoaiPhuongTienModel> LOAI_PHUONG_TIEN { get; set; }
        public DbSet<PhuongTienModel> PHUONG_TIEN { get; set; }
    }
}
