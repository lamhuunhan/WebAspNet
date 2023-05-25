using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smart_shop.Models;
using PagedList;

namespace smart_shop.Controllers
{

    using toys.Extensions;
    public class ProductsController : Controller
    {
        smart_shopEntities db = new smart_shopEntities();
        // GET: Products
        [Route("san-pham/{name}-{id}.html")]
        public ActionResult Index(int? id, int? page, string srt, int? sh, string name = "")
        {

            ViewBag.LoaiSP = db.loaisps.ToList();
            int pageNumber = page ?? 1;
            int pageSize = sh ?? 12;
            ViewBag.sh = sh;
            var spall = from all in db.sanphams
                        select all;
            if (id != 0)
                spall = from all in db.sanphams
                        where all.MaLoaiSP == id
                        select all;
            switch (srt)
            {
                case "AZ":
                    spall = spall.OrderBy(n => n.TenSanPham);
                    break;
                case "ZA":
                    spall = spall.OrderByDescending(n => n.TenSanPham);
                    break;
                case "90":
                    spall = spall.OrderByDescending(n => n.DonGia);
                    break;
                case "09":
                    spall = spall.OrderBy(n => n.DonGia);
                    break;
                default:
                    spall = spall.OrderBy(n => n.DonGia);
                    break;
            }
            ViewBag.srt = srt;
            ViewBag.id = id;
            return View(spall.ToPagedList(pageNumber, pageSize));
        }

        [ChildActionOnly]
        public ActionResult Productpartial()
        {
            return PartialView();
        }
        [Route("quy-ong/{categoryName}-{id}.html")]
        public ActionResult Men(int? id, int? page, string srt, int? sh)
        {
            int pageNumber = page ?? 1;
            int pageSize = sh ?? 12;
            ViewBag.sh = sh;
            var spm = from sp in db.sanphams
                      where sp.Man == 1
                      select sp;
            if (id != null)
            {
                spm = from sp in db.sanphams
                      where sp.Man == 1 && sp.MaLoaiSP == id
                      select sp;
            }
            switch (srt)
            {
                case "AZ":
                    spm = spm.OrderBy(n => n.TenSanPham);
                    break;
                case "ZA":
                    spm = spm.OrderByDescending(n => n.TenSanPham);
                    break;
                case "90":
                    spm = spm.OrderByDescending(n => n.DonGia);
                    break;
                case "09":
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
                default:
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
            }
            ViewBag.srt = srt;
            ViewBag.id = id;
            return View(spm.ToPagedList(pageNumber, pageSize));
        }
        [Route("quy-ba/{categoryName}-{id}.html")]
        public ActionResult Women(int? id, int? page, string srt, int? sh)
        {
            int pageNumber = page ?? 1;
            int pageSize = sh ?? 12;
            ViewBag.sh = sh;
            var spm = from sp in db.sanphams
                      where sp.Woman == 1
                      select sp;
            if (id != null)
            {
                spm = from sp in db.sanphams
                      where sp.Woman == 1 && sp.MaLoaiSP == id
                      select sp;
            }
            switch (srt)
            {
                case "AZ":
                    spm = spm.OrderBy(n => n.TenSanPham);
                    break;
                case "ZA":
                    spm = spm.OrderByDescending(n => n.TenSanPham);
                    break;
                case "90":
                    spm = spm.OrderByDescending(n => n.DonGia);
                    break;
                case "09":
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
                default:
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
            }
            ViewBag.srt = srt;
            ViewBag.id = id;
            return View(spm.ToPagedList(pageNumber, pageSize));
        }
        [Route("tim-kiem/")]
        public ActionResult Search(int? id, string q, int? page, string srt, int? sh)
        {
            if (String.IsNullOrEmpty(q))
            {
                var res = db.loaisps.SingleOrDefault(n => n.MaLoaiSP == id);
                if (res != null)
                    return RedirectToAction("Index", new { @id = res.MaLoaiSP, @name = res.Url });
                return RedirectToAction("Index", "Products", new { @id = 0, @name = "tat-ca" });
            }
            int pageNumber = page ?? 1;
            int pageSize = sh ?? 12;
            ViewBag.sh = sh;
            var spm = from sp in db.sanphams
                      where (sp.TenSanPham.Contains(q))
                      select sp;
            if (id != null)
            {
                spm = from sp in db.sanphams
                      where sp.MaLoaiSP == id && (sp.TenSanPham.Contains(q))
                      select sp;
            }
            switch (srt)
            {
                case "AZ":
                    spm = spm.OrderBy(n => n.TenSanPham);
                    break;
                case "ZA":
                    spm = spm.OrderByDescending(n => n.TenSanPham);
                    break;
                case "90":
                    spm = spm.OrderByDescending(n => n.DonGia);
                    break;
                case "09":
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
                default:
                    spm = spm.OrderBy(n => n.DonGia);
                    break;
            }
            if (q != null)
            {
                ViewBag.srt = srt;

                ViewBag.q = q.ToFriendlyUrl();
            }

            return View(spm.ToPagedList(pageNumber, pageSize));
        }
        [Route("san-pham/{categoryName}/{TenSanPham_KhongDau}-{id}.html")]
        public ActionResult Single(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            List<binhluan> bl = db.binhluans.Where(n => n.MaSanPham == id).ToList();
            ViewBag.lbl = bl;
            return View(db.sanphams.Single(n => n.MaSanPham == id));
        }
    }
}