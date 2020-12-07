using QuanLySieuthimini1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLySieuthimini1.Areas.Staff.Controllers
{
    public class HomessController : Controller
    {
        ConnectDB db = new ConnectDB();
        // GET: Staff/Homess
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Dangxuat()
        {
            Session.Abandon();//remove session
            return Redirect("/Home");
        }
    }
}