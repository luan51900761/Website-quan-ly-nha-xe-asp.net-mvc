using System;
using System.Web.Mvc;

namespace Shop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //KHI METHOD EDIT ĐƯỢC GỌI THÌ THAM SỐ TRUYỀN VÀO MẶC ĐỊNH SẼ ĐC LƯU LÀ USER.
            context.MapRoute(
                "Detail_Product",
                "Admin/{controller}/{action}/{key}",
                new { controller = "Product", action = "Detail", key = UrlParameter.Optional }
            );
            context.MapRoute(
                "Edit_default",
                "Admin/{controller}/{action}/{user}",
                new { controller = "User", action = "Edit", user = UrlParameter.Optional }
            );
            context.MapRoute(
                "Edit_Customer",
                "Admin/{controller}/{action}/{user}",
                new { controller = "Custommer", action = "Edit", user = UrlParameter.Optional }
            );
            /*context.MapRoute(
                "Delete_default",
                "Admin/{controller}/{action}/{username}",
                new { action = "Delete", username = UrlParameter.Optional }
            );*/
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "KiGui",
                "Admin/{controller}/{action}/{makg}",
                new { controler="KiGui",action = "Detail", makg = UrlParameter.Optional }
            );
        }
    }
}