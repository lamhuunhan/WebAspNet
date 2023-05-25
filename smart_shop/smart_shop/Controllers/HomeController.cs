using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smart_shop.Models;
using System.Data.Entity;

namespace smart_shop.Controllers
{
    public class HomeController : Controller
    {
        smart_shopEntities db = new smart_shopEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        #region giỏ hàng
        /// <summary>
        /// Lấy toàn bộ item trong giỏ hàng
        /// </summary>
        /// <returns>Khởi tạo rỗng nếu chưa có</returns>
        public List<ItemGioHang> GetGioHang()
        {

            List<ItemGioHang> kq = Session["cart"] as List<ItemGioHang>;
            if (kq == null)
            {
                kq = new List<ItemGioHang>();
                Session["cart"] = kq;
            }
            return kq;
        }
        /// <summary>
        /// Tính tổng số lượng sản phẩm có trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public int TongSoLuong()
        {
            List<ItemGioHang> kq = Session["cart"] as List<ItemGioHang>;
            if (kq == null)
                return 0;
            return kq.Sum(n => n.SoLuong);
        }
        /// <summary>
        /// Tính tổng tiền hiện có trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public decimal? TongTien()
        {
            List<ItemGioHang> kq = Session["cart"] as List<ItemGioHang>;
            if (kq == null)
                return 0;
            return kq.Sum(n => (n.SoLuong * (n.DonGia - (Convert.ToDecimal(n.GiamGia) * n.DonGia))));
        }
        /// <summary>
        /// Thêm một sản phẩm mới vào giỏ hàng
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        /// <returns></returns>
        public ActionResult ThemGioHang(int maSP)
        {
            sanpham sp = db.sanphams.Find(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> kq = GetGioHang();
            ItemGioHang getItemExists = kq.Find(n => n.MaSP == maSP);
            if (getItemExists != null)
            {
                if (getItemExists.SoLuong < 6 && getItemExists.SoLuong <= sp.SoLuong)
                {
                    getItemExists.SoLuong++;
                }
                ViewBag.TongTien = TongTien();
                ViewBag.TongSoLuong = TongSoLuong();
                Session["cart"] = kq;
                return PartialView("GioHangPartial");
            }
            getItemExists = new ItemGioHang(maSP);
            if (getItemExists.SoLuong <= sp.SoLuong)
                kq.Add(getItemExists);
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuong = TongSoLuong();
            Session["cart"] = kq;
            return PartialView("GioHangPartial");
        }
        /// <summary>
        /// Thêm sản phẩm mới vào giỏ hàng với số lượng cho trước
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        /// <param name="sl">Số lượng của sản phẩm đó</param>
        /// <returns></returns>
        public ActionResult ThemGioHangSL(int maSP, int sl)
        {
            sanpham sp = db.sanphams.Find(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> kq = GetGioHang();
            ItemGioHang getItemExists = kq.Find(n => n.MaSP == maSP);
            if (getItemExists != null)
            {
                if (getItemExists.SoLuong < 6 && getItemExists.SoLuong <= sp.SoLuong)
                {
                    getItemExists.SoLuong = sl;
                }
                ViewBag.TongTien = TongTien();
                ViewBag.TongSoLuong = TongSoLuong();
                Session["cart"] = kq;
                return PartialView("GioHangPartial");
            }
            getItemExists = new ItemGioHang(maSP, sl);
            if (getItemExists.SoLuong <= sp.SoLuong)
                kq.Add(getItemExists);
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuong = TongSoLuong();
            Session["cart"] = kq;
            return PartialView("GioHangPartial");
        }


        /// <summary>
        /// Một giỏ hàng Partial có chức năng Load Ajax
        /// </summary>
        /// <returns></returns>
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                ViewBag.TongTien = 0;
                ViewBag.TongSoLuong = 0;
                return PartialView();
            }
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        /// <summary>
        /// xóa một Item trong giỏ hàng
        /// </summary>
        /// <param name="maSP"> Mã sản phẩm</param>
        /// <returns></returns>
        public ActionResult DeleteItemCart(int? maSP)
        {
            sanpham sp = db.sanphams.Find(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> cart = Session["cart"] as List<ItemGioHang>;
            ItemGioHang it = cart.Find(n => n.MaSP == maSP);
            if (it == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            cart.Remove(it);
            ViewBag.TongTien = TongTien();
            return PartialView(cart);
        }
        /// <summary>
        /// Cập nhập lại số lượng sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="maSP">Mã sản phẩm muốn cập nhật</param>
        /// <param name="sl">Số lượng cập nhật</param>
        /// <returns></returns>
        public ActionResult UpdateItemCart(int? maSP, int sl)
        {
            sanpham sp = db.sanphams.Find(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> kq = Session["cart"] as List<ItemGioHang>;
            ItemGioHang getItemExists = kq.Find(n => n.MaSP == maSP);
            if (getItemExists != null)
            {
                if (sl <= sp.SoLuong)
                {
                    getItemExists.SoLuong = sl;
                }
                ViewBag.TongTien = TongTien();
                ViewBag.TongSoLuong = TongSoLuong();
                Session["cart"] = kq;
            }
            return PartialView("DeleteItemCart", kq);

        }

        public string DatHang(string noigiaoSP)
        {
            dondat dd = new dondat();
            List<ItemGioHang> kq = Session["cart"] as List<ItemGioHang>;
            thanhvien tv = Session["login"] as thanhvien;
            if (kq == null || tv == null)
                return "err";
            else
            {
                dd.TenDangNhap = tv.TenDangNhap;
                dd.TrangThai = "Đã đặt hàng, chờ xác nhận";
                dd.NoiGiao = noigiaoSP;
                dd.NgayDat = DateTime.Now;
                db.dondats.Add(dd);

                foreach (var item in kq)
                {
                    ct_dondat ctdd = new ct_dondat();
                    ctdd.MaDonDat = dd.MaDonDat;
                    ctdd.MaSanPham = item.MaSP;
                    ctdd.SoLuong = item.SoLuong;
                    db.ct_dondat.Add(ctdd);
                }
                db.SaveChanges();
                Session["cart"] = null;
                return "ok";

            }
        }

        #endregion

        [HttpGet]
        public ActionResult Account(string id)
        {
            thanhvien tamp = db.thanhviens.Find(id);
            if (Session["login"] == null)
            {
                return RedirectToAction("Index");
            }
            if (((thanhvien)Session["login"]).TenDangNhap != tamp.TenDangNhap)
                return RedirectToAction("Index");
            return View(tamp);
        }
        [HttpPost]
        public ActionResult Account([Bind(Include = "TenDangNhap,MatKhau,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,Email,HinhAnh")] thanhvien thanhvien, FormCollection f)
        {
            string gtt = f["gtinh"].ToString();
            if (gtt == "N")
                thanhvien.GioiTinh = "Nam";
            else
                thanhvien.GioiTinh = "Nữ";
            db.Entry(thanhvien).State = EntityState.Modified;
            db.SaveChanges();

            return View(thanhvien);
        }
        public string UpdatePassWord(string User, string Pass, string NewPass)
        {
            if (Session["login"] == null)
            {
                return "err";
            }
            var tv = db.thanhviens.Find(User);
            if (tv != null)
            {
                if (tv.MatKhau != Pass)
                    return "Cập nhập thất bại";
                else
                {
                    tv.MatKhau = NewPass;
                    db.Entry(tv).State = System.Data.Entity.EntityState.Modified;
                    if (db.SaveChanges() == 1)
                        return "ok";
                }
            }
            return "Cập nhập thất bại";

        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult Updatepass(string user)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index");
            }
            thanhvien tv = db.thanhviens.Single(n => n.TenDangNhap == user);
            return PartialView(tv);
        }
        public ActionResult Singup(string url, string username, string password)
        {
            thanhvien tv = new thanhvien();
            tv.TenDangNhap = username;
            tv.MatKhau = password;
            db.thanhviens.Add(tv);
            int sr = db.SaveChanges();
            if (sr > 0)
            {
                Session["login"] = tv;
            }
            return Redirect(url);
        }
        public string Login(string username, string password)
        {
            thanhvien tv = db.thanhviens.FirstOrDefault(n => n.TenDangNhap == username && n.MatKhau == password);
            var employeer = db.nhanviens.FirstOrDefault(n => n.TenDangNhap == username && n.MatKhau == password);
            if (tv?.TenDangNhap == employeer?.TenDangNhap)
            {
                return "Tên đăng nhập hoặc mật khẩu không chính xác";
            }
            if (tv != null)
            {
                if (tv.MatKhau != password)
                    return "Tên đăng nhập hoặc mật khẩu không chính xác";
                else
                {
                    Session["login"] = tv;
                    return "ok";
                }
            }
            if (employeer != null)
            {
                if (employeer.MatKhau != password)
                    return "Tên đăng nhập hoặc mật khẩu không chính xác";
                else
                {
                    Session["admin"] = employeer;
                    return "admin";
                }
            }
            return "Tên đăng nhập hoặc mật khẩu không chính xác";

        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView(db.loaisps.ToList());
        }

        public ActionResult MenuProduct()
        {
            return PartialView(db.loaisps.ToList());
        }

        public ActionResult OptionLSP()
        {
            return PartialView(db.loaisps.ToList());
        }
        public ActionResult Checkout()
        {
            thanhvien tv = new thanhvien();
            if (Session["login"] != null)
            {
                thanhvien t = (thanhvien)Session["login"];
                tv = db.thanhviens.Find(t.TenDangNhap);
            }
            List<ItemGioHang> kq = GetGioHang();
            ViewBag.cart = kq;
            ViewBag.TongTien = TongTien();
            return View(tv);
        }
        public ActionResult ThemBinhLuan(int? masp, string nd)
        {
            thanhvien tv = Session["login"] as thanhvien;
            if (tv != null)
            {
                binhluan bl = new binhluan();
                bl.MaSanPham = masp;
                bl.NoiDungBinhLuan = nd;
                bl.TenDangNhap = tv.TenDangNhap;
                bl.NgayBinhLuan = DateTime.Now;
                db.binhluans.Add(bl);
                db.SaveChanges();
            }
            return PartialView(db.binhluans.Where(n => n.MaSanPham == masp).ToList());
        }
        public ActionResult XoaBinhLuan(int? mabluan, int? masp)
        {
            binhluan dl = db.binhluans.Find(mabluan);
            if (dl != null)
            {
                db.binhluans.Remove(dl);
                db.SaveChanges();
            }
            return PartialView("ThemBinhLuan", db.binhluans.Where(n => n.MaSanPham == masp).ToList());
        }

        public ActionResult formUpdateBL([Bind(Include = "MaBinhLuan,TenDangNhap,MaSanPham,NgayBinhLuan,NoiDungBinhLuan")] binhluan bl,
            int? mabl, string noidungbt, string tdn, int? masp, DateTime nbl)
        {
            binhluan ble = db.binhluans.Find(mabl);
            sanpham sp = db.sanphams.Find(masp);
            thanhvien tv = db.thanhviens.Find(tdn);
            if (ble == null || sp == null || tv == null)
            {
                return null;
            }
            ble.MaBinhLuan = ble.MaBinhLuan;
            ble.NoiDungBinhLuan = noidungbt;
            ble.TenDangNhap = tdn;
            ble.MaSanPham = masp;
            ble.NgayBinhLuan = nbl;
            db.Entry(ble).State = EntityState.Modified;
            db.SaveChanges();
            return PartialView("ThemBinhLuan", db.binhluans.Where(n => n.MaSanPham == masp).ToList());
        }
    }
}