using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using AppTS.Models;
using AppTS.ViewModels;

namespace AppTS.Controllers
{
    public class DeskTopController : Controller
    {
        //
        // GET: /DeskTop/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        //-------------FORM Reply Question--------------------
        public ActionResult traLoiChatBot(int? sort, int? page)
        {
            int pageSize = 20;
            
            //Tạo biến số trang
            int pageNum = (page ?? 1);
            var model = from a in db.Table_TUVANs select a;
            if (sort == 1)
                model = from a in db.Table_TUVANs.Where(m => m.DA_REP == true) select a;
            else if (sort == 2)
                model = from a in db.Table_TUVANs.Where(m => m.DA_REP == false) select a;
            return View(model.OrderByDescending(m => m.NGAYHOI).ToList().ToPagedList(pageNum, pageSize));

        }
        //[HttpPost]
        //public JsonResult sortQuestion(int val)
        //{
        //    var model = from a in db.Table_TUVANs select a;
        //    if(val == 1)
        //    {
        //         model = from a in db.Table_TUVANs.Where(m=>m.DA_REP == true) select a;
        //    }
        //    else if (val == 2)
        //    {
        //        model = from a in db.Table_TUVANs.Where(m => m.DA_REP == false) select a;
        //    }

        //    return Json(new
        //    {
        //        status = model,
        //    }, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult getQuestion(int ID_CAUHOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.DA_XEM = true;
            UpdateModel(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult setQuestion(int ID_CAUHOI, string CAUTRALOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.DA_XEM = true;
            tv.DA_REP = true;
            tv.CAUTRALOI = CAUTRALOI;
            UpdateModel(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult deleteQuestion(int ID_CAUHOI)
        {

            var model = db.Table_TUVANs.Where(m => m.ID_CAUHOI == ID_CAUHOI);
            var tv = db.Table_TUVANs.First(m => m.ID_CAUHOI == ID_CAUHOI);
            tv.ADMIN_DEL = true;
            db.Table_TUVANs.DeleteOnSubmit(tv);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult showAllListSV( int? page)
        {
            int pageSize = 20;

            //Tạo biến số trang
            int pageNum = (page ?? 1);
            var model = from a in db.Table_TrungTuyens
                        join b in db.Table_ChuyenNganhs on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        select new TrungTuyen()
                        {
                            ID = a.ID,
                            HOTEN = a.HOTEN,
                            DiaChi = a.DIACHI,
                            Truong = a.TRUONG,
                            SDT = a.SDT,
                            Email = a.EMAIL,
                            NGAYDANGKY = a.NGAYDANGKY,
                            TENTOHOP = a.TENTOHOP,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            TongDiem = a.MON1 + a.MON2 + a.MON3,
                            Flag = a.TRUNGTUYEN
                        };

            return View(model.OrderBy(m => m.ID).ToList().ToPagedList(pageNum, pageSize));

        }

        [HttpPost]
        public JsonResult deleteData(int ID)
        {

            var model = db.Table_TrungTuyens.Where(m => m.ID == ID);
            var tt = db.Table_TrungTuyens.First(m => m.ID == ID);
            db.Table_TrungTuyens.DeleteOnSubmit(tt);
            db.SubmitChanges();
            return Json(new
            {
                status = model,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}