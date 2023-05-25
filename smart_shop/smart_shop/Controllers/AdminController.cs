using smart_shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using System.Data.Entity;

namespace smart_shop.Controllers
{
    using toys.Extensions;
    [RoutePrefix("quan-ly")]
    public class AdminController : Controller
    {
        smart_shopEntities db = new smart_shopEntities();
        #region Quản lý sản phẩm
        [Route("san-pham.html")]
        public ActionResult Products(string Search,int? page,int? pagesiZe)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            ViewBag.Search = Search;
            var sanphams = db.sanphams.ToList();
            if (!String.IsNullOrEmpty(Search))
            {
               
                try
                {
                    decimal? dg = decimal.Parse(Search);
                    sanphams = db.sanphams.Where(n => n.DonGia <= dg).ToList();
                }
                catch (Exception)
                {

                    sanphams = db.sanphams.Where(n => n.TenSanPham.Contains(Search)).ToList();
                    //sp = db.sanphams.Where(n => n.ThongTin.Contains(Search)).ToList();
                }
            }

            ViewBag.MaLoaiSP = new SelectList(db.loaisps, "MaLoaiSP", "TenLoai");
            int pageNumber = page ?? 1;
            int pageSize = pagesiZe ?? 6;
            ViewBag.Count = sanphams.Count();
            return View(sanphams.OrderByDescending(n=>n.MaSanPham).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult ProductsAjax(string Search)
        {
            ViewBag.Search = Search;
            var sp = db.sanphams.ToList();
            try
            {
                decimal? dg = decimal.Parse(Search);
                sp = db.sanphams.Where(n => n.DonGia <= dg).ToList();
            }
            catch (Exception)
            {

                sp = db.sanphams.Where(n => n.TenSanPham.Contains(Search)).ToList();
                //sp = db.sanphams.Where(n => n.ThongTin.Contains(Search)).ToList();
            }
            ViewBag.MaLoaiSP = new SelectList(db.loaisps, "MaLoaiSP", "TenLoai");
            int pageNumber =  1;
            int pageSize = 6;
            ViewBag.Count = sp.Count();
            return PartialView(sp.OrderByDescending(n=>n.MaSanPham).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Edit_CreateProduct(sanpham sp,HttpPostedFileBase HA1, 
            HttpPostedFileBase HA2, HttpPostedFileBase HA3,
            HttpPostedFileBase HA4,string Search,int? page)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            sanpham tam = db.sanphams.Find(sp.MaSanPham);

            if(tam == null)
            {
                #region thêm sp
                sanpham spm = new sanpham();
                //Tạo mới
                spm.TenSanPham = sp.TenSanPham;


                spm.TenSanPham_KhongDau = sp.TenSanPham.ToFriendlyUrl();
                spm.SoLuong = sp.SoLuong;
                spm.DonGia = sp.DonGia;
                spm.ThongTin = sp.ThongTin;
                spm.MaLoaiSP = sp.MaLoaiSP;
                if (sp.Man == 2)
                {
                    spm.Woman = sp.Woman;
                }
                else
                {
                    spm.Man = sp.Man;
                }
                    
                if(HA1.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(HA1.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if(!System.IO.File.Exists(path))
                    {
                        HA1.SaveAs(path);
                    }
                    spm.HinhAnh1 = fileName;
                }
                if(HA2 ==null || HA2.FileName==HA1.FileName){ spm.HinhAnh2 = spm.HinhAnh1; }
                else if(HA2.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(HA2.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path))  { HA2.SaveAs(path);   }
                    spm.HinhAnh2 = fileName;
                }
                if (HA3 == null) { spm.HinhAnh3 = spm.HinhAnh1; }
                else {
                    var fileName = System.IO.Path.GetFileName(HA3.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path)) {  HA3.SaveAs(path);  }
                    spm.HinhAnh3 = fileName;
                }
                if (HA4 == null) { spm.HinhAnh4 = spm.HinhAnh1; }
                else 
                {
                        var fileName = System.IO.Path.GetFileName(HA4.FileName);
                        var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                        if (!System.IO.File.Exists(path)) { HA4.SaveAs(path); }
                        spm.HinhAnh4 = fileName;
                    
                }
                db.sanphams.Add(spm);
                db.SaveChanges();
                #endregion
            }
            else
            {
                tam.TenSanPham = sp.TenSanPham;
               


                tam.TenSanPham_KhongDau = sp.TenSanPham.ToFriendlyUrl();
                tam.SoLuong = sp.SoLuong;
                tam.DonGia = sp.DonGia;
                tam.ThongTin = sp.ThongTin;
                tam.MaLoaiSP = sp.MaLoaiSP;
                if (sp.Man == 2)
                {
                    tam.Woman = sp.Woman;
                }
                else
                {
                    tam.Man = sp.Man;
                }
                
               
                if (HA1 == null) tam.HinhAnh1 = tam.HinhAnh1;
                else
                {
                    var fileName = System.IO.Path.GetFileName(HA1.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path))
                    {
                        HA1.SaveAs(path);
                    }
                    tam.HinhAnh1 = fileName;
                }
                if (HA2 == null) tam.HinhAnh2 = tam.HinhAnh2;
                else
                {
                    var fileName = System.IO.Path.GetFileName(HA2.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path))
                    {
                        HA2.SaveAs(path);
                    }
                    tam.HinhAnh2 = fileName;
                }
                if (HA3 == null) tam.HinhAnh3 = tam.HinhAnh3;
                else
                {
                    var fileName = System.IO.Path.GetFileName(HA3.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path))
                    {
                        HA3.SaveAs(path);
                    }
                    tam.HinhAnh3 = fileName;
                }
                if (HA4 == null) tam.HinhAnh4 = tam.HinhAnh4;
                else
                {
                    var fileName = System.IO.Path.GetFileName(HA4.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    if (!System.IO.File.Exists(path))
                    {
                        HA4.SaveAs(path);
                    }
                    tam.HinhAnh4 = fileName;
                }
                db.Entry(tam).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Products",new {@page=page,@Search=Search });

        }
        [HttpPost]
        public ActionResult DeleteAjax(int? id, int? page, string Search)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            sanpham idsp = db.sanphams.Single(n => n.MaSanPham == id);

