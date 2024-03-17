using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webprokelasb.Entitas;
using webprokelasb.Models;

namespace webprokelasb.Controllers
{
    public class BarangController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Barang
        public ActionResult Index()
        {
            var listbarang = db.Tblbarang.ToList();
            return View(listbarang);
        }
        public ActionResult Tambah()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tambah(Barang model)
        {
            if (model !=null)
            {
                Barang barang1 = new Barang();
                barang1.KodeBarang = model.KodeBarang;
                barang1.NamaBarang = model.NamaBarang;
                barang1.harga = model.harga;
                barang1.Stok = model.Stok;
                db.Tblbarang.Add(barang1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Detil(string kodebarang)
        {
            Barang detilbarang = db.Tblbarang.Find(kodebarang);
            return View(detilbarang);
        }
        public ActionResult Ubah(string kodebarang)
        {
            Barang barang = db.Tblbarang.Find(kodebarang);
            return View(barang);
        }
        [HttpPost]
        public ActionResult Ubah(Barang barang1)
        {
            Barang Ubahbarang = db.Tblbarang.Find(barang1.KodeBarang);
            if (Ubahbarang != null)
            {
                Ubahbarang.NamaBarang = barang1.NamaBarang;
                Ubahbarang.harga = barang1.harga;
                Ubahbarang.Stok = barang1.Stok;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Hapus(string kodebarang)
        {
            Barang hapusbarang = db.Tblbarang.Find(kodebarang);
            return View(hapusbarang);
        }
        [HttpPost]
        public ActionResult Hapus(Barang barang1)
        {
            Barang baranghapus = db.Tblbarang.Find(barang1.KodeBarang);
            if (baranghapus !=null)
            {
                db.Tblbarang.Remove(baranghapus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}