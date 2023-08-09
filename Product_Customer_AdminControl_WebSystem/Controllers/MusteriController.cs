using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DERSTEMVC.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace _50DERSTEMVC.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DB_50DERSMVCEntities db = new DB_50DERSMVCEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var musteri = db.TBL_MUSTERILER.ToList();
            var musteri = db.TBL_MUSTERILER.ToList().ToPagedList(sayfa, 4);
            return View(musteri);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_MUSTERILER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            db.TBL_MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriBilgiGetir(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            return View(musteri);
        }

        public ActionResult Guncelle(TBL_MUSTERILER p2)
        {
            var musteri = db.TBL_MUSTERILER.Find(p2.MUSTERIID);
            musteri.MUSTERIAD = p2.MUSTERIAD;
            musteri.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}