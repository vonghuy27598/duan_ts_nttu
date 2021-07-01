using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using AppTS.Models;

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
    }
}