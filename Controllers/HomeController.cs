using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Text;
using Microsoft.AspNet.Identity;
using S_me.Models;

namespace S_me.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sanphams
        public ActionResult Index()
        {
            var sanphams = db.Sanphams.Include(s => s.DanhmucObj).Include(s => s.ThuonghieuObj);
            return View(sanphams.ToList());
        }

        // GET: Sanphams/Details/5
        public ActionResult Chitietsanpham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sanpham sanpham = db.Sanphams.Find(id);

            if (sanpham == null)
            {
                return HttpNotFound();
            }

            // Lấy danh sách sản phẩm liên quan
            var sanphamLienQuans = db.Sanphams.Where(s => s.DanhmucObj.DMID == sanpham.DanhmucObj.DMID && s.SpID != id).ToList();

            // Tạo ViewModel
            var viewModel = new ChitietsanphamViewModel
            {
                Sanphamchinh = sanpham,
                Sanphamlienquans = sanphamLienQuans
            };

            // Trả về view với ViewModel
            return View(viewModel);
        }

        public ActionResult Themvaogiohang(int id)
        {
            //Kiem tra Id sanpham ton tai hay khong
            var sanpham = db.Sanphams.Where(x => x.SpID == id).FirstOrDefault();
            if (sanpham == null)
            {
                return RedirectToAction("Index");
            }
            var Hoadon = this.Session["Donhang"] as Donhang;
            if (Hoadon == null)
            {
                Hoadon = new Donhang();
                Hoadon.NgayLap = DateTime.Now;
                Hoadon.Chitietdonhangs = new List<Chitietdonhang>();
                this.Session["Donhang"] = Hoadon;
                Hoadon.KHID = 1;
                db.Donhangs.Add(Hoadon);
            }

            //Kiem tra don hang da co truoc do
            var Chitiethoadon = Hoadon.Chitietdonhangs.Where(x => x.SanphamObj.SpID == id).FirstOrDefault();
            if (Chitiethoadon == null)
            {
                Chitiethoadon = new Chitietdonhang();
                Chitiethoadon.SpID = id;
                Chitiethoadon.SanphamObj = sanpham;
                Chitiethoadon.DHObj = Hoadon;
                Chitiethoadon.Soluong = 1;
                Hoadon.Chitietdonhangs.Add(Chitiethoadon);
            }
            else
            {
                Chitiethoadon.Soluong++;
            }
            db.SaveChanges();
            return View(Hoadon);
        }

        //public ActionResult Xoakhoigiohang(int SpIDs)
        //{
        //    var Hoadon = this.Session["Đơn hàng"] as Donhang;
        //    var Chitiethoadon = Hoadon.Chitietdonhangs.Where(x => x.SanphamObj.SpID ==
        //    SpIDs).FirstOrDefault();
        //    Hoadon.Chitietdonhangs.Remove(Chitiethoadon);
        //    return View("Themvaogiohang", Hoadon);
        //}
        public ActionResult Xoakhoigiohang(int SpIDs)
        {
            var Hoadon = this.Session["Donhang"] as Donhang;

            if (Hoadon != null)
            {
                var Chitiethoadon = Hoadon.Chitietdonhangs.FirstOrDefault(x => x.SanphamObj.SpID == SpIDs);

                if (Chitiethoadon != null)
                {
                    Hoadon.Chitietdonhangs.Remove(Chitiethoadon);
                }
            }

            return View("Themvaogiohang", Hoadon);
        }
        public PartialViewResult Summary()
        {
            var Hoadon = this.Session["Donhang"] as Donhang;
            if (Hoadon == null)
            {
                return null;
            }
            return PartialView(Hoadon);
        }
        public ActionResult Thanhtoan()
        {
            return View(new Thanhtoan());
        }
        [HttpPost]
        public ActionResult Thanhtoan(Thanhtoan detail)
        {
            var Hoadon = this.Session["Donhang"] as Donhang;
            if (Hoadon.Chitietdonhangs.Count() == 0)
            {
                ModelState.AddModelError("", "Ôi không! Bạn chưa bỏ gì vào giỏ hàng mà!");
            }
            if (ModelState.IsValid)
            {
                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var Chitiethoadon in Hoadon.Chitietdonhangs)
                {
                    var subtotal = Chitiethoadon.SanphamObj.Price * Chitiethoadon.Soluong;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", Chitiethoadon.Soluong,
                    Chitiethoadon.SanphamObj.ProductName,
                    subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", Hoadon.TongTien)
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(detail.Name)
                .AppendLine(detail.Address)
                .AppendLine(detail.Mobile.ToString());
                Email.SendEmail(new IdentityMessage()
                {
                    Destination = detail.Email,
                    Subject = "Đơn hàng thành công!",
                    Body = body.ToString()
                });
                this.Session["Donhang"] = null;
                return View("Thanhtoanthanhcong");
            }
            else
            {
                return View(new Thanhtoan());
            }
        }
    }
}