using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smart_shop.Models
{
    [MetadataType(typeof(sanphamMetaData))]
    public partial class sanpham
    {
        class sanphamMetaData
        {
            public int MaSanPham { get; set; }
            [Display(Name ="Tên")]
            public string TenSanPham { get; set; }
            [Display(Name = "Link")]
            public string TenSanPham_KhongDau { get; set; }
            [Display(Name = "Số Lượng")]
            public Nullable<int> SoLuong { get; set; }
            [Display(Name = "Giảm giá")]
            public Nullable<float> GiamGia { get; set; }
            [Display(Name = "Hình 1")]
            public string HinhAnh1 { get; set; }
            [Display(Name = "Hình 2")]
            public string HinhAnh2 { get; set; }
            [Display(Name = "Hình 3")]
            public string HinhAnh3 { get; set; }
            [Display(Name = "Hình 4")]
            public string HinhAnh4 { get; set; }
            [Display(Name = "Giá")]
            public Nullable<decimal> DonGia { get; set; }
            [Display(Name = "Mô tả")]
            public string ThongTin { get; set; }
            [Display(Name = "Loại sản phẩm")]
            public Nullable<int> MaLoaiSP { get; set; }
            [Display(Name = "M")]
            [Range(0,1)]
            public Nullable<int> Man { get; set; }
            [Display(Name = "F")]
            [Range(0, 1)]
            public Nullable<int> Woman { get; set; }

            public virtual loaisp loaisp { get; set; }
        }
    }
}