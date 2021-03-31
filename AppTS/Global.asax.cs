using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace AppTS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //HttpCookie user_noname = Request.Cookies["ID_USER_NONAME"];
            //if (user_noname == null)
            //{
            //    Guid CartGUID = Guid.NewGuid();                
            //    HttpCookie UserCookie = new HttpCookie("ID_USER_NONAME",CartGUID.ToString());
            //    UserCookie.HttpOnly = true;
            //    //Đặt thời hạn cho cookie
            //    UserCookie.Expires = DateTime.MaxValue;
            //    //Lưu thông tin vào cookie
            //    HttpContext.Current.Response.SetCookie(UserCookie);
            //}


            //Guid CartGUID = Guid.NewGuid();    
            //HttpCookie cookie = new HttpCookie("CHATBOT_USER_NONAME");
            
            //cookie.Values.Add("ID_USER_NONAME", CartGUID.ToString());
            //cookie.Expires = DateTime.Now.AddDays(30); //Thoi han cookie
            //HttpContext.Current.Response.AppendCookie(cookie);


        }


    }
}
