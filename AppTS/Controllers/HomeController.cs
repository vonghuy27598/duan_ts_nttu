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
    public class HomeController : BaseController
    {
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                string userAgent = Request.UserAgent;
                if(!userAgent.Contains("BlackBerry") || !userAgent.Contains("iPhone") || !userAgent.Contains("Android"))
                {

                }
                else
                {
                    Session["Check"] = true;
                }
            }
            return View();
        }
        public ActionResult Error404()
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
                model = from a in db.Table_ChuyenNganhs.OrderBy(m=>m.TENCHUYENNGANH) select a;
            }
            else if (nganh.Equals("2"))
            {
                Session["ct_nganh"] = "2";
               
            }
            else if (nganh.Equals("3"))
            {
                Session["ct_nganh"] = "3";
               
            }
            else if (nganh.Equals("4"))
            {
                Session["ct_nganh"] = "4";
              
            }
            else if (nganh.Equals("5"))
            {
                Session["ct_nganh"] = "5";
               
            }
            else if (nganh.Equals("6"))
            {
                Session["ct_nganh"] = "6";

            }
            else if (nganh.Equals("7"))
            {
                Session["ct_nganh"] = "7";

            }
            else if (nganh.Equals("8"))
            {
                Session["ct_nganh"] = "8";

            }
            else if (nganh.Equals("9"))
            {
                Session["ct_nganh"] = "9";

            }
            ViewData["tohop"] = from a in db.Table_ToHops select a;
            return View(model);
        }

        public ActionResult ChiTietRiengCacNganh(int id)
        {
            var model = Nganh.getChiTietNganh(id);       
            return View(model);
        }

        public ActionResult DangCapNhat()
        {
          
            return View();
        }
        public ActionResult TienIchHocTap()
        {
            return View();
        }
        public ActionResult ChiTietTienIch()
        {
            var nganh = Request.QueryString["id_tienich"];
            if (nganh.Equals("1"))
            {
                Session["ct_tienich"] = "1";
            }
            else if (nganh.Equals("2"))
            {
                Session["ct_tienich"] = "2";

            }
            else if (nganh.Equals("3"))
            {
                Session["ct_tienich"] = "3";

            }
            else if (nganh.Equals("4"))
            {
                Session["ct_tienich"] = "4";

            }
            else if (nganh.Equals("5"))
            {
                Session["ct_tienich"] = "5";

            }
            return View();
        }
        public PartialViewResult part_Thacsi()
        {
            return PartialView();
        }
        public PartialViewResult part_SongNganh()
        {
            return PartialView();
        }
        public PartialViewResult part_LienXuyen()
        {
            return PartialView();
        }
        public PartialViewResult part_TrungCap()
        {
            return PartialView();
        }
        public PartialViewResult part_QuocTe()
        {
            return PartialView();
        }
        public PartialViewResult part_Anh()
        {
            return PartialView();
        }
        public PartialViewResult part_Sinh()
        {
            return PartialView();
        }
        public PartialViewResult part_Ly()
        {
            return PartialView();
        }
        public PartialViewResult part_Hoa()
        {
            return PartialView();
        }
        public PartialViewResult part_Toan()
        {
            return PartialView();
        }
        public ActionResult VongQuanhNTTU()
        {
            return View();
        }
       
        
    }
}