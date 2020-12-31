using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using AppTS.ViewModels;
using AppTS.XuLy;

namespace AppTS.Controllers
{
    public class TuVanController : Controller
    {
        //
        // GET: /TuVan/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult DuDoan()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("DangNhap", "HocSinh", new { link = "dudoan" });
            }
            return View();
        }
        public ActionResult TuVanChonNganh()
        {
            return View();
        }
        public ActionResult TuVanChonNgheNghiep()
        {
            return View();
        }
        public ActionResult TuVanChonTruong()
        {
            return View();
        }
        public ActionResult DinhHuong()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("DangNhap", "HocSinh", new {link="dinhhuong" });
            }
            return View();
        }
        public ActionResult TamLy()
        {
            return View();
        }
        public ActionResult TinhCach()
        {
            return View();
        }

        //getNganh_TheoDiem
        [HttpPost]
        public JsonResult getNganh_TheoDiem(double toan,double ly,double hoa,double van,double su, double dia, double sinh, double anh)
        {
            DHNN getList = new DHNN();
            getList.set_Diem(toan,ly,hoa,van,su,dia,sinh,anh);
           
            string[] list_nganh = getList.get_list_Nganh();
                  
            if(list_nganh !=null )
            {
                int count = list_nganh.Length;
                List<ChuyenNganh> list_linkidnganh = new List<ChuyenNganh>();
                //list_linkidnganh = Nganh.getID_CHUYENNGANH_BYTENCHUYENNGANH(list_nganh);              
                foreach (var item in list_nganh)
                {
                    var model = db.Table_ChuyenNganhs.Where(m=>m.TENCHUYENNGANH == item).Select(m=>m.ID_CHUYENNGANH);
                    list_linkidnganh.Add(new ChuyenNganh{ID_CHUYENNGANH = int.Parse(model.ToString())});                    
                }                 
                var result = list_nganh;
               
                return Json(new
                {
                    status = result,
                    list_id = list_linkidnganh
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = list_nganh;
                return Json(new
                {
                    status = result
                  
                }, JsonRequestBehavior.AllowGet);
            }
           
           
           
        }
    }
}