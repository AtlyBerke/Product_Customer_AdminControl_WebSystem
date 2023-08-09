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

    
    public class CategoryController : Controller
    {
        DB_50DERSMVCEntities db = new DB_50DERSMVCEntities();
        // GET: Category
        public ActionResult Index(int sayfa=1)
        {
            // var kategoriler = db.TBL_KATEGORILER.ToList();
            var kategoriler = db.TBL_KATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(kategoriler);
        }


        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        
        public ActionResult Sil(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(TBL_KATEGORILER p2)
        {
            var kategori = db.TBL_KATEGORILER.Find(p2.KATEGORIID);
            kategori.KATEGORIAD = p2.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}