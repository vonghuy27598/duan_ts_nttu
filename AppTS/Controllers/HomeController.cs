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
    public class HomeController : Controller
    {
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult DangKyXetTuyen()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult MoTaNganh(int id)
        {
            Table_Nganh ng = new Table_Nganh();
            var model = Nganh.NganhFull_byID(id);
            return View(model.Single());
        }
        public ActionResult MoTaChuyenNganh(int id)
        {
            Table_ChuyenNganh cn = new Table_ChuyenNganh();
            ViewData["Chitiet"] = CNganh.getChiTiet_ByIDCN(id);
            //Get tên chuyên ngành by id ngành
            var model = from a in db.Table_ChuyenNganhs where a.ID_CHUYENNGANH == id select a;
            return View(model.Single());
        }
        public PartialViewResult Header()
        {
            var model = Nganh.NganhFull();
            return PartialView(model);
        }
        public PartialViewResult Header_TuVan()
        {

            return PartialView();
        }
        public PartialViewResult Header_KhaoSat()
        {

            return PartialView();
        }
        public PartialViewResult Menu(int id)
        {
            var model = CNganh.ChuyenNganhFull_byID_select(id);
            return PartialView(model);

        }
        public ActionResult PhuongAnTS()
        {
            return View();
        }
        public ActionResult CacNganhDaoTao()
        {
            return View();
        }
        public ActionResult ChiTietCacNganh()
        {
            var nganh = Request.QueryString["id_nganh"];
            var model = from a in db.Table_ChuyenNganhs select a;
            if(nganh.Equals("1"))
            {
                Session["ct_nganh"] = "1";
                model = from a in db.Table_ChuyenNganhs where a.ID_NGANH == 1 select a;
            }
            else if (nganh.Equals("2"))
            {
                Session["ct_nganh"] = "2";
                model = from a in db.Table_ChuyenNganhs where a.ID_NGANH == 2 select a;
            }
            else if (nganh.Equals("3"))
            {
                Session["ct_nganh"] = "3";
                model = from a in db.Table_ChuyenNganhs where a.ID_NGANH == 3 select a;
            }
            else if (nganh.Equals("4"))
            {
                Session["ct_nganh"] = "4";
                model = from a in db.Table_ChuyenNganhs where a.ID_NGANH == 1002 select a;
            }
            else if (nganh.Equals("5"))
            {
                Session["ct_nganh"] = "5";
                model = from a in db.Table_ChuyenNganhs where a.ID_NGANH == 1003 select a;
            }
            ViewData["tohop"] = from a in db.Table_ToHops select a;
            return View(model);
        }
        public ActionResult ChinhSachHocBong()
        {
            return View();
        }
        public ActionResult VongQuanhNTTU()
        {
            return View();
        }
       
        
    }
}