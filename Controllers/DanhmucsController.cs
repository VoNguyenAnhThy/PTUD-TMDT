using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S_me.Models;

namespace S_me.Controllers
{
    public class DanhmucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Danhmucs
        public ActionResult Index()
        {
            return View(db.Danhmucs.ToList());
        }
    }
}
