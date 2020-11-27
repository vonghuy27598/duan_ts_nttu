using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTS.Controllers
{
    public class ChatViewController : Controller
    {
        //
        // GET: /ChatView/
        public ActionResult Index()
        {
            return View();
        }
    }
}