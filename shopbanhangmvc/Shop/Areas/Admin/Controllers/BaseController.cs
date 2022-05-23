using EF.DAO;
using Shop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //Check Session
        // GET: Admin/Base
        //Lớp check session chung cho các class
        protected override void OnActionExecuted(ActionExecutedContext filecontext)
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                filecontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", ares = "Admin " }));
            }

            base.OnActionExecuted(filecontext);
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
    }
}