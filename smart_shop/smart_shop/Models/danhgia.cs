//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace smart_shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class danhgia
    {
        public int MaSanPham { get; set; }
        public string TenDangNhap { get; set; }
        public string NoiDung { get; set; }
    
        public virtual sanpham sanpham { get; set; }
        public virtual thanhvien thanhvien { get; set; }
    }
}
