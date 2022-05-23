using EF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    //Check session by BaseController
    public class HomeController : BaseController     //Check session by BaseController

    {
        // GET: Admin/Home
        //TẠO VIEW
       
        public ActionResult Index()
        {
            var session = Session[UserDao.USER_SESSION];
               if(session == null)
                {
                return RedirectToAction("Login", "Index");
                }
            var us = new UserDao();
            string cv = us.FindCV(session.ToString());
            if (cv.Trim().Equals("Custommer"))
            {
                Session[UserDao.USER_SESSION] = null;
                return RedirectToAction("Login", "Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session[UserDao.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
            
        }
        public ActionResult Detail()
        {
            NhanVienDao nv = new NhanVienDao();
            var result1 = nv.ListWhereByUserName(Session[UserDao.USER_SESSION].ToString());
            return View(result1);
            
        }
    }
}