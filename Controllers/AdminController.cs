using S_me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Text;
using System.Web.Security;
namespace S_me.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationDbContext db = new ApplicationDbContext();
            var dataItem = db.Admins.Where(x => x.UserAdmin == model.UserAdmin && x.PassAdmin == model.PassAdmin).SingleOrDefault();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.UserAdmin, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.");
                return View(model);
            }
        }

        // Thuộc Sản phẩm
        public ActionResult QLSanpham()
        {
            return View(db.Sanphams.ToList());
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
            return View(sanpham);
        }

        // GET: Sanphams/Create
        public ActionResult SpThem()
        {
            ViewBag.CatID = new SelectList(db.Danhmucs, "DMID", "Name");
            ViewBag.BrandID = new SelectList(db.Thuonghieux, "ThuonghieuID", "Name");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpThem([Bind(Include = "SpID,ProductName,Price,Summary,Rated,Storage,CatID,BrandID")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                sanpham.Picture = new byte[sanpham.PictureUpload.ContentLength];
                sanpham.PictureUpload.InputStream.Read(sanpham.Picture, 0, sanpham.PictureUpload.ContentLength);

                sanpham.Picture2 = new byte[sanpham.PictureUpload2.ContentLength];
                sanpham.PictureUpload2.InputStream.Read(sanpham.Picture2, 0, sanpham.PictureUpload2.ContentLength);

                db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("QLSanpham");
            }

            ViewBag.CatID = new SelectList(db.Danhmucs, "DMID", "Name", sanpham.CatID);
            ViewBag.BrandID = new SelectList(db.Thuonghieux, "ThuonghieuID", "Name", sanpham.BrandID);
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public ActionResult SpSua(int? id)
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
            ViewBag.CatID = new SelectList(db.Danhmucs, "DMID", "Name", sanpham.CatID);
            ViewBag.BrandID = new SelectList(db.Thuonghieux, "ThuonghieuID", "Name", sanpham.BrandID);
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpSua([Bind(Include = "SpID,ProductName,Price,Summary,Picture,Picture2,Rated,Storage,CatID,BrandID")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLSanpham");
            }
            ViewBag.CatID = new SelectList(db.Danhmucs, "DMID", "Name", sanpham.CatID);
            ViewBag.BrandID = new SelectList(db.Thuonghieux, "ThuonghieuID", "Name", sanpham.BrandID);
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public ActionResult SpXoa(int? id)
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
            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            db.Sanphams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Kết thúc sản phẩm



        // Thuộc Thương hiệu
        public ActionResult QLThuonghieu()
        {
            return View(db.Thuonghieux.ToList());
        }
        // GET: Thuonghieux/Details/5
        public ActionResult THChitiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu thuonghieu = db.Thuonghieux.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // GET: Thuonghieux/Create
        public ActionResult THThem()
        {
            return View();
        }

        // POST: Thuonghieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult THThem([Bind(Include = "ThuonghieuID,Name")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.Thuonghieux.Add(thuonghieu);
                db.SaveChanges();
                return RedirectToAction("QLThuonghieu");
            }

            return View(thuonghieu);
        }

        // GET: Thuonghieux/Edit/5
        public ActionResult THSua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu thuonghieu = db.Thuonghieux.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: Thuonghieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult THSua([Bind(Include = "ThuonghieuID,Name")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuonghieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLThuonghieu");
            }
            return View(thuonghieu);
        }

        // GET: Thuonghieux/Delete/5
        public ActionResult THXoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu thuonghieu = db.Thuonghieux.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: Thuonghieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTH(int id)
        {
            Thuonghieu thuonghieu = db.Thuonghieux.Find(id);
            db.Thuonghieux.Remove(thuonghieu);
            db.SaveChanges();
            return RedirectToAction("QLThuonghieu");
        }
        //Kết thúc thương hiệu



        // Thuộc Danh mục
        public ActionResult QLDanhmuc()
        {
            return View(db.Danhmucs.ToList());
        }
        // GET: Danhmucs/Details/5
        public ActionResult DMChitiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // GET: Danhmucs/Create
        public ActionResult DMThem()
        {
            return View();
        }

        // POST: Danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DMThem([Bind(Include = "DMID,Name")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Danhmucs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("QLDanhmuc");
            }

            return View(danhmuc);
        }

        // GET: Danhmucs/Edit/5
        public ActionResult DMSua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DMSua([Bind(Include = "DMID,Name")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLDanhmuc");
            }
            return View(danhmuc);
        }

        // GET: Danhmucs/Delete/5
        public ActionResult DMXoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        // POST: Danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedDM(int id)
        {
            Danhmuc danhmuc = db.Danhmucs.Find(id);
            db.Danhmucs.Remove(danhmuc);
            db.SaveChanges();
            return RedirectToAction("QLDanhmuc");
        }
        //Kết thúc danh mục



        // Thuộc Form
        public ActionResult ViewForm()
        {
            return View(db.Forms.ToList());
        }
        // GET: Forms/Details/5
        public ActionResult FormChitiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // GET: Forms/Create
        public ActionResult FormThem()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormThem([Bind(Include = "formID,CustomerName,CustomerEmail,CustomerPhone,CustomerMessage")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form);
                db.SaveChanges();
                return RedirectToAction("ViewForm");
            }

            return View(form);
        }

        // GET: Forms/Edit/5
        public ActionResult FormSua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSua([Bind(Include = "formID,CustomerName,CustomerEmail,CustomerPhone,CustomerMessage")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewForm");
            }
            return View(form);
        }

        // GET: Forms/Delete/5
        public ActionResult FormXoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedForm(int id)
        {
            Form form = db.Forms.Find(id);
            db.Forms.Remove(form);
            db.SaveChanges();
            return RedirectToAction("ViewForm");
        }
        //Kết thúc Form

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
