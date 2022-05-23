using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class KiGuiController : BaseController
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
                SetAlert("bạn không có quyền truy cập vào trang này","error");
                filecontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", ares = "Admin " }));
            }
            base.OnActionExecuted(filecontext);
        }
        // GET: Admin/KiGui
        public ActionResult Index()
        {
            KiGuiDao kg = new KiGuiDao();
            var result = kg.ListAll();
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            KiGuiDao kg = new KiGuiDao();
            var result = kg.ListWhereBySdt(keyword);
            return View(result);
        }

        public ActionResult Detail(int makg)
        {
            KiGuiDao kg = new KiGuiDao();
            var result = kg.ListWhere(makg);
            return View(result);
        }

        public ActionResult Delete(int makg)
        {
            KiGuiDao kg = new KiGuiDao();
            var result = kg.Delete(makg);
            if(result == 0)
            {
                SetAlert("Xóa kí gửi không thành công", "error");
                return RedirectToAction("Index", "KiGui");
            }
            SetAlert("Xóa kí gửi thành công", "success");
            return RedirectToAction("Index", "KiGui");
        }

        public ActionResult Create()
        {
            var chuyenxeDao = new ChuyenXeDao();
            ViewBag.machuyen = chuyenxeDao.getMaChuyen();
            return View();
        }

        [HttpPost]
        public ActionResult Create(kigui kigui)
        {
            var kg = new KiGuiDao();
            NhanVienDao nv = new NhanVienDao();
            kigui.nvsuly = nv.getManvByUserName(Session[UserDao.USER_SESSION].ToString());
            var result = kg.create(kigui);
            return RedirectToAction("Index", "KiGui");
        }
    }
}