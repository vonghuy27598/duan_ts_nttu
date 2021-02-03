using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using AppTS.ViewModels;
using AppTS.XuLy;

namespace AppTS.Controllers
{
    public class TuVanController : BaseController
    {
        //
        // GET: /TuVan/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult DuDoan()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("DangNhapSDT", "HocSinh", new { link = "dudoan" });
            }
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
            return View();
        }
        public ActionResult BatDauDinhHuong()
        {
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
        public JsonResult getNganh_TheoDiem(double toan, double ly, double hoa, double van, double su, double dia, double sinh, double anh)
        {
            DHNN getList = new DHNN();
            getList.set_Diem(toan,ly,hoa,van,su,dia,sinh,anh);          
            string[] list_nganh = getList.get_list_Nganh();
                  
            if(list_nganh !=null )
            {
                int count = list_nganh.Length;
                List<object> list_linkidnganh = new List<object>();
                //list_linkidnganh = Nganh.getID_CHUYENNGANH_BYTENCHUYENNGANH(list_nganh);              
                foreach (var item in list_nganh)
                {
                    var model = db.Table_ChuyenNganhs.Where(m => m.TENCHUYENNGANH.ToLower() == item.ToLower()).Select(m => m.ID_CHUYENNGANH);

                    list_linkidnganh.Add(new { ID_CHUYENNGANH = model, TENCHUYENNGANH = item });            
                }                 
                var result = list_linkidnganh;
               
                return Json(new
                {
                    status = result,
                   
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = list_nganh;
                return Json(new
                {
                    status = result
                  
                }, JsonRequestBehavior.AllowGet);
            }
           
           
           
        }

        //submit dang nhap
        [HttpPost]
        public JsonResult submit_DangNhap(string sdt, string matkhau)
        {
            Table_TaiKhoan tk = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == sdt && m.PASSWORD == Str_Encoder(matkhau));
            if (matkhau.Length == 0)
            {
                tk = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == sdt);

                if (tk != null)
                {
                    if (tk.PASSWORD != null)
                    {
                        tk = null;
                    }
                }

            }
            if (tk != null)
            {
                ViewBag.Mess = "Đăng nhập thành công";

                Session["User"] = (HocSinh.GetInfoHS_byIDTK(tk.ID_TK)).SingleOrDefault();
                //Tạo cookie
                Session["User"] = (HocSinh.GetInfoHS_byIDTK(tk.ID_TK)).SingleOrDefault();
                HttpCookie UserCookie = new HttpCookie("user", (tk.ID_TK).ToString());
                UserCookie.HttpOnly = true;
                //Đặt thời hạn cho cookie
                UserCookie.Expires = DateTime.Now.AddDays(365);
                //Lưu thông tin vào cookie
                HttpContext.Response.SetCookie(UserCookie);
                return Json(new
                {
                    success = 1,
                    message = "Đăng nhập thành công"
                }, JsonRequestBehavior.AllowGet) ;
            }
            else
            {
                ViewBag.ThongBao = "Số điện thoại hoặc mật khẩu không đúng";
                return Json(new
                {
                    success = 0,
                    message = "Số điện thoại hoặc mật khẩu không đúng"
                }, JsonRequestBehavior.AllowGet);
            }
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
    }
}