using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySieuthimini1.Models;

namespace QuanLySieuthimini1.Areas.Admin.Controllers
{
    public class HoadonsController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Hoadons
        public ActionResult Index()
        {
            var hoadons = db.Hoadons.Include(h => h.Hanghoa).Include(h => h.Nhanvien);
            return View(hoadons.ToList());
        }

        // GET: Admin/Hoadons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // GET: Admin/Hoadons/Create
        public ActionResult Create()
        {
            
            

            var context = new ConnectDB();
            var HanghoaSelect = new SelectList(context.Hanghoas, "Ten_HH", "Ten_HH");
            ViewBag.Ten_HH = HanghoaSelect;
            ViewBag.Ma_NV = new SelectList(db.Nhanviens, "Ma_NV", "Ten_NV");
            return View();
        }

        // POST: Admin/Hoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_HD,Ma_HH,Ten_HH,Ma_NV,TongTien,Trangthai,Ngaytaohoadon")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Hoadons.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_HH = new SelectList(db.Hanghoas, "Ma_HH", "Ten_HH", hoadon.Ma_HH);
            ViewBag.Ma_NV = new SelectList(db.Nhanviens, "Ma_NV", "Ten_NV", hoadon.Ma_NV);
            return View(hoadon);
        }

        // GET: Admin/Hoadons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_HH = new SelectList(db.Hanghoas, "Ma_HH", "Ten_HH", hoadon.Ma_HH);
            ViewBag.Ma_NV = new SelectList(db.Nhanviens, "Ma_NV", "Ten_NV", hoadon.Ma_NV);
            return View(hoadon);
        }

        // POST: Admin/Hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_HD,Ma_HH,Ten_HH,Ma_NV,TongTien,Trangthai,Ngaytaohoadon")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_HH = new SelectList(db.Hanghoas, "Ten_HH", "Ten_HH", hoadon.Ten_HH);
            ViewBag.Ma_NV = new SelectList(db.Nhanviens, "Ten_NV", "Ten_NV", hoadon.Nhanvien.Ten_NV);
            return View(hoadon);
        }

        // GET: Admin/Hoadons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: Admin/Hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoadon hoadon = db.Hoadons.Find(id);
            db.Hoadons.Remove(hoadon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
