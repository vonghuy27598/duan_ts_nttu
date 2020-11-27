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
    public class AllController : Controller
    {
        //
        // GET: /NghienCuu/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NghienCuuIndex(int id)
        {
            Table_NghienCuu nc = new Table_NghienCuu();
            ViewData["Chitiet"] = NghienCuu.getchitiet_byID(id);
            var model = from a in db.Table_NghienCuus where a.ID_NGHIENCUU == id select a;
            return View(model.Single());
        }
        public ActionResult ListNghienCuu()
        {
            var model = NghienCuu.NghienCuuFull();
            return View(model);
        }
        public ActionResult KhoiNghiepIndex(int id)
        {
            Table_NghienCuu nc = new Table_NghienCuu();
            ViewData["Chitiet"] = KhoiNghiep.getchitiet_byID(id);
            var model = from a in db.Table_KhoiNghieps where a.ID_KHOINGHIEP == id select a;
            return View(model.Single());
        }
        public ActionResult ListKhoiNghiep()
        {
            var model = NghienCuu.NghienCuuFull();
            return View(model);
        }
	}
}