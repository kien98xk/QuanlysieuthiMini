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
    public class HanghoasController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Hanghoas
        public ActionResult Index()
        {
            var hanghoas = db.Hanghoas.Include(h => h.Nhacungcap).Include(h => h.Nhomhang);
            return View(hanghoas.ToList());
        }

        // GET: Admin/Hanghoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // GET: Admin/Hanghoas/Create
        public ActionResult Create()
        {
            ViewBag.Ma_NCC = new SelectList(db.Nhacungcaps, "Ma_NCC", "Ten_NCC");
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH");
            return View();
        }

        // POST: Admin/Hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_HH,Ma_NCC,Ma_NH,Ten_HH")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Hanghoas.Add(hanghoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_NCC = new SelectList(db.Nhacungcaps, "Ma_NCC", "Ten_NCC", hanghoa.Ma_NCC);
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", hanghoa.Ma_NH);
            return View(hanghoa);
        }

        // GET: Admin/Hanghoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_NCC = new SelectList(db.Nhacungcaps, "Ma_NCC", "Ten_NCC", hanghoa.Ma_NCC);
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", hanghoa.Ma_NH);
            return View(hanghoa);
        }

        // POST: Admin/Hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_HH,Ma_NCC,Ma_NH,Ten_HH")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanghoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_NCC = new SelectList(db.Nhacungcaps, "Ma_NCC", "Ten_NCC", hanghoa.Ma_NCC);
            ViewBag.Ma_NH = new SelectList(db.Nhomhangs, "Ma_NH", "Ten_NH", hanghoa.Ma_NH);
            return View(hanghoa);
        }

        // GET: Admin/Hanghoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // POST: Admin/Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            db.Hanghoas.Remove(hanghoa);
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
