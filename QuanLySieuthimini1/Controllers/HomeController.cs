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
                var Kiemtrataikhoan = db.Nhanviens.Where(n => n.Email.Equals(Email) && n.Matkhau.Equals(Mahoadulieu)).FirstOrDefault();
                if(Kiemtrataikhoan != null)
                {
                    Session["idNhanvien"] = Kiemtrataikhoan.Ma_NV;   
                    Session["Ten_NV"] = Kiemtrataikhoan.Ten_NV;
                    var checkAdmin = Kiemtrataikhoan.Role;
                    if (checkAdmin == "Admin")
                    {
                        return RedirectToAction("Index", "Homes", new { Area = "Admin" });
                    } 
                    else
                    {
                        return RedirectToAction("Index","Homess", new { Area = "Staff"});
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

        public ActionResult Dangxuat()
        {
            Session.Abandon();//remove session
            return Redirect("/Home");
        }
    }
}