using AppTS.Areas.Admin.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using Newtonsoft.Json;
using AppTS.ViewModels;
namespace AppTS.Areas.Admin.Controllers
{
    public class NganhController : BaseController
    {
        //
        // GET: /Admin/Nganh/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();


        #region Quản lý ngành
        //public ActionResult Nganh()
        //{
        //    var model = NganhDAO.getNganh();
        //    return View(model);
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id_nganh)
        //{
        //    var model = (from a in db.Table_HocSinhs where a.ID_NGANH == id_nganh select a).Count();
        //    if ((int)model == 0)
        //    {
        //        new XuLyDAO().DeleteNganh(id_nganh);
        //        return JavaScript("Onsuccess("+id_nganh+");");
        //    }else{
        //        return JavaScript("DeleteFail();");
        //    }
           
         
              
        //}

        //[HttpPost]
        //public ActionResult UpdateNganh(int id_nganh,string tennganh)
        //{
        //    var model = db.Table_Nganhs.First(m => m.ID_NGANH == id_nganh);
        //    model.TENNGANH = tennganh;
        //    UpdateModel(model);
        //    db.SubmitChanges();
        //    return RedirectToAction("Nganh");
        //}

        #endregion


        
        #region Quản lý chuyên ngành

        public ActionResult ChuyenNganh()
        {
            var model = NganhDAO.getChuyenNganh();
            
            return View(model);
        }
        //Thêm chuyên ngành
        [HttpPost]
        public ActionResult ChuyenNganh(ChuyenNganhFull form)
        {
            Table_ChuyenNganh tb_cn = new Table_ChuyenNganh();
            tb_cn.ID_CHUYENNGANH = (int)(form.ID_CHUYENNGANH);
            tb_cn.TENCHUYENNGANH = form.TENCHUYENNGANH;
            Table_CTCN ct_cn = new Table_CTCN();
            ct_cn.MOTA = form.MOTA;
            tb_cn.ID_NGANH = 1;
            bool tontaiID = db.Table_ChuyenNganhs.Any(m => form.ID_CHUYENNGANH == m.ID_CHUYENNGANH);
            if(tontaiID){
                ModelState.AddModelError("ID_CHUYENNGANH", "Mã chuyên ngành " + form.ID_CHUYENNGANH + " đã tồn tại");
                ViewBag.Mess = "Mã chuyên ngành " + form.ID_CHUYENNGANH + " đã tồn tại";
               
            }
            if(ModelState.IsValid)
            {
                db.Table_ChuyenNganhs.InsertOnSubmit(tb_cn);
                db.SubmitChanges();
                RedirectToAction("ChuyenNganh");
            }
            var model = NganhDAO.getChuyenNganh();
            return View(model);
        }

        [HttpDelete]
        public ActionResult DeleteChuyenNganh(int id_chuyennganh)
        {
            var model = (from a in db.Table_HocSinhs where a.ID_CHUYENNGANH == id_chuyennganh select a).Count();
            if ((int)model == 0)
            {
                new XuLyDAO().DeleteChuyenNganh(id_chuyennganh);
                return JavaScript("Onsuccess(" + id_chuyennganh + ");");
            }
            else
            {
                return JavaScript("DeleteFail();");
            }



        }
        [HttpPost]
        public ActionResult UpdateChuyenNganh(int id_chuyennganh, string tenchuyennganh)
        {
            var model = db.Table_ChuyenNganhs.First(m => m.ID_CHUYENNGANH == id_chuyennganh);
            model.TENCHUYENNGANH = tenchuyennganh;
            UpdateModel(model);
            db.SubmitChanges();
            return RedirectToAction("ChuyenNganh");
        }

        #endregion
    }
}