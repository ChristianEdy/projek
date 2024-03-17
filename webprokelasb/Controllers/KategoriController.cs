using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webprokelasb.Entitas;
using webprokelasb.Models;

namespace webprokelasb.Controllers
{
    public class KategoriController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Kategori
        public ActionResult Index()
        {
            var listkategori = db.Tblkategori.ToList();
            return View(listkategori);
        }
        public ActionResult Tambah()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tambah(Kategori model)
        {
            if(model !=null)
            {
                Kategori kategori1 = new Kategori
                {
                    KodeKategori = model.KodeKategori,
                    NamaKategori = model.NamaKategori
                };
                db.Tblkategori.Add(kategori1);
                db.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detil(string KodeKategori)
        {
            Kategori kategori = db.Tblkategori.Find(KodeKategori);
            return View(kategori);
        }
        public ActionResult Ubah(string kodeKategori)
        {
            Kategori kategori = db.Tblkategori.Find(kodeKategori);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult Ubah(Kategori kategori)
        {
            Kategori kategoriBaru = db.Tblkategori.Find(kategori.KodeKategori);
            if (kategoriBaru != null)
            {
               
                kategoriBaru.NamaKategori = kategori.NamaKategori;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Hapus(string kodeKategori)
        {
            Kategori kategori = db.Tblkategori.Find(kodeKategori);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult ConfirmHapus(Kategori kategori)
        {
            Kategori kategoriHapus = db.Tblkategori.Find(kategori.KodeKategori);
            if (kategoriHapus != null)
            {
                db.Tblkategori.Remove(kategoriHapus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Hapus");
        }
    }
}