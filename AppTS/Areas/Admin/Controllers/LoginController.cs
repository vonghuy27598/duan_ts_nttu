using AppTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AppTS.Areas.Admin.Models.ViewModel;

namespace AppTS.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan tk)
        {
            var tb_taikhoan = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == tk.USERNAME && m.PASSWORD == Str_Encoder(tk.PASSWORD));
            if (tb_taikhoan != null)
            {
                if (tb_taikhoan.ADMIN == true)
                {
                    Session["TAIKHOANADMIN"] = tk;
                    return RedirectToAction("TrangChu", "Admin");
                }
            }
            else
            {
                ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu";
            }
          

            return View(tk);
        }

        public ActionResult Signup()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Signup(AppTS.Areas.Admin.Models.ViewModel.Admin ad, FormCollection form)
        {
            //var hogv = form["HOGV"];
            //var tengv = form["TENGV"];
            //var sdt = form["SDT"];
            //string gioitinh = ad.GIOITINH                   
            //var email = form["EMAIL"];
            var username = form["USERNAME"];
            var password = form["PASSWORD"];          
            
            Table_TaiKhoan tk = new Table_TaiKhoan();

            bool tontaitk = db.Table_TaiKhoans.Any(m => m.USERNAME == username);
            if (tontaitk)
            {
                
                ModelState.AddModelError("USERNAME", "Tên tài khoản đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                tk.USERNAME = username;
                tk.PASSWORD = Str_Encoder(password);
                tk.ADMIN = true;
                db.Table_TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();
                Table_Admin admin = new Table_Admin();
                admin.ID_TK = tk.ID_TK;
                admin.HOADMIN = ad.HOADMIN;
                admin.TENADMIN = ad.TENADMIN;
                admin.SDT = ad.SDT;
                //bool gt = false;
                //if (gioitinh == ("Nam"))
                //    gt = true;
                admin.GIOITINH = ad.GIOITINH;
               
                admin.EMAIL = ad.EMAIl;
                db.Table_Admins.InsertOnSubmit(admin);
                db.SubmitChanges();
                ViewBag.SuccessMsg = "Tạo tài khoản thành công";
                return RedirectToAction("Index");
            }
            return View(ad);
         
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