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
    public class XeController : BaseController
    {
        // GET: Admin/Xe

        protected override void OnActionExecuted(ActionExecutedContext filecontext)
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                Response.Redirect("~/Admin/Login/Index");
            }
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session.ToString()).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                filecontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", ares = "Admin " }));
            }
            base.OnActionExecuted(filecontext);
        }
        public ActionResult Index()
        {
            XeDao tx = new XeDao();
            return View(tx.ListAll());
        }

        [HttpGet]
        public ActionResult Delete(string maxe)
        {
            var nv = new XeDao();
            if (nv.Delete(maxe) == 1)
            {
                SetAlert("Xoá xe thành công", "success");
                return RedirectToAction("Index", "Xe");

            }
            SetAlert("Xoá xe không thành công vui lòng xóa các chuyến liên quan đến xe trước", "error");
            return RedirectToAction("Index", "Xe");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(xe newtx)
        {
            var tx = new XeDao();
            tx.create(newtx);
            return RedirectToAction("Index");
        }
       

        public ActionResult Edit(string maxe)
        {
            xe nv = new xe();
            nv.maxe = maxe;
            return View(nv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(xe editObj)
        {
          
            var nv = new XeDao();
            nv.Edit(editObj);
            return RedirectToAction("Index");

        }
    }
}