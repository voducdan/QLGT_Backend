/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     12/13/2020 6:19:33 PM                        */
/*==============================================================*/
use master
if DB_ID ('QLGT') is not null
	drop database QLGT
go
create database QLGT
go 
use QLGT
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BANG_LAI') and o.name = 'FK_CO_BANG_LAI')
alter table BANG_LAI
   drop constraint FK_CO_BANG_LAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BANG_LAI') and o.name = 'FK_THUOC_LOAI_BANG_LAI')
alter table BANG_LAI
   drop constraint FK_THUOC_LOAI_BANG_LAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BIEN_BANG') and o.name = 'FK_KHACH_HANG_BI_PHAT')
alter table BIEN_BANG
   drop constraint FK_KHACH_HANG_BI_PHAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BIEN_BANG') and o.name = 'FK_DUOC_LAP')
alter table BIEN_BANG
   drop constraint FK_DUOC_LAP

go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DANH_SACH_LOI_VI_PHAM') and o.name = 'FK_PHAM_LOI')
alter table DANH_SACH_LOI_VI_PHAM
   drop constraint FK_PHAM_LOI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DANH_SACH_LOI_VI_PHAM') and o.name = 'FK_THUOC_BIEN_BANG')
alter table DANH_SACH_LOI_VI_PHAM
   drop constraint FK_THUOC_BIEN_BANG

go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOI_VI_PHAM') and o.name = 'FK_LOI_VI_PHAM_CUA_LOAI_PHUONG_TIEN')
alter table LOI_VI_PHAM
   drop constraint FK_LOI_VI_PHAM_CUA_LOAI_PHUONG_TIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOI_VI_PHAM') and o.name = 'FK_THUOC_NHOM_LVP')
alter table LOI_VI_PHAM
   drop constraint FK_THUOC_NHOM_LVP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEU_NOP_PHAT') and o.name = 'FK_GIAO_DICH')
alter table PHIEU_NOP_PHAT
   drop constraint FK_GIAO_DICH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHUONG_TIEN') and o.name = 'FK_KHACH_HANG_CO_PHUONG_TIEN')
alter table PHUONG_TIEN
   drop constraint FK_KHACH_HANG_CO_PHUONG_TIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHUONG_TIEN') and o.name = 'FK_THUOC_LOAI_PHUONG_TIEN')
alter table PHUONG_TIEN
   drop constraint FK_THUOC_LOAI_PHUONG_TIEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BANG_LAI')
            and   type = 'U')
   drop table BANG_LAI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BIEN_BANG')
            and   type = 'U')
   drop table BIEN_BANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CONG_AN')
            and   type = 'U')
   drop table CONG_AN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DANH_SACH_LOI_VI_PHAM')
            and   type = 'U')
   drop table DANH_SACH_LOI_VI_PHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACH_HANG')
            and   type = 'U')
   drop table KHACH_HANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAI_BANG_LAI')
            and   type = 'U')
   drop table LOAI_BANG_LAI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAI_PHUONG_TIEN')
            and   type = 'U')
   drop table LOAI_PHUONG_TIEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOI_VI_PHAM')
            and   type = 'U')
   drop table LOI_VI_PHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHOM_LOI_VI_PHAM')
            and   type = 'U')
   drop table NHOM_LOI_VI_PHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHIEU_NOP_PHAT')
            and   type = 'U')
   drop table PHIEU_NOP_PHAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHUONG_TIEN')
            and   type = 'U')
   drop table PHUONG_TIEN

go
/*==============================================================*/
/* Table: ACCOUNT                                              */
/*==============================================================*/
create table  ACCOUNT(
	ID_ACCOUNT INT IDENTITY(1,1),
	CMND char(12) not null,
	PASS_WORD char(20) not null,
	IS_ADMIN int,
	constraint PK_ACCOUNT primary key nonclustered (ID_ACCOUNT)
)
go

/*==============================================================*/
/* Table: BANG_LAI                                              */
/*==============================================================*/
create table BANG_LAI (
   MA_BANG_LAI          INT IDENTITY(1,1),
   MA_LOAI_BANG_LAI     int              null,
   MA_KHACH_HANG        int             null,
   NGAY_CAP_NCK         datetime             null,
   NOI_CAP_NCK          nvarchar(30)          null,
   THOI_HAN_SU_DUNG     int                  null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_BANG_LAI primary key nonclustered (MA_BANG_LAI)
)
go

