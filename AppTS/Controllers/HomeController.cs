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
    }
}