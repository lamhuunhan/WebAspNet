using smart_shop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace smart_shop.Controllers
{
    public class SearchController : Controller
    {
        smart_shopEntities db = new smart_shopEntities();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getCategory(int? sex)
        {
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;

                if (sex == 1)
                {
                    var data = db.loaisps.Select(n => new { MaLoaiSP = n.MaLoaiSP, TenLoai = n.TenLoai, Url = n.Url });
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                if (sex == 0)
                {
                    var data = db.loaisps.Select(n => new { MaLoaiSP = n.MaLoaiSP, TenLoai = n.TenLoai, Url = n.Url });
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.DenyGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {

                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }
        public JsonResult getProductDetail(int? categoryid)
        {

            if (categoryid != 0)
            {
                var productDetail = db.sanphams.
                    Where(t => t.MaLoaiSP == categoryid).
                    Select(n => new
                    {
                        TenSanPham = n.TenSanPham,
                        MaSanPham = n.MaSanPham,
                        TenSanPham_KhongDau = n.TenSanPham_KhongDau,
                       
                    });
                return Json(productDetail, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [Route("tim-kiem/thoi-trang/{sex__text}/{categoryid}/{TenSanPham_KhongDau}/{id}.html")]
        public ActionResult ProductSearch(int? id)
        {
            if (id == null)
                return RedirectToAction("Index","Home");

            List<binhluan> bl = db.binhluans.Where(n => n.MaSanPham == id).ToList();
            ViewBag.lbl = bl;
            var model = db.sanphams.Single(n => n.MaSanPham == id);
            return View(model);
        }
    }
}