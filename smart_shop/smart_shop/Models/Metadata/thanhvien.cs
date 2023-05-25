using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace smart_shop.Models
{
    [MetadataType(typeof(thanhvienMetadata))]
    public partial class thanhvien
    {
        class thanhvienMetadata
        {
            [DisplayName("Tên đăng nhập")]
            public string TenDangNhap { get; set; }
            [DisplayName("Mật khẩu")]
            public string MatKhau { get; set; }

            [DisplayName("Họ tên")]
            public string HoTen { get; set; }
            [DisplayName("Ngày sinh")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
            public Nullable<System.DateTime> NgaySinh { get; set; }
            [DisplayName("Giới tính")]
            public string GioiTinh { get; set; }
            [DisplayName("Địa chỉ")]

            public string DiaChi { get; set; }
            [DisplayName("Điện thoại")]
            public string DienThoai { get; set; }
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [DisplayName("Hình đại diện")]
            public string HinhAnh { get; set; }
        }
    }
}