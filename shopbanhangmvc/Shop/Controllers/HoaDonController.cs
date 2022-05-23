using EF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "LoginUser");
            }
            string username = session.ToString();
            HoaDonDao hd =  new HoaDonDao();
            var result = hd.ListWhere(username);
            return View(result);
        }

        public ActionResult Delete(int mahd)
        {
            var nv = new HoaDonDao();
            if (nv.Delete(mahd) == 1)
            {
                SetAlert("Xoá thành công", "success");
                return RedirectToAction("Index", "HoaDon");

            }

            SetAlert("Xoá không thành công", "error");
            return RedirectToAction("Index", "HoaDon");
        }
    }
}