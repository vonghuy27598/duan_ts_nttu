using AppTS.XuLy;
using System.Web.Mvc;

namespace AppTS.Controllers
{
    public class TuVanController : Controller
    {
        //
        // GET: /TuVan/
        public ActionResult DuDoan()
        {
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
                return RedirectToAction("DangNhap", "HocSinh");
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
            var result = list_nganh;
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}