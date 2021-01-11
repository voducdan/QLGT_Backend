using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLGT_API.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANG_LAI",
                columns: table => new
                {
                    MA_BANG_LAI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MA_LOAI_BANG_LAI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MA_KHACH_HANG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_CAP_NCK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOI_CAP_NCK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    THOI_HAN_SU_DUNG = table.Column<int>(type: "int", nullable: false),
                    NGAY_TAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAY_CAP_NHAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HOAT_DONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANG_LAI", x => x.MA_BANG_LAI);
                });

            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    MA_KHACH_HANG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TEN_KHACH_HANG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIA_CHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TUOI = table.Column<int>(type: "int", nullable: false),
                    GIOI_TINH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUOC_TICH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_TAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAY_CAP_NHAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HOAT_DONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACH_HANG", x => x.MA_KHACH_HANG);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_BANG_LAI",
                columns: table => new
                {
                    MA_LOAI_BANG_LAI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TEN_LOAI_BANG_LAI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MO_TA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_BANG_LAI", x => x.MA_LOAI_BANG_LAI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANG_LAI");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "LOAI_BANG_LAI");
        }
    }
}