/*==============================================================*/
/* Table: BIEN_BANG                                             */
/*==============================================================*/
create table BIEN_BANG (
   MA_BIEN_BANG         INT IDENTITY(1,1),
   MA_KHACH_HANG        int             null,
   MA_SO_CONG_AN        int             null,
   NGAY_LAP             datetime             null,
   NOI_LAP              nvarchar(30)          null,
   DON_VI_LAP_BIEN_BANG nvarchar(100)         null,
   NGAY_YC_NOP_PHAT		datetime			 null,
   DON_VI_YC_NOP_PHAT	nvarchar(100)		 null,
   TONG_TIEN            float              null,
   TRANG_THAI           nvarchar(30)          null,
   GHI_CHU              nvarchar(max)                 null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   Y_KIEN_BO_XUNG       nvarchar(max)                 null,
   constraint PK_BIEN_BANG primary key nonclustered (MA_BIEN_BANG)
)
go


/*==============================================================*/
/* Table: CONG_AN                                               */
/*==============================================================*/
create table CONG_AN (
   MA_SO_CONG_AN        INT IDENTITY(1,1),
   TEN_CONG_AN          nvarchar(50)          null,
   CAP_BAC__CHUC_VU     nvarchar(30)          null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_CONG_AN primary key nonclustered (MA_SO_CONG_AN)
)

go

/*==============================================================*/
/* Table: DANH_SACH_LOI_VI_PHAM                                 */
/*==============================================================*/
create table DANH_SACH_LOI_VI_PHAM (
   MA_BIEN_BANG         int             not null,
   MA_LOI_VI_PHAM       int              not null,
   GIA_PHAT             float              null,
   constraint PK_DANH_SACH_LOI_VI_PHAM primary key nonclustered (MA_BIEN_BANG, MA_LOI_VI_PHAM)
)

go

/*==============================================================*/
/* Table: KHACH_HANG                                            */
/*==============================================================*/
create table KHACH_HANG (
   MA_KHACH_HANG        INT IDENTITY(1,1),
   TEN_KHACH_HANG       nvarchar(50)          null,
   EMAIL                nvarchar(40)             null,
   DIA_CHI              nvarchar(max)         null,
   SDT                  char(10)             null,
   TUOI                 int                  null,
   GIOI_TINH            nvarchar(3)           null,
   CMND                 char(12)             null,
   QUOC_TICH            nvarchar(20)          null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_KHACH_HANG primary key nonclustered (MA_KHACH_HANG)
)
go

/*==============================================================*/
/* Table: LOAI_BANG_LAI                                         */
/*==============================================================*/
create table LOAI_BANG_LAI (
   MA_LOAI_BANG_LAI     INT IDENTITY(1,1),
   TEN_LOAI_BANG_LAI    nvarchar(30)          null,
   MO_TA                nvarchar(max)        null,
   constraint PK_LOAI_BANG_LAI primary key nonclustered (MA_LOAI_BANG_LAI)
)
go

/*==============================================================*/
/* Table: LOAI_PHUONG_TIEN                                      */
/*==============================================================*/
create table LOAI_PHUONG_TIEN (
   MA_LOAI_PHUONG_TIEN  INT IDENTITY(1,1),
   TEN_LOAI_PHUONG_TIEN nvarchar(20)          null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                 null,
   constraint PK_LOAI_PHUONG_TIEN primary key nonclustered (MA_LOAI_PHUONG_TIEN)
)
go

/*==============================================================*/
/* Table: LOI_VI_PHAM                                           */
/*==============================================================*/
create table LOI_VI_PHAM (
   MA_LOI_VI_PHAM       INT IDENTITY(1,1),
   MA_NHOM_VI_PHAM      int             null,
   MA_LOAI_PHUONG_TIEN  int                  null,
   TEN_LOI_VI_PHAM      nvarchar(100)                 null,
   NOI_DUNG             nvarchar(max)                 null,
   MUC_PHAT_TOI_THIEU   float              null,
   MUC_PHAT_TOI_DA      float              null,
   DIEU_LUAT            nvarchar(max)                 null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_LOI_VI_PHAM primary key nonclustered (MA_LOI_VI_PHAM)
)
go

/*==============================================================*/
/* Table: NHOM_LOI_VI_PHAM                                      */
/*==============================================================*/
create table NHOM_LOI_VI_PHAM (
   MA_NHOM_VI_PHAM      INT IDENTITY(1,1),
   TEN_NHOM_VI_PHAM     nvarchar(30)          null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_NHOM_LOI_VI_PHAM primary key nonclustered (MA_NHOM_VI_PHAM)
)
go

