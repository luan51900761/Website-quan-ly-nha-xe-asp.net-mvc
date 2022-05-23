using EF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class HoaDonMNController : BaseController
    {

        protected override void OnActionExecuted(ActionExecutedContext filecontext)
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                Response.Redirect("~/Admin/Login/Index");
            }
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session.ToString()).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")) && !chucvu.Equals(Crypt.convertToUnSign3("Truc Ban")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                filecontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", ares = "Admin " }));
            }
            base.OnActionExecuted(filecontext);
        }
        // GET: Admin/HoaDonMN
        public ActionResult Index()
        {
            HoaDonDao hd = new HoaDonDao();
            var result = hd.ListAll();
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            HoaDonDao hd = new HoaDonDao();
            var result = hd.ListWhereBySdt(keyword);
            return View(result);
        }
        [HttpGet]
        public ActionResult Confirm(int mahd)
        {
            HoaDonDao hd = new HoaDonDao();
            int resultconfirm = hd.Confirm(mahd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int mahd)
        {
            var nv = new HoaDonDao();
            if (nv.Delete(mahd) == 1)
            {
                SetAlert("Xoá thành công", "success");
                return RedirectToAction("Index", "HoaDonMN");

            }
            SetAlert("Xoá không thành công", "error");
            return RedirectToAction("Index", "HoaDonMN");
        }

        public ActionResult Detail(int mahd)
        {
            VeXeDao kg = new VeXeDao();
            var result = kg.ListWhere(mahd);
            return View(result);
        }

    }
}