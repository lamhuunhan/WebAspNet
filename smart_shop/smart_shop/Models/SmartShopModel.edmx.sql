
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2016 00:17:56
-- Generated from EDMX file: C:\Users\lingo\Desktop\Layout\smart_shop\smart_shop\Models\SmartShopModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [smartshopaspmvc5];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_binhluan_thanhvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[binhluans] DROP CONSTRAINT [FK_binhluan_thanhvien];
GO
IF OBJECT_ID(N'[dbo].[FK_chitietgiamgia_giamgia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitietgiamgias] DROP CONSTRAINT [FK_chitietgiamgia_giamgia];
GO
IF OBJECT_ID(N'[dbo].[FK_ct_dondat_dondat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ct_dondat] DROP CONSTRAINT [FK_ct_dondat_dondat];
GO
IF OBJECT_ID(N'[dbo].[FK_danhgia_thanhvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[danhgias] DROP CONSTRAINT [FK_danhgia_thanhvien];
GO
IF OBJECT_ID(N'[dbo].[FK_dondat_thanhvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dondats] DROP CONSTRAINT [FK_dondat_thanhvien];
GO
IF OBJECT_ID(N'[dbo].[FK_binhluan_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[binhluans] DROP CONSTRAINT [FK_binhluan_sanpham];
GO
IF OBJECT_ID(N'[dbo].[FK_chitietgiamgia_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitietgiamgias] DROP CONSTRAINT [FK_chitietgiamgia_sanpham];
GO
IF OBJECT_ID(N'[dbo].[FK_ct_dondat_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ct_dondat] DROP CONSTRAINT [FK_ct_dondat_sanpham];
GO
IF OBJECT_ID(N'[dbo].[FK_danhgia_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[danhgias] DROP CONSTRAINT [FK_danhgia_sanpham];
GO
IF OBJECT_ID(N'[dbo].[FK_sanpham_loaisp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanphams] DROP CONSTRAINT [FK_sanpham_loaisp];
GO
IF OBJECT_ID(N'[dbo].[FK_accountgroup_nhanvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[accountgroups] DROP CONSTRAINT [FK_accountgroup_nhanvien];
GO
IF OBJECT_ID(N'[dbo].[FK_accountgroup_group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[accountgroups] DROP CONSTRAINT [FK_accountgroup_group];
GO
IF OBJECT_ID(N'[dbo].[FK_grouppath_group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[grouppaths] DROP CONSTRAINT [FK_grouppath_group];
GO
IF OBJECT_ID(N'[dbo].[FK_grouppath_path]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[grouppaths] DROP CONSTRAINT [FK_grouppath_path];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[binhluans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[binhluans];
GO
IF OBJECT_ID(N'[dbo].[chitietgiamgias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[chitietgiamgias];
GO
IF OBJECT_ID(N'[dbo].[ct_dondat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ct_dondat];
GO
IF OBJECT_ID(N'[dbo].[danhgias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[danhgias];
GO
IF OBJECT_ID(N'[dbo].[dondats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dondats];
GO
IF OBJECT_ID(N'[dbo].[giamgias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[giamgias];
GO
IF OBJECT_ID(N'[dbo].[loaisps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[loaisps];
GO
IF OBJECT_ID(N'[dbo].[nhanviens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[nhanviens];
GO
IF OBJECT_ID(N'[dbo].[thanhviens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[thanhviens];
GO
IF OBJECT_ID(N'[dbo].[sanphams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sanphams];
GO
IF OBJECT_ID(N'[dbo].[accountgroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[accountgroups];
GO
IF OBJECT_ID(N'[dbo].[configs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[configs];
GO
IF OBJECT_ID(N'[dbo].[grouppaths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[grouppaths];
GO
IF OBJECT_ID(N'[dbo].[groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[groups];
GO
IF OBJECT_ID(N'[dbo].[paths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[paths];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'binhluans'
CREATE TABLE [dbo].[binhluans] (
    [MaBinhLuan] int IDENTITY(1,1) NOT NULL,
    [TenDangNhap] varchar(255)  NULL,
    [MaSanPham] int  NULL,
    [NgayBinhLuan] datetime  NULL,
    [NoiDungBinhLuan] nvarchar(max)  NULL
);
GO

-- Creating table 'chitietgiamgias'
CREATE TABLE [dbo].[chitietgiamgias] (
    [MaCTGiamGia] int IDENTITY(1,1) NOT NULL,
    [MaGiamGia] int  NOT NULL,
    [MaSanPham] int  NOT NULL,
    [Ngay] datetime  NULL
);
GO

-- Creating table 'ct_dondat'
CREATE TABLE [dbo].[ct_dondat] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MaDonDat] int  NOT NULL,
    [MaSanPham] int  NOT NULL,
    [SoLuong] int  NULL
);
GO

-- Creating table 'danhgias'
CREATE TABLE [dbo].[danhgias] (
    [MaSanPham] int IDENTITY(1,1) NOT NULL,
    [TenDangNhap] varchar(255)  NOT NULL,
    [NoiDung] nvarchar(max)  NULL
);
GO

-- Creating table 'dondats'
CREATE TABLE [dbo].[dondats] (
    [MaDonDat] int IDENTITY(1,1) NOT NULL,
    [TenDangNhap] varchar(255)  NULL,
    [TrangThai] nvarchar(50)  NULL,
    [NoiGiao] nvarchar(max)  NULL,
    [NgayDat] datetime  NULL
);
GO

-- Creating table 'giamgias'
CREATE TABLE [dbo].[giamgias] (
    [MaGiamGia] int IDENTITY(1,1) NOT NULL,
    [Ten] nvarchar(50)  NULL,
    [PhamTramGiam] int  NULL
);
GO

-- Creating table 'loaisps'
CREATE TABLE [dbo].[loaisps] (
    [MaLoaiSP] int IDENTITY(1,1) NOT NULL,
    [TenLoai] nvarchar(50)  NULL,
    [Mota] nvarchar(50)  NULL
);
GO

-- Creating table 'nhanviens'
CREATE TABLE [dbo].[nhanviens] (
    [MaNhanVien] int IDENTITY(1,1) NOT NULL,
    [HoTen] nvarchar(200)  NULL,
    [TenDangNhap] varchar(255)  NULL,
    [MatKhau] varchar(50)  NULL,
    [NgaySinh] datetime  NULL,
    [GioiTinh] nvarchar(50)  NULL,
    [DienThoai] nvarchar(50)  NULL
);
GO

-- Creating table 'thanhviens'
CREATE TABLE [dbo].[thanhviens] (
    [TenDangNhap] varchar(255)  NOT NULL,
    [MatKhau] varchar(50)  NULL,
    [HoTen] nvarchar(500)  NULL,
    [NgaySinh] datetime  NULL,
    [GioiTinh] nvarchar(50)  NULL,
    [DiaChi] nvarchar(500)  NULL,
    [DienThoai] nvarchar(50)  NULL,
    [Email] varchar(200)  NULL,
    [HinhAnh] nvarchar(500)  NULL
);
GO

-- Creating table 'sanphams'
CREATE TABLE [dbo].[sanphams] (
    [MaSanPham] int IDENTITY(1,1) NOT NULL,
    [TenSanPham] nvarchar(500)  NULL,
    [TenSanPham_KhongDau] nvarchar(500)  NULL,
    [SoLuong] int  NULL,
    [HinhAnh1] nvarchar(500)  NULL,
    [HinhAnh2] nvarchar(500)  NULL,
    [HinhAnh3] nvarchar(500)  NULL,
    [HinhAnh4] nvarchar(500)  NULL,
    [DonGia] decimal(10,0)  NULL,
    [ThongTin] nvarchar(max)  NULL,
    [MaLoaiSP] int  NULL,
    [Man] int  NULL,
    [Woman] int  NULL
);
GO

-- Creating table 'accountgroups'
CREATE TABLE [dbo].[accountgroups] (
    [AcountGroupID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [AccountID] int  NULL,
    [Active] int  NULL
);
GO

-- Creating table 'configs'
CREATE TABLE [dbo].[configs] (
    [ConfigID] int IDENTITY(1,1) NOT NULL,
    [ConfigName] nvarchar(50)  NULL,
    [ConfigValue] nvarchar(max)  NULL,
    [Active] int  NULL
);
GO

-- Creating table 'grouppaths'
CREATE TABLE [dbo].[grouppaths] (
    [GroupPathID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [PathID] int  NULL,
    [AccessMaskID] int  NULL
);
GO

-- Creating table 'groups'
CREATE TABLE [dbo].[groups] (
    [GroupID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(50)  NULL,
    [ParentID] int  NULL,
    [Active] int  NULL
);
GO

-- Creating table 'paths'
CREATE TABLE [dbo].[paths] (
    [PathID] int IDENTITY(1,1) NOT NULL,
    [PathName] nvarchar(50)  NULL,
    [PathDescription] nvarchar(500)  NULL,
    [PathURL] nvarchar(500)  NULL,
    [ImageURL] nvarchar(500)  NULL,
    [OrderNo] int  NULL,
    [Display] int  NULL,
    [ParentID] int  NULL,
    [Active] int  NULL,
    [ClassIcon] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaBinhLuan] in table 'binhluans'
ALTER TABLE [dbo].[binhluans]
ADD CONSTRAINT [PK_binhluans]
    PRIMARY KEY CLUSTERED ([MaBinhLuan] ASC);
GO

-- Creating primary key on [MaCTGiamGia] in table 'chitietgiamgias'
ALTER TABLE [dbo].[chitietgiamgias]
ADD CONSTRAINT [PK_chitietgiamgias]
    PRIMARY KEY CLUSTERED ([MaCTGiamGia] ASC);
GO

-- Creating primary key on [ID] in table 'ct_dondat'
ALTER TABLE [dbo].[ct_dondat]
ADD CONSTRAINT [PK_ct_dondat]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [MaSanPham], [TenDangNhap] in table 'danhgias'
ALTER TABLE [dbo].[danhgias]
ADD CONSTRAINT [PK_danhgias]
    PRIMARY KEY CLUSTERED ([MaSanPham], [TenDangNhap] ASC);
GO

-- Creating primary key on [MaDonDat] in table 'dondats'
ALTER TABLE [dbo].[dondats]
ADD CONSTRAINT [PK_dondats]
    PRIMARY KEY CLUSTERED ([MaDonDat] ASC);
GO

-- Creating primary key on [MaGiamGia] in table 'giamgias'
ALTER TABLE [dbo].[giamgias]
ADD CONSTRAINT [PK_giamgias]
    PRIMARY KEY CLUSTERED ([MaGiamGia] ASC);
GO

-- Creating primary key on [MaLoaiSP] in table 'loaisps'
ALTER TABLE [dbo].[loaisps]
ADD CONSTRAINT [PK_loaisps]
    PRIMARY KEY CLUSTERED ([MaLoaiSP] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'nhanviens'
ALTER TABLE [dbo].[nhanviens]
ADD CONSTRAINT [PK_nhanviens]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [TenDangNhap] in table 'thanhviens'
ALTER TABLE [dbo].[thanhviens]
ADD CONSTRAINT [PK_thanhviens]
    PRIMARY KEY CLUSTERED ([TenDangNhap] ASC);
GO

-- Creating primary key on [MaSanPham] in table 'sanphams'
ALTER TABLE [dbo].[sanphams]
ADD CONSTRAINT [PK_sanphams]
    PRIMARY KEY CLUSTERED ([MaSanPham] ASC);
GO

-- Creating primary key on [AcountGroupID] in table 'accountgroups'
ALTER TABLE [dbo].[accountgroups]
ADD CONSTRAINT [PK_accountgroups]
    PRIMARY KEY CLUSTERED ([AcountGroupID] ASC);
GO

-- Creating primary key on [ConfigID] in table 'configs'
ALTER TABLE [dbo].[configs]
ADD CONSTRAINT [PK_configs]
    PRIMARY KEY CLUSTERED ([ConfigID] ASC);
GO

-- Creating primary key on [GroupPathID] in table 'grouppaths'
ALTER TABLE [dbo].[grouppaths]
ADD CONSTRAINT [PK_grouppaths]
    PRIMARY KEY CLUSTERED ([GroupPathID] ASC);
GO

-- Creating primary key on [GroupID] in table 'groups'
ALTER TABLE [dbo].[groups]
ADD CONSTRAINT [PK_groups]
    PRIMARY KEY CLUSTERED ([GroupID] ASC);
GO

-- Creating primary key on [PathID] in table 'paths'
ALTER TABLE [dbo].[paths]
ADD CONSTRAINT [PK_paths]
    PRIMARY KEY CLUSTERED ([PathID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TenDangNhap] in table 'binhluans'
ALTER TABLE [dbo].[binhluans]
ADD CONSTRAINT [FK_binhluan_thanhvien]
    FOREIGN KEY ([TenDangNhap])
    REFERENCES [dbo].[thanhviens]
        ([TenDangNhap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_binhluan_thanhvien'
CREATE INDEX [IX_FK_binhluan_thanhvien]
ON [dbo].[binhluans]
    ([TenDangNhap]);
GO

-- Creating foreign key on [MaGiamGia] in table 'chitietgiamgias'
ALTER TABLE [dbo].[chitietgiamgias]
ADD CONSTRAINT [FK_chitietgiamgia_giamgia]
    FOREIGN KEY ([MaGiamGia])
    REFERENCES [dbo].[giamgias]
        ([MaGiamGia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_chitietgiamgia_giamgia'
CREATE INDEX [IX_FK_chitietgiamgia_giamgia]
ON [dbo].[chitietgiamgias]
    ([MaGiamGia]);
GO

-- Creating foreign key on [MaDonDat] in table 'ct_dondat'
ALTER TABLE [dbo].[ct_dondat]
ADD CONSTRAINT [FK_ct_dondat_dondat]
    FOREIGN KEY ([MaDonDat])
    REFERENCES [dbo].[dondats]
        ([MaDonDat])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ct_dondat_dondat'
CREATE INDEX [IX_FK_ct_dondat_dondat]
ON [dbo].[ct_dondat]
    ([MaDonDat]);
GO

-- Creating foreign key on [TenDangNhap] in table 'danhgias'
ALTER TABLE [dbo].[danhgias]
ADD CONSTRAINT [FK_danhgia_thanhvien]
    FOREIGN KEY ([TenDangNhap])
    REFERENCES [dbo].[thanhviens]
        ([TenDangNhap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_danhgia_thanhvien'
CREATE INDEX [IX_FK_danhgia_thanhvien]
ON [dbo].[danhgias]
    ([TenDangNhap]);
GO

-- Creating foreign key on [TenDangNhap] in table 'dondats'
ALTER TABLE [dbo].[dondats]
ADD CONSTRAINT [FK_dondat_thanhvien]
    FOREIGN KEY ([TenDangNhap])
    REFERENCES [dbo].[thanhviens]
        ([TenDangNhap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dondat_thanhvien'
CREATE INDEX [IX_FK_dondat_thanhvien]
ON [dbo].[dondats]
    ([TenDangNhap]);
GO

-- Creating foreign key on [MaSanPham] in table 'binhluans'
ALTER TABLE [dbo].[binhluans]
ADD CONSTRAINT [FK_binhluan_sanpham]
    FOREIGN KEY ([MaSanPham])
    REFERENCES [dbo].[sanphams]
        ([MaSanPham])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_binhluan_sanpham'
CREATE INDEX [IX_FK_binhluan_sanpham]
ON [dbo].[binhluans]
    ([MaSanPham]);
GO

-- Creating foreign key on [MaSanPham] in table 'chitietgiamgias'
ALTER TABLE [dbo].[chitietgiamgias]
ADD CONSTRAINT [FK_chitietgiamgia_sanpham]
    FOREIGN KEY ([MaSanPham])
    REFERENCES [dbo].[sanphams]
        ([MaSanPham])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_chitietgiamgia_sanpham'
CREATE INDEX [IX_FK_chitietgiamgia_sanpham]
ON [dbo].[chitietgiamgias]
    ([MaSanPham]);
GO

-- Creating foreign key on [MaSanPham] in table 'ct_dondat'
ALTER TABLE [dbo].[ct_dondat]
ADD CONSTRAINT [FK_ct_dondat_sanpham]
    FOREIGN KEY ([MaSanPham])
    REFERENCES [dbo].[sanphams]
        ([MaSanPham])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ct_dondat_sanpham'
CREATE INDEX [IX_FK_ct_dondat_sanpham]
ON [dbo].[ct_dondat]
    ([MaSanPham]);
GO

-- Creating foreign key on [MaSanPham] in table 'danhgias'
ALTER TABLE [dbo].[danhgias]
ADD CONSTRAINT [FK_danhgia_sanpham]
    FOREIGN KEY ([MaSanPham])
    REFERENCES [dbo].[sanphams]
        ([MaSanPham])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaLoaiSP] in table 'sanphams'
ALTER TABLE [dbo].[sanphams]
ADD CONSTRAINT [FK_sanpham_loaisp]
    FOREIGN KEY ([MaLoaiSP])
    REFERENCES [dbo].[loaisps]
        ([MaLoaiSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_sanpham_loaisp'
CREATE INDEX [IX_FK_sanpham_loaisp]
ON [dbo].[sanphams]
    ([MaLoaiSP]);
GO

-- Creating foreign key on [AccountID] in table 'accountgroups'
ALTER TABLE [dbo].[accountgroups]
ADD CONSTRAINT [FK_accountgroup_nhanvien]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[nhanviens]
        ([MaNhanVien])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_accountgroup_nhanvien'
CREATE INDEX [IX_FK_accountgroup_nhanvien]
ON [dbo].[accountgroups]
    ([AccountID]);
GO

-- Creating foreign key on [GroupID] in table 'accountgroups'
ALTER TABLE [dbo].[accountgroups]
ADD CONSTRAINT [FK_accountgroup_group]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[groups]
        ([GroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_accountgroup_group'
CREATE INDEX [IX_FK_accountgroup_group]
ON [dbo].[accountgroups]
    ([GroupID]);
GO

-- Creating foreign key on [GroupID] in table 'grouppaths'
ALTER TABLE [dbo].[grouppaths]
ADD CONSTRAINT [FK_grouppath_group]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[groups]
        ([GroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_grouppath_group'
CREATE INDEX [IX_FK_grouppath_group]
ON [dbo].[grouppaths]
    ([GroupID]);
GO

-- Creating foreign key on [PathID] in table 'grouppaths'
ALTER TABLE [dbo].[grouppaths]
ADD CONSTRAINT [FK_grouppath_path]
    FOREIGN KEY ([PathID])
    REFERENCES [dbo].[paths]
        ([PathID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_grouppath_path'
CREATE INDEX [IX_FK_grouppath_path]
ON [dbo].[grouppaths]
    ([PathID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------