            if (idsp != null)
            {
                db.sanphams.Remove(idsp);
                db.SaveChanges();
            }
            int pageNumber = page ?? 1; // phan trang
            int pageSize = 6;
            var sanpham = db.sanphams.ToList();
            try
            {
                decimal? dg = decimal.Parse(Search);
                sanpham = db.sanphams.Where(n => n.DonGia <= dg).ToList();
            }
            catch (Exception)
            {

                sanpham = db.sanphams.Where(n => n.TenSanPham.Contains(Search)).ToList();
                //sp = db.sanphams.Where(n => n.ThongTin.Contains(Search)).ToList();
            }
            return RedirectToAction("Products", new { @page = page, @Search = Search });
        }
        #endregion

        #region Quản lý loại sản phẩm
        [Route("loai-san-pham.html")]
        public ActionResult Category(int? page,string search)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            ViewBag.Search = search;
            int pageNumber = page ?? 1;
            var lsp = db.loaisps.ToList();
            if (!String.IsNullOrEmpty(search))
            {
                lsp = db.loaisps.Where(n => n.TenLoai.Contains(search)).ToList();
            }
            return View(lsp.ToPagedList(pageNumber,6));
        }
        public ActionResult Create_EditCategory(loaisp sp)
        {
            loaisp lsp = new loaisp();
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            if (sp.MaLoaiSP==0)
            {
                lsp.Url = sp.TenLoai.ToFriendlyUrl(); // chuyen sang chu khong dau dung de seo mang
                db.loaisps.Add(sp);// them loai
                db.SaveChanges(); // luu
            }
            else
            {
                loaisp loaisp_ = db.loaisps.Find(sp.MaLoaiSP);
                loaisp_.TenLoai = sp.TenLoai;
                loaisp_.Url = sp.TenLoai.ToFriendlyUrl();
                loaisp_.Mota = sp.Mota;
                db.Entry(loaisp_).State = System.Data.Entity.EntityState.Modified;// trang thai sua
                db.SaveChanges(); /// luu xuong db
            }
            return RedirectToAction("Category");
        }

        public ActionResult DeleteLoaiSP(int? idloaisp)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");

            loaisp ls = db.loaisps.Find(idloaisp);
            if(ls!=null)
            {
                db.loaisps.Remove(ls);
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }
        #endregion

        #region Quản lý thành viên

        [Route("nguoi-dung.html")]
        public ActionResult Member(string search,int? page)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");

            ViewBag.Search = search;
            int pageNumber = page ?? 1;
            var lsp = db.thanhviens.ToList();
            if (!String.IsNullOrEmpty(search))
            {
                lsp = db.thanhviens.Where(n => n.HoTen.Contains(search)).ToList();
            }
            return View(lsp.ToPagedList(pageNumber, 6));
        }

        public ActionResult MemberEdit(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanhvien thanhvien = db.thanhviens.Find(id);
            if (thanhvien == null)
            {
                return HttpNotFound();
            }
            return View(thanhvien);
        }
        [HttpPost]
        public ActionResult MemberEdit([Bind(Include = "TenDangNhap,MatKhau,HoTen,NgaySinh,GioiTinh,DienThoai,Email,HinhAnh")] thanhvien thanhvien)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                db.Entry(thanhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Member");
            }
            return View(thanhvien);
        }

        public ActionResult MemberCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberCreate([Bind(Include = "TenDangNhap,MatKhau,HoTen,NgaySinh,GioiTinh,DienThoai,Email,HinhAnh")] thanhvien thanhvien)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                db.thanhviens.Add(thanhvien);
                db.SaveChanges();
                return RedirectToAction("Member");
            }

            return View(thanhvien);
        }
        public ActionResult MemberDele(string idloaisp)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            thanhvien ls = db.thanhviens.Find(idloaisp);
            if (ls != null)
            {
                db.thanhviens.Remove(ls);
                db.SaveChanges();
            }
            return RedirectToAction("Member");
        }

        #endregion

        #region Quản lý giỏ hàng
        public ActionResult Cart(string search,int? page)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            ViewBag.Search = search;
            int pageNumber = page ?? 1;
            var lsp = db.dondats.ToList();
            if (!String.IsNullOrEmpty(search))
            {
                lsp = db.dondats.Where(n => n.TenDangNhap.Contains(search)).ToList();
            }
            return View(lsp.OrderByDescending(n=>n.NgayDat).ToPagedList(pageNumber, 6));
        }
        public ActionResult CartUp(int? id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            dondat dd = db.dondats.Find(id);
            if(dd!=null)
            {
                dd.TrangThai = "Xác nhận, Đang gửi hàng";
                db.Entry(dd).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult CartErr(int? id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            dondat dd = db.dondats.Find(id);
            if (dd != null)
            {
                dd.TrangThai = "Đã có lỗi";
                db.Entry(dd).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }



        public ActionResult CartDet(int? id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            dondat dd = db.dondats.Find(id);
            if(dd!=null)
            {
                ViewBag.DonDat = dd;
                var ctdd = db.ct_dondat.Where(n => n.MaDonDat == id);
                return View(ctdd.ToList());
            }
            return RedirectToAction("Cart");
        }
        #endregion


        #region Quản lý bình luận

        public ActionResult Comment(string search,int? page)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            ViewBag.Search = search;
            int pageNumber = page ?? 1;
            var lsp = db.binhluans.ToList();
            if (!String.IsNullOrEmpty(search))
            {
                lsp = db.binhluans.Where(n => n.TenDangNhap.Contains(search)).ToList();
            }
            return View(lsp.OrderByDescending(n => n.NgayBinhLuan).ToPagedList(pageNumber, 6));
        }

        public ActionResult DeleteComment(int? idmabinhluan)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            binhluan bl = db.binhluans.Find(idmabinhluan);
            if(bl!=null)
            {
                db.binhluans.Remove(bl);
                db.SaveChanges();
            }
            return RedirectToAction("Comment");
        }


        public ActionResult EditComment(int? idmabinhluans, string noidungbinhluane)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            binhluan bl = db.binhluans.Find(idmabinhluans);
            if (bl != null)
            {
                bl.NoiDungBinhLuan = noidungbinhluane;
                db.Entry(bl).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Comment");
        }

        #endregion


        public ActionResult Login(string user,string pass)
        {
            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
            {
                nhanvien nv = db.nhanviens.Single(n => n.TenDangNhap == user && n.MatKhau == pass);
                if (nv != null)
                {
                    Session["admin"] = nv;
                    return RedirectToAction("Index");
                }
            }
            return View();
            
        }
        [Route("dang-xuat.html")]
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }
        [Route("trang-quan-tri.html")]
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
            ViewBag.TongDDH = db.dondats.Count();
            ViewBag.TongBL = db.binhluans.Count();
            ViewBag.TongSP = db.sanphams.Count();
            return View();
        }
        
    }
}