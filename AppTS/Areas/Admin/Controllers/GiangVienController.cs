using AppTS.Areas.Admin.Models.DAO;
using AppTS.Areas.Admin.Models.ViewModel;
using AppTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTS.Areas.Admin.Controllers
{
    public class GiangVienController : BaseController
    {
        //
        // GET: /Admin/GiangVien/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        #region Giảng viên khoa CNTT
        public ActionResult GiangVienKhoa()
        {
            var model = GiangVienDAO.getDataGV_KHOA();
            //setDDlistNganh();
            return View(model);
        }

        //Sửa thông tin giảng viên
        [HttpPost]
        public ActionResult GiangVienKhoa(FormCollection form)
        {
            //setDDlistNganh();
            var ho = form["Ho"];
            var ten = form["Ten"];
            var gioitinh = form["gioitinh"];
            var ngaysinh = form["ngaysinh"];
            var sdt = form["sdt"];
            var email = form["email"];
            //var nganh = form["dropdownlist"];
            var diachi = form["diachi"];
            var model = (GiangVien)Session["ThongTinGV"];
            var gv = db.Table_GiangViens.First(m => m.ID_GV == model.ID_GV);
            gv.HOGV = ho;
            gv.TENGV = ten;
            bool gt = false;
            if (gioitinh == "Nam")
                gt = true;
            gv.GIOITINH = gt;
            gv.NGAYSINH = DateTime.Parse(ngaysinh);
            gv.SDT = sdt;
            gv.EMAIL = email;
            gv.DIACHI = diachi;
            gv.HOCVI = form["hocvi"];
            //gv.ID_CHUYENNGANH = int.Parse(nganh);
            db.SubmitChanges();
            var model2 = GiangVienDAO.getDataGV_KHOA();
            return View(model2);
        }
        [HttpPost]
        public ActionResult addGiangVien(FormCollection form)
        {
            Table_GiangVien tb_gv = new Table_GiangVien();
            tb_gv.ID_GV = int.Parse(form["Add_ID"].ToString());
            tb_gv.HOGV = form["Add_Ho"];
            tb_gv.TENGV = form["Add_Ten"];
            var gioitinh = form["Add_gioitinh"];
            bool gt = false;
            if (gioitinh == "Nam")
                gt = true;
            tb_gv.GIOITINH = gt;
            tb_gv.NGAYSINH = DateTime.Parse(form["Add_ngaysinh"]);
            tb_gv.SDT = form["Add_sdt"];
            tb_gv.EMAIL = form["Add_email"];
            tb_gv.DIACHI = form["Add_diachi"];
            tb_gv.HOCVI = form["Add_hocvi"];
            db.Table_GiangViens.InsertOnSubmit(tb_gv);
            db.SubmitChanges();
            var model2 = GiangVienDAO.getDataGV_KHOA();
            return RedirectToAction("GiangVienKhoa", model2);
        }


        //dropdown ngành
        //public void setDDlistNganh(int? selectedId = null)
        //{

        //    ViewBag.Nganh = new SelectList(NganhDAO.getChuyenNganh(), "ID_CHUYENNGANH", "TENCHUYENNGANH", selectedId);
        //}


        //Show chi tiết giảng viên
        [HttpPost]
        public JsonResult ChiTietGV(int ID_GV)
        {
            var result = GiangVienDAO.getDataGV_KHOA_byIDGV(ID_GV).SingleOrDefault();
            Session["ThongTinGV"] = result;
            //setDDlistNganh(result.ID_CHUYENNGANH);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }


        //Xóa giảng viên
        [HttpPost]
        public JsonResult deleteGV(int ID_GV)
        {
            var model = db.Table_GiangViens.SingleOrDefault(m => m.ID_GV == ID_GV);
            db.Table_GiangViens.DeleteOnSubmit(model);
            db.SubmitChanges();
            var result = true;
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult ChangeGiangVienTheoNganh(int ID_NGANH)
        //{
        //    var result = GiangVienDAO.getDataGV_KHOA_byNganh(ID_NGANH);
        //    return Json(new
        //    {
        //        status = result
        //    }, JsonRequestBehavior.AllowGet);
        //}
        #endregion



        #region
        public ActionResult GiangVienDoanhNghiep()
        {
            var model = GiangVienDAO.getDataGV_DOANHNGHIEP();
            ViewData["getGVDN"] = model;
            return View();
        }

        //Sửa thông tin giảng viên
        [HttpPost]
        public ActionResult GiangVienDoanhNghiep(GiangVien giangvien)
        {

            //var ho = form["Ho"];
            //var ten = form["Ten"];
            //var gioitinh = form["gioitinh"];
            //var ngaysinh = form["ngaysinh"];
            //var sdt = form["sdt"];
            //var email = form["email"];

            //var diachi = form["diachi"];
            var model = (GiangVien)Session["ThongTinGVDoanhNghiep"];
            var gv = db.Table_GiangVienDNs.First(m => m.ID_GVDN == model.ID_GV);
            gv.HOGVDN = giangvien.HOGV;
            gv.TENGVDN = giangvien.TENGV;

            gv.GIOITINH = giangvien.GIOITINH;
            gv.NGAYSINH = giangvien.NGAYSINH;
            gv.SDT = giangvien.SDT;
            gv.EMAIL = giangvien.EMAIL;
            gv.DIACHI = giangvien.DIACHI;
            gv.HOCVI = giangvien.HOCVI;
           
            db.SubmitChanges();
            var model2 = GiangVienDAO.getDataGV_DOANHNGHIEP();
            ViewData["getGVDN"] = model2;
            return View(giangvien);
        }
        [HttpPost]
        public ActionResult addGiangVienDoanhNghiep(FormCollection form)
        {
            Table_GiangVienDN tb_gv = new Table_GiangVienDN();
            tb_gv.ID_GVDN = int.Parse(form["Add_ID"].ToString());
            tb_gv.HOGVDN = form["Add_Ho"];
            tb_gv.TENGVDN = form["Add_Ten"];
            var gioitinh = form["Add_gioitinh"];
            bool gt = false;
            if (gioitinh == "Nam")
                gt = true;
            tb_gv.GIOITINH = gt;
            tb_gv.NGAYSINH = DateTime.Parse(form["Add_ngaysinh"]);
            tb_gv.SDT = form["Add_sdt"];
            tb_gv.EMAIL = form["Add_email"];
            tb_gv.DIACHI = form["Add_diachi"];
            tb_gv.HOCVI = form["Add_hocvi"];
            db.Table_GiangVienDNs.InsertOnSubmit(tb_gv);
            db.SubmitChanges();
            var model2 = GiangVienDAO.getDataGV_DOANHNGHIEP();
            return RedirectToAction("GiangVienDoanhNghiep", model2);
        }


        


        //Show chi tiết giảng viên
        [HttpPost]
        public JsonResult ChiTietGVDoanhNghiep(int ID_GV)
        {
            var result = GiangVienDAO.getDataGV_DOANHNGHIEP_byIDGV(ID_GV).SingleOrDefault();
            Session["ThongTinGVDoanhNghiep"] = result;
            //setDDlistNganh(result.ID_CHUYENNGANH);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }


        //Xóa giảng viên
        [HttpPost]
        public JsonResult deleteGVDoanhNghiep(int ID_GV)
        {
            var model = db.Table_GiangVienDNs.SingleOrDefault(m => m.ID_GVDN == ID_GV);
            db.Table_GiangVienDNs.DeleteOnSubmit(model);
            db.SubmitChanges();
            var result = true;
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        
        #endregion


    }
}