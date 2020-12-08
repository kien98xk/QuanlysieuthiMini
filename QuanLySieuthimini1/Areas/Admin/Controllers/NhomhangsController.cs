﻿using System;
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
    public class NhomhangsController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Nhomhangs
        public ActionResult Index()
        {
            return View(db.Nhomhangs.ToList());
        }

        // GET: Admin/Nhomhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomhang nhomhang = db.Nhomhangs.Find(id);
            if (nhomhang == null)
            {
                return HttpNotFound();
            }
            return View(nhomhang);
        }

        // GET: Admin/Nhomhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nhomhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_NH,Ten_NH")] Nhomhang nhomhang)
        {
            if (ModelState.IsValid)
            {
                db.Nhomhangs.Add(nhomhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomhang);
        }

        // GET: Admin/Nhomhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomhang nhomhang = db.Nhomhangs.Find(id);
            if (nhomhang == null)
            {
                return HttpNotFound();
            }
            return View(nhomhang);
        }

        // POST: Admin/Nhomhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_NH,Ten_NH")] Nhomhang nhomhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomhang);
        }

        // GET: Admin/Nhomhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomhang nhomhang = db.Nhomhangs.Find(id);
            if (nhomhang == null)
            {
                return HttpNotFound();
            }
            return View(nhomhang);
        }

        // POST: Admin/Nhomhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhomhang nhomhang = db.Nhomhangs.Find(id);
            db.Nhomhangs.Remove(nhomhang);
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
