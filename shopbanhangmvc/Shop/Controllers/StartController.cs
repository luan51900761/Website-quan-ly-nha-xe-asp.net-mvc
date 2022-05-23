using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.DAO;
using System.Web.Mvc;
using Shop.Areas.Admin.Controllers;

namespace Shop.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            var user = new TuyenXeDao();
            var tuyenxes = user.ListAll();
            return View(tuyenxes);
        }

        [HttpPost]
        public ActionResult Index(string from, string to)
        {
            return RedirectToAction("ListSchedule", "Schedule", new { from = from, to = to });
        }

        public ActionResult Pay()
        {
       
            return View();
        }

        public ActionResult BusStation()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session[UserDao.USER_SESSION] = null;
            return RedirectToAction("Index", "LoginUser");

        }
        public ActionResult About()
        {
          
            return View();
        }

        public ActionResult PaidBillDeleteAlert()
        {

            return View();
        }
        public ActionResult Rules()
        {

            return View();
        }

    }
}