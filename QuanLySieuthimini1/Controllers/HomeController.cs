using QuanLySieuthimini1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLySieuthimini1.Controllers
{
    public class HomeController : Controller
    {
        ConnectDB db = new ConnectDB(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dangnhap()
        {    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangnhap(string Email, string Matkhau)
        {
            if(ModelState.IsValid)
            {
                var Mahoadulieu = GETMD5(Matkhau);
                var Kiemtrataikhoan = db.Nhanviens.Where(n => n.Email.Equals(Email) && n.Matkhau.Equals(Mahoadulieu)).ToList();
                if(Kiemtrataikhoan != null)
                {
                    Session["idNhanvien"] = Kiemtrataikhoan.FirstOrDefault().Ma_NV;
                    Session["Ten_NV"] = Kiemtrataikhoan.FirstOrDefault().Ten_NV;
                    var checkAdmin = Kiemtrataikhoan.FirstOrDefault().Role;
                    if (checkAdmin == "Admin")
                    {
                        return RedirectToAction("Index", "Homes", new { Areas = "Admin" });
                    } else
                    {
                        return RedirectToAction("Index");
                    }    
                }
                else
                {
                    ViewBag.loginError = "Đăng nhập không thành công";
                    return RedirectToAction("Dangnhap");
                }
            }
            return View();
        }

        public ActionResult Dangki()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangki (Nhanvien nv)
        {
            if(ModelState.IsValid)
            {
                var checkEmail = db.Nhanviens.FirstOrDefault(m => m.Email == nv.Email);
                if(checkEmail == null)
                {
                    nv.Matkhau = GETMD5(nv.Matkhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Nhanviens.Add(nv);
                    db.SaveChanges();
                    return RedirectToAction("Dangnhap");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return View("Dangki");
                }    
            }
            return View();
        }

        public ActionResult Dangxuat()
        {
            Session.Clear();//remove session
            return RedirectToAction("Dangnhap");
        }

        public static string GETMD5(string Matkhau)
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
    }
}