using System;
using EF.DAO;
using EF.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            var tuyenxe = new TuyenXeDao();
            var listSchedule = tuyenxe.ListAll();
            return View(listSchedule);
        }

        
        public ActionResult ListSchedule(string from, string to)
        {
            var chuyenxe = new ChuyenXeDao();
            var listSchedule = chuyenxe.ListAll(from, to);
            return View(listSchedule);
        }
    }
}