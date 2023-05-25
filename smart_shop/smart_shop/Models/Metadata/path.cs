using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smart_shop.Models
{
    [MetadataType(typeof(pathMetadata))]
    public partial class path
    {
        class pathMetadata
        {
            public int PathID { get; set; }
            [Display(Name ="Name")]
            [Required(ErrorMessage ="{0} khong được để trống")]
            public string PathName { get; set; }
            [Display(Name = "Mô tả")]

            public string PathDescription { get; set; }
            [Display(Name = "URL")]
            [Required(ErrorMessage = "{0} khong được để trống")]
            public string PathURL { get; set; }
            [Display(Name = "Hình ảnh")]
            public string ImageURL { get; set; }
            [Display(Name = "Thứ")]
            public Nullable<int> OrderNo { get; set; }
            [Display(Name = "Hiển thị")]
            [Range(0, 1)]
            public Nullable<int> Display { get; set; }
            [Display(Name = "Cây cha")]
            public Nullable<int> ParentID { get; set; }
            [Display(Name = "Hoạt động")]
            [Range(0,1)]
            public Nullable<int> Active { get; set; }
            [Display(Name = "Icon class")]
            public string ClassIcon { get; set; }
        }
    }
}