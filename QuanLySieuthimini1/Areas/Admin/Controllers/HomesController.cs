using QuanLySieuthimini1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLySieuthimini1.Areas.Admin.Controllers
{
    public class HomesController : Controller
    {
        ConnectDB db = new ConnectDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dangki()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangki(Nhanvien nv)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.Nhanviens.FirstOrDefault(m => m.Email == nv.Email);
                if (checkEmail == null)
                {
                    nv.Matkhau = AdminGETMD5(nv.Matkhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Nhanviens.Add(nv);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return View("Dangki");
                }
            }
            return View();
        }

        public static string AdminGETMD5(string Matkhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(Matkhau);
            byte[] targetData = md5.ComputeHash(fromData);
            string matkhaudamahoa = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                matkhaudamahoa += targetData[i].ToString("x2");

            }
            return matkhaudamahoa;
        }

        
        public ActionResult Dangxuat()
        {
            Session.Abandon();//remove session
            return Redirect("/Home");
        }
    }
}