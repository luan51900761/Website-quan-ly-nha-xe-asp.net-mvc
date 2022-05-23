using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class ChuyenXeController : BaseController
    {

   
        // GET: Admin/ChuyenXe
        public ActionResult Index()
        {
            ChuyenXeDao tx = new ChuyenXeDao();
            return View(tx.List());
        }
         [HttpPost]
        public ActionResult Index(string keyword)
        {
            ChuyenXeDao kg = new ChuyenXeDao();
            var result = kg.ListWhereBykeyword(keyword);
            return View(result);
        }

        [HttpGet]
        public ActionResult Delete(string machuyen)
        {
            var session = Session[UserDao.USER_SESSION].ToString();
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")) && !chucvu.Equals(Crypt.convertToUnSign3("Truc Ban")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                return RedirectToAction("Index");
            }
                var cx = new ChuyenXeDao();
            if (cx.Delete(machuyen) == 1)
            {
                SetAlert("Xoá chuyến xe thành công", "success");
                return RedirectToAction("Index");

            }
            SetAlert("Xoá tuyến xe không thành công vui lòng xóa các hóa đơn liên quan đến xe trước", "error");
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            var session = Session[UserDao.USER_SESSION].ToString();
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")) && !chucvu.Equals(Crypt.convertToUnSign3("Truc Ban")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                return RedirectToAction("Index");

            }
            var tx = new TuyenXeDao();
            var xe = new XeDao();
            ViewBag.matuyen = tx.getMaTuyen();
            ViewBag.loxe = nv.getLoXe();
            ViewBag.maxe = xe.getMaXe();
            ViewBag.mataixe = nv.getTaiXe();


            return View();
        }

        [HttpPost]
        public ActionResult Create(chuyenxe item)
        {
            var tx = new ChuyenXeDao();
            tx.create(item);
            return RedirectToAction("Index");
        }

        

        public ActionResult Edit(string machuyen)
        {
            var session = Session[UserDao.USER_SESSION].ToString();
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")) && !chucvu.Equals(Crypt.convertToUnSign3("Truc Ban")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                return RedirectToAction("Index");
            }
            chuyenxe cx = new chuyenxe();
            cx.machuyen = machuyen;
            return View(cx);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(chuyenxe editObj)
        {

            var nv = new ChuyenXeDao();
            nv.Edit(editObj);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Detail(string machuyen)
        {
            var session = Session[UserDao.USER_SESSION].ToString();
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")) && !chucvu.Equals(Crypt.convertToUnSign3("Truc Ban")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                return RedirectToAction("Index");
            }
            ChuyenXeDao tx = new ChuyenXeDao();
            var result = tx.ListWhere(machuyen);
            return View(result);
        }
        public ActionResult ListView()
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            string username = session.ToString();
            NhanVienDao nv = new NhanVienDao();
            string manv = nv.getManvByUserName(username);
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(username).Trim());
            ChuyenXeDao tx = new ChuyenXeDao();
           if(chucvu.Equals(Crypt.convertToUnSign3("Lơ Xe"))){
                var result = tx.ListbyManv(manv);
                return View(result);

            }
            else if (chucvu.Equals(Crypt.convertToUnSign3("Tài Xế")))
            {
                var result = tx.ListbyMatx(manv);
                return View(result);

            }
            return View(tx.List());
        }

        public ActionResult ListTicket(string machuyen)
        {
            var VexeDao = new VeXeDao();
            var tx = VexeDao.ListWhereByMaChuyen(machuyen);
            if (tx.Count()==0)
            {
                SetAlert("Danh sách trống", "warming");

                return RedirectToAction("ListView", "ChuyenXe");
            }
            return View(tx);
        }

        public ActionResult ListShipping(string machuyen)
        {
            var KiGuiDao = new KiGuiDao();
            var tx = KiGuiDao.ListWhereByMaChuyen(machuyen);
            if (tx.Count() == 0)
            {
                SetAlert("Danh sách trống", "warming");

                return RedirectToAction("ListView", "ChuyenXe");
            }
            return View(tx);
        }
    }
}