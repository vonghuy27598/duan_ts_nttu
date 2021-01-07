using AppTS.Areas.Admin.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using AppTS.Areas.Admin.Models.ViewModel;
namespace AppTS.Areas.Admin.Controllers
{
    public class ThanhVienController : BaseController
    {
        //
        // GET: /Admin/ThanhVien/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        //public ActionResult SinhVien()
        //{
        //    var model = SinhVienDAO.getDataSV();
        //    setDDlistNganh();
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult SinhVien(FormCollection form)
        //{
        //    setDDlistNganh();
        //    var ho = form["Ho"];
        //    var ten = form["Ten"];
        //    var gioitinh = form["gioitinh"];
        //    var ngaysinh = form["ngaysinh"];
        //    var sdt = form["sdt"];
        //    var email = form["email"];
        //    var nganh = form["dropdownlist"];
        //    var diachi = form["diachi"];           
        //    var model = (SinhVien)Session["ThongTinSV"];
        //    var sv = db.Table_HocSinhs.First(m => m.ID_HS == model.ID_HS);
        //    sv.HOTENHS = ho+" "+ten;
            
        //    bool gt = false;
        //    if (gioitinh == "Nam")
        //        gt = true;
        //    sv.GIOITINH = gt;
        //    sv.NGAYSINH = DateTime.Parse(ngaysinh);
        //    sv.SDT = sdt;
        //    sv.EMAIL = email;
        //    sv.DIACHI = diachi;
        //    sv.ID_CHUYENNGANH = int.Parse(nganh);
        //    db.SubmitChanges();
        //    var model2 = SinhVienDAO.getDataSV();
        //    return View(model2);
        //}

        ////Show chi tiết sinh viên
        //[HttpPost]
        //public JsonResult ChiTietSV(int ID_SV)
        //{
        //    var result = SinhVienDAO.getDataSV_byID(ID_SV).SingleOrDefault();
        //    Session["ThongTinSV"] = result;
        //    setDDlistNganh(result.ID_CHUYENNGANH);
        //    return Json(new
        //    {
        //        status = result
        //    }, JsonRequestBehavior.AllowGet);
        //}

        ////Xóa sinh viên
        //[HttpPost]
        //public JsonResult deleteSV(int ID_SV)
        //{
        //    var model = db.Table_HocSinhs.SingleOrDefault(m => m.ID_HS == ID_SV);
        //    db.Table_HocSinhs.DeleteOnSubmit(model);
        //    db.SubmitChanges();
        //    var result = true;
        //    return Json(new
        //    {
        //        status = result
        //    }, JsonRequestBehavior.AllowGet);
        //}

        ////dropdown ngành
        //public void setDDlistNganh(int? selectedId = null)
        //{

        //    ViewBag.Nganh = new SelectList(NganhDAO.getChuyenNganh(), "ID_CHUYENNGANH", "TENCHUYENNGANH", selectedId);
        //}

        //[HttpPost]
        //public JsonResult ChangeSinhVienTheoNganh(int ID_NGANH)
        //{
        //    var result = SinhVienDAO.getSinhVien_byIDNGANH(ID_NGANH);
        //    return Json(new
        //    {
        //        status = result
        //    }, JsonRequestBehavior.AllowGet);
        //}
	}
}