/*==============================================================*/
/* Table: PHIEU_NOP_PHAT                                        */
/*==============================================================*/
create table PHIEU_NOP_PHAT (
   MA_GIAO_DICH         INT IDENTITY(1,1),
   MA_BIEN_BANG         int             null,
   NGAY_LAP             datetime             null,
   HINH_THUC_THANH_TOAN nvarchar(20)          null,
   TONG_TIEN            float              null,
   NGAN_HANG            nvarchar(max)                 null,
   SO_THE__SO_TAI_KHOAN char(20)             null,
   PHI_GIAO_DICH        float              null,
   GHI_CHU              nvarchar(max)                 null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_PHIEU_NOP_PHAT primary key nonclustered (MA_GIAO_DICH)
)
go

/*==============================================================*/
/* Table: PHUONG_TIEN                                           */
/*==============================================================*/
create table PHUONG_TIEN (
   MA_PHUONG_TIEN       INT IDENTITY(1,1),
   MA_KHACH_HANG        int             null,
   MA_LOAI_PHUONG_TIEN  int                  null,
   SO_PHUONG_TIEN       nvarchar(6)              null,
   SO_MAY               nvarchar(12)             null,
   NGAY_DANG_KY         datetime             null,
   MAU_SON              nvarchar(20)          null,
   NHAN_HIEU            nvarchar(20)             null,
   DUNG_TICH            int                  null,
   BIEN_SO_XE           char(10)             null,
   NGAY_DAU_DANG_KY     datetime             null,
   GHI_CHU              nvarchar(max)                 null,
   NGAY_TAO             datetime             null,
   NGAY_CAP_NHAT        datetime             null,
   HOAT_DONG            int                  null,
   constraint PK_PHUONG_TIEN primary key nonclustered (MA_PHUONG_TIEN)
)
go

alter table BANG_LAI
   add constraint FK_CO_BANG_LAI foreign key (MA_KHACH_HANG)
      references KHACH_HANG (MA_KHACH_HANG)
go

alter table BANG_LAI
   add constraint FK_THUOC_LOAI_BANG_LAI foreign key (MA_LOAI_BANG_LAI)
      references LOAI_BANG_LAI (MA_LOAI_BANG_LAI)
go

alter table BIEN_BANG
   add constraint FK_KHACH_HANG_BI_PHAT foreign key (MA_KHACH_HANG)
      references KHACH_HANG (MA_KHACH_HANG)
go

alter table BIEN_BANG
   add constraint FK_DUOC_LAP foreign key (MA_SO_CONG_AN)
      references CONG_AN (MA_SO_CONG_AN)

go


alter table DANH_SACH_LOI_VI_PHAM
   add constraint FK_PHAM_LOI foreign key (MA_LOI_VI_PHAM)
      references LOI_VI_PHAM (MA_LOI_VI_PHAM)
go

alter table DANH_SACH_LOI_VI_PHAM
   add constraint FK_THUOC_BIEN_BANG foreign key (MA_BIEN_BANG)
      references BIEN_BANG (MA_BIEN_BANG)
go

alter table LOI_VI_PHAM
   add constraint FK_LOI_VI_PHAM_CUA_LOAI_PHUONG_TIEN foreign key (MA_LOAI_PHUONG_TIEN)
      references LOAI_PHUONG_TIEN (MA_LOAI_PHUONG_TIEN)
go

alter table LOI_VI_PHAM
   add constraint FK_THUOC_NHOM_LVP foreign key (MA_NHOM_VI_PHAM)
      references NHOM_LOI_VI_PHAM (MA_NHOM_VI_PHAM)
go

alter table PHIEU_NOP_PHAT
   add constraint FK_GIAO_DICH foreign key (MA_BIEN_BANG)
      references BIEN_BANG (MA_BIEN_BANG)
go

alter table PHUONG_TIEN
   add constraint FK_KHACH_HANG_CO_PHUONG_TIEN foreign key (MA_KHACH_HANG)
      references KHACH_HANG (MA_KHACH_HANG)
go

alter table PHUONG_TIEN
   add constraint FK_THUOC_LOAI_PHUONG_TIEN foreign key (MA_LOAI_PHUONG_TIEN)
      references LOAI_PHUONG_TIEN (MA_LOAI_PHUONG_TIEN)
go
