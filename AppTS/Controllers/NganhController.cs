using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTS.Controllers
{
    public class NganhController : BaseController
    {
        //
        // GET: /Nganh/
        public ActionResult CacNganhDaoTao()
        {
            return View();
        }

    }
}