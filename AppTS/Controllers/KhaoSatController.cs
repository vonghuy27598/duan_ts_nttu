using AppTS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
namespace AppTS.Controllers
{
    public class KhaoSatController : Controller
    {
        //
        // GET: /KhaoSat/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult KhaoSat()
        {

            var model = from a in db.Table_KhaoSats where a.ID_ROOT == 0 select a;
            return View(model);

        }
        [HttpPost]
        public ActionResult KhaoSat(FormCollection form)
        {
                    var getCauHoi = from a in db.Table_KhaoSats where a.ID_ROOT == 0 select a;
                 var getTraLoi = from a in db.Table_KhaoSats where a.ID_ROOT != 0 select a;

                 var hohs = form["hoten"];
                 var sodt = form["sdt"];
                 var Email = form["email"];

                 var hs = new Table_HocSinh();
                 hs.HOTENHS = hohs;
               
                 hs.SDT = sodt;
                 hs.EMAIL = Email;
                 db.Table_HocSinhs.InsertOnSubmit(hs);
                 db.SubmitChanges();

                 if (Request.IsAjaxRequest())
                 {
                 if (Session["User"] != null)
                 {
                 var tk = (HocSinh_TK)Session["User"];
                 foreach (var item in getCauHoi)
                 {
                 Table_ChiTietKhaoSat ct_ks = new Table_ChiTietKhaoSat();
                 ct_ks.ID_KS = item.ID_KS;
                 ct_ks.ID_HS = (int)tk.ID_HS;
                 ct_ks.CAUTRALOI = form[item.ID_KS - 1];
                 db.Table_ChiTietKhaoSats.InsertOnSubmit(ct_ks);
                 db.SubmitChanges();
                 }

                 }
                 else
                 {

                 foreach (var item in getCauHoi)
                 {
                 Table_ChiTietKhaoSat ct_ks = new Table_ChiTietKhaoSat();
                 ct_ks.ID_KS = item.ID_KS;
                 ct_ks.ID_HS = (int)hs.ID_HS;
                 ct_ks.CAUTRALOI = form[item.ID_KS +3];
                 db.Table_ChiTietKhaoSats.InsertOnSubmit(ct_ks);
                 db.SubmitChanges();
                 }


                 }
                 return Json(new { Status = "success", Message = "Cảm ơn bạn đã thực hiện bảng khảo sát này" });
                 }
                 return RedirectToAction("Index", "Home" ) ;
           


        }

        public PartialViewResult GoiYKhaoSat(int ID_KS)
        {
            var model = from a in db.Table_KhaoSats where a.ID_ROOT == ID_KS select a;
            return PartialView(model);
        }

        public ActionResult KhaoSatNTD()
        {
            return View();
        }
        public ActionResult KhaoSatNTD_Khac()
        {
            return View();
        }

        public ActionResult KhaoSatHS()
        {
            return View();
        }

        public ActionResult KhaoSatNangLuc()
        {
            return View();
        }
        public ActionResult KhaoSatTinhHinhSV()
        {
            return View();
        }
        
    }
}