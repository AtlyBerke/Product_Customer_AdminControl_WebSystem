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
    public class UrunController : Controller
    {
        // GET: Urun
        DB_50DERSMVCEntities db = new DB_50DERSMVCEntities();
        public ActionResult Index(int sayfa=1)
        {
            var urun = db.TBL_URUNLER.ToList().ToPagedList(sayfa, 4);
            return View(urun);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORILER.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString()}).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniUrun(TBL_URUNLER p3)
        {
            var ktgr = db.TBL_KATEGORILER.Where(m => m.KATEGORIID == p3.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            p3.TBL_KATEGORILER = ktgr;
            db.TBL_URUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunSil(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORILER.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);

        }

        public ActionResult Guncelle(TBL_URUNLER p1)
        {
            var urun = db.TBL_URUNLER.Find(p1.URUNID); //ürün id'ye göre bul
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            var ktgr = db.TBL_KATEGORILER.Where(m => m.KATEGORIID == p1.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktgr.KATEGORIID;//***
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}