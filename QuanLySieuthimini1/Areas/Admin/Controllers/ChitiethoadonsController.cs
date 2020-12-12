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
    public class ChitiethoadonsController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Chitiethoadons
        public ActionResult Index()
        {
            var chitiethoadons = db.Chitiethoadons.Include(c => c.Hoadon);
            return View(chitiethoadons.ToList());
        }

        // GET: Admin/Chitiethoadons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethoadon chitiethoadon = db.Chitiethoadons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadon);
        }

        // GET: Admin/Chitiethoadons/Create
        public ActionResult Create()
        {
            ViewBag.Ma_HD = new SelectList(db.Hoadons, "Ma_HD", "Ma_HD");
            return View();
        }

        // POST: Admin/Chitiethoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_CTHD,Ma_HD,Ten_HH,Soluong,Gia")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                db.Chitiethoadons.Add(chitiethoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_HD = new SelectList(db.Hoadons, "Ma_HD", "Ma_HD", chitiethoadon.Ma_HD);
            return View(chitiethoadon);
        }

        // GET: Admin/Chitiethoadons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethoadon chitiethoadon = db.Chitiethoadons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_HD = new SelectList(db.Hoadons, "Ma_HD", "Ma_HD", chitiethoadon.Ma_HD);
            return View(chitiethoadon);
        }

        // POST: Admin/Chitiethoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_CTHD,Ma_HD,Ten_HH,Soluong,Gia")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_HD = new SelectList(db.Hoadons, "Ma_HD", "Ten_HH", chitiethoadon.Ma_HD);
            return View(chitiethoadon);
        }

        // GET: Admin/Chitiethoadons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethoadon chitiethoadon = db.Chitiethoadons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadon);
        }

        // POST: Admin/Chitiethoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitiethoadon chitiethoadon = db.Chitiethoadons.Find(id);
            db.Chitiethoadons.Remove(chitiethoadon);
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
