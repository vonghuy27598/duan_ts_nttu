using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using System.Text;
using System.Security.Cryptography;
using AppTS.XuLy;
using AppTS.ViewModels;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using ClosedXML.Excel;
using System.Data;

namespace AppTS.Controllers
{
    public class DangKyCNController : BaseController
    {
        //
        // GET: /DangKyCN/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult CheckLogin()
        {
            ViewBag.ThongBao = "Vui lòng đăng nhập trước khi đăng ký ngành";
            return View();
        }
        [HttpPost]
        public ActionResult CheckLogin(FormCollection collection, string id)
        {
            var tendn = collection["TenDN"];
            string tdn = tendn;
            var matkhau = collection["MatKhau"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewBag.Mess = string.Format("Tên đăng nhập không được rỗng");
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewBag.Mess = "Mật khẩu không được rỗng";
            }
            else
            {
                AppTS.Models.Table_TaiKhoan tk = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == tendn && m.PASSWORD == matkhau);
                if (tk != null)
                {

                    ViewBag.Mess = "Đăng nhập thành công";

                    Session["User"] = (HocSinh.GetInfoHS_byIDTK(tk.ID_TK)).SingleOrDefault();
                    return RedirectToAction("AcceptDangKyCN", "DangKyCN", new { id_cn = id });
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        public string Str_Encoder(string str)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            Byte[] hashBytes = encoding.GetBytes(str);
            // Compute the SHA-1 hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            Byte[] crypt_str = sha1.ComputeHash(hashBytes);
            return BitConverter.ToString(crypt_str);
        }
        [HttpGet]
        public ActionResult DangKyCN(int id)
        {
            var model = from a in db.Table_ChuyenNganhs where a.ID_CHUYENNGANH == id select a;
            return View(model.Single());
        }

        public ActionResult AcceptDangKyCN(int id_cn)
        {
            //Thêm CN vao HS

            var hs = (HocSinh_TK)Session["User"];


            var themCN = db.Table_HocSinhs.First(m => m.ID_HS == hs.ID_HS);
            themCN.ID_CHUYENNGANH = id_cn;
            UpdateModel(themCN);
            db.SubmitChanges();
            return RedirectToAction("DangKyThanhCong", "DangKyCN");
        }
        public ActionResult DangKyThanhCong()
        {
            return View();
        }
        public ActionResult QuanLyXetTuyen(TrungTuyen from)
        {
            var model = ListTrungTuyen.getDanhSach();
            return View(model);
        }
        [HttpPost]
        public JsonResult sortByDate(int value)
        {
            var result = ListTrungTuyen.getDanhSach();
            if (value == 0)
            {
                result = ListTrungTuyen.getDanhSach_toDay();
            }


            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult sortByDate_cus(DateTime date)
        {

            var result = ListTrungTuyen.getDanhSach_byDate(date);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ExportToExcel(string select, FormCollection form)
        {

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[6]{ new DataColumn("STT"),
                                            new DataColumn("Họ tên"),
                                            new DataColumn("Số ĐT"),
                                            new DataColumn("Chuyên ngành"),
                                            new DataColumn("Tổ hợp"),
                                            new DataColumn("Ngày đăng ký") });

            var danhsach = ListTrungTuyen.getDanhSach();
            var select_sort = form["select_sort"];


            if (select_sort.Equals("0"))
            {
                danhsach = ListTrungTuyen.getDanhSach_toDay();
               
            }
            else if (select_sort.Equals("1"))
            {
                DateTime date = DateTime.Parse(form["ip_date"]);
                danhsach = ListTrungTuyen.getDanhSach_byDate(date);
               
            }


            foreach (var item in danhsach)
            {
                dt.Rows.Add(item.ID, item.HOTEN, item.SDT, item.TENCHUYENNGANH, item.TENTOHOP, DateTime.Parse(item.NGAYDANGKY.ToString()).ToShortDateString());
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachDangKyXetTuyen.xlsx");
                }
            }


        }
    }
}