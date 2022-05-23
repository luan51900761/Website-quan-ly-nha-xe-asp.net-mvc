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
    public class TuyenXeController : BaseController
    {

        // GET: Admin/TuyenXe
        public ActionResult Index()
        {
            TuyenXeDao tx = new TuyenXeDao();
            return View(tx.ListAll());
        }
        [HttpPost]
        public ActionResult Index(string keyword)
        {
            TuyenXeDao kg = new TuyenXeDao();
            var result = kg.ListWhereBykeyword(keyword);
            return View(result);
        }
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

        [HttpGet]
        public ActionResult Delete(string matuyen)
        {
            var nv = new TuyenXeDao();
            if (nv.Delete(matuyen) == 1)
            {
                SetAlert("Xoá tuyến xe thành công", "success");
                return RedirectToAction("Index", "TuyenXe");

            }
            SetAlert("Xoá tuyến xe không thành công vui lòng xóa các chuyến liên quan đến xe trước", "error");
            return RedirectToAction("Index", "TuyenXe");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tuyenxe newtx)
        {
            string url = "/Content/img/" + newtx.image;
            newtx.image = url;
            var tx = new TuyenXeDao();
            tx.create(newtx);
            return RedirectToAction("Index");
        }

        public void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success"; break;
                case "warming":
                    TempData["AlertType"] = "alert-danger"; break;
                case "error":
                    TempData["AlertType"] = "alert-danger"; break;
                default:
                    TempData["AlertType"] = ""; break;
            }
        }


        public ActionResult Edit(string matuyen)
        {
            tuyenxe nv = new tuyenxe();
            nv.matuyen = matuyen;
            return View(nv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tuyenxe editObj)
        {
            string url = "/Content/img/" + editObj.image;
            editObj.image = url;
            var nv = new TuyenXeDao();
            nv.Edit(editObj);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Detail(string matuyen)
        {
            TuyenXeDao tx = new TuyenXeDao();
            var result = tx.ListWhere(matuyen);
            result.image = result.image.Trim();
            return View(result);
        }
    }
}