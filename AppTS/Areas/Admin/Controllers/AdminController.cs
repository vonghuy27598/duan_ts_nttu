using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTS.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/Home/
        public ActionResult TrangChu()
        {
            return View();
        }
        public PartialViewResult HeaderAdmin()
        {
            return PartialView();
        }
        public PartialViewResult ttQuanTri()
        {
            return PartialView();
        }
	}
}