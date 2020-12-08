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
    public class ChitiethanghoasController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Chitiethanghoas
        public ActionResult Index()
        {
            var chitiethanghoas = db.Chitiethanghoas.Include(c => c.Nhomhangs);
            return View(chitiethanghoas.ToList());
        }

        // GET: Admin/Chitiethanghoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethanghoa chitiethanghoa = db.Chitiethanghoas.Find(id);
            if (chitiethanghoa == null)
            {
                return HttpNotFound();
            }
            return View(chitiethanghoa);
        }

        // GET: Admin/Chitiethanghoas/Create
        public ActionResult Create()
        {
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH");
            return View();
        }

        // POST: Admin/Chitiethanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_HH,Ten_HH,GiaMua,GiaBan,Noi_SX,HSD,SoLuongNhap,Ma_NH")] Chitiethanghoa chitiethanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Chitiethanghoas.Add(chitiethanghoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", chitiethanghoa.Ma_NH);
            return View(chitiethanghoa);
        }

        // GET: Admin/Chitiethanghoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethanghoa chitiethanghoa = db.Chitiethanghoas.Find(id);
            if (chitiethanghoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", chitiethanghoa.Ma_NH);
            return View(chitiethanghoa);
        }

        // POST: Admin/Chitiethanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_HH,Ten_HH,GiaMua,GiaBan,Noi_SX,HSD,SoLuongNhap,Ma_NH")] Chitiethanghoa chitiethanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethanghoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", chitiethanghoa.Ma_NH);
            return View(chitiethanghoa);
        }

        // GET: Admin/Chitiethanghoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiethanghoa chitiethanghoa = db.Chitiethanghoas.Find(id);
            if (chitiethanghoa == null)
            {
                return HttpNotFound();
            }
            return View(chitiethanghoa);
        }

        // POST: Admin/Chitiethanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitiethanghoa chitiethanghoa = db.Chitiethanghoas.Find(id);
            db.Chitiethanghoas.Remove(chitiethanghoa);
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
