using AppTS.Models;
using AppTS.ViewModels;
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
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {
            var user = (HocSinh_TK)Session["User"];
            if (user != null)
            {
                if (user.USERNAME.ToString().Equals("tvv"))
                {
                    return RedirectToAction("TuVanVien");
                }
                else
                {
                    var model = db.Table_TUVANs.Where(m => m.ID_USERNAME == user.ID_HS && m.USER_DEL == false && m.DA_REP == true);
                    ViewData["ID_USERNAME"] = model.Select(m => m.ID_USERNAME);
                    return View(model);
                }
            }

            return View();
        }


        [HttpPost]
        public JsonResult seenRep(int ID_USERNAME)
        {
            
            foreach(var item in db.Table_TUVANs.Where(m=>m.ID_USERNAME == ID_USERNAME && m.DA_REP == true))
            {
                 var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == item.ID_CAUHOI);
                 tv.USER_DEL = true;
                 UpdateModel(tv);
                 db.SubmitChanges();
            }
           
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TuVanVien()
        {
            var model = from a in db.Table_TUVANs select a;
            return View(model);
        }
        //ChatBotResponse
        [HttpPost]
        public JsonResult ChatBotResponse(string text)
        {
            string uri = "http://tvhn.ntt.edu.vn:4077/index.html?msg=" + text;
            WebClient webClient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            string response = webClient.DownloadString(uri);
            Console.Write(response);
            return Json(new
            {
                status = response
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult saveQuestion(string text)
        {
            var user = (HocSinh_TK)Session["User"];
            Table_TUVAN tv = new Table_TUVAN();

            if (user != null)
            {
                tv.ID_USERNAME = user.ID_HS;
                tv.HOTEN = user.HOTENHS;
                tv.DA_XEM = false;
                tv.DA_REP = false;
                tv.ADMIN_DEL = false;
                tv.USER_DEL = false;
                tv.CAUHOI = text;
                tv.NGAYHOI = DateTime.Now;
                db.Table_TUVANs.InsertOnSubmit(tv);
                db.SubmitChanges();
            }
            return Json(new
            {
                status = tv,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getQuestion(int ID_CAUHOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.DA_XEM = true;
            UpdateModel(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult setQuestion(int ID_CAUHOI, string CAUTRALOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.DA_XEM = true;
            tv.DA_REP = true;
            tv.CAUTRALOI = CAUTRALOI;
            UpdateModel(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult deleteQuestion(int ID_CAUHOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            Guid CartGUID = Guid.NewGuid();

            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.ADMIN_DEL = true;
            UpdateModel(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = CartGUID.ToString(),
            }, JsonRequestBehavior.AllowGet);
        }

    }
}