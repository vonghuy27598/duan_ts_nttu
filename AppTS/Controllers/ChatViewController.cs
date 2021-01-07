using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppTS.Controllers
{
    public class ChatViewController : BaseController
    {
        //
        // GET: /ChatView/
        public ActionResult Index()
        {
            return View();
        }

        //ChatBotResponse
        [HttpPost]
        public JsonResult ChatBotResponse(string text)
        {
            string uri = "http://tvhn.ntt.edu.vn:4077/index.html?msg="+text;
            WebClient webClient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            string response = webClient.DownloadString(uri);
            Console.Write(response);
            return Json(new
            {
                status = response
            }, JsonRequestBehavior.AllowGet);
        }
    }
}