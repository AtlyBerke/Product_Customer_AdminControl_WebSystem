using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DERSTEMVC.Models.Entity;
namespace _50DERSTEMVC.Controllers
{
    public class SatisController : Controller
    {
        DB_50DERSMVCEntities db = new DB_50DERSMVCEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBL_SATISLAR p)
        {
            db.TBL_SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}