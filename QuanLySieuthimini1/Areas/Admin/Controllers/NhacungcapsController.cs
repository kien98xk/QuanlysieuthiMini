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
    public class NhacungcapsController : Controller
    {
        private ConnectDB db = new ConnectDB();

        // GET: Admin/Nhacungcaps
        public ActionResult Index()
        {
            return View(db.Nhacungcaps.ToList());
        }

        // GET: Admin/Nhacungcaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhacungcap nhacungcap = db.Nhacungcaps.Find(id);
            if (nhacungcap == null)
            {
                return HttpNotFound();
            }
            return View(nhacungcap);
        }

        // GET: Admin/Nhacungcaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nhacungcaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_NCC,Ten_NCC,Diachi,SĐT,Email")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                db.Nhacungcaps.Add(nhacungcap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhacungcap);
        }

        // GET: Admin/Nhacungcaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhacungcap nhacungcap = db.Nhacungcaps.Find(id);
            if (nhacungcap == null)
            {
                return HttpNotFound();
            }
            return View(nhacungcap);
        }

        // POST: Admin/Nhacungcaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_NCC,Ten_NCC,Diachi,SĐT,Email")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhacungcap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhacungcap);
        }

        // GET: Admin/Nhacungcaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhacungcap nhacungcap = db.Nhacungcaps.Find(id);
            if (nhacungcap == null)
            {
                return HttpNotFound();
            }
            return View(nhacungcap);
        }

        // POST: Admin/Nhacungcaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhacungcap nhacungcap = db.Nhacungcaps.Find(id);
            db.Nhacungcaps.Remove(nhacungcap);
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
