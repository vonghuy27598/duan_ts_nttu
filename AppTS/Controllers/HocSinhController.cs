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

namespace AppTS.Controllers
{
    public class HocSinhController : Controller
    {
        //
        // GET: /Login/
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
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
                AppTS.Models.Table_TaiKhoan tk = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == tendn && m.PASSWORD == Str_Encoder(matkhau));
                if (tk != null)
                {
                    if (!(bool)tk.ADMIN)
                    {
                        ViewBag.Mess = "Đăng nhập thành công";

                        Session["User"] = (HocSinh.GetInfoHS_byIDTK(tk.ID_TK)).SingleOrDefault();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                  
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(HocSinh_TK hs_tk)
        {
                bool tontaitk = db.Table_TaiKhoans.Any(m => hs_tk.USERNAME == m.USERNAME);
                if (tontaitk)
                {
                    ViewData["LoiUS"] = "Tài khoản đã được sử dụng";
                }
                else
                {
                    Table_TaiKhoan tk = new Table_TaiKhoan();
                    tk.USERNAME = hs_tk.USERNAME;
                    tk.PASSWORD = Str_Encoder(hs_tk.PASSWORD);
                    tk.ADMIN = false;
                    db.Table_TaiKhoans.InsertOnSubmit(tk);
                    db.SubmitChanges();
                    Table_HocSinh hs = new Table_HocSinh();
                    hs.ID_TK = tk.ID_TK;
                    hs.HOTENHS = hs_tk.HOTENHS;
                    hs.TRUONGCAP3 = hs_tk.TRUONGCAP3;
                    hs.GIOITINH = hs_tk.GIOITINH;
                    hs.EMAIL = hs_tk.EMAIL;
                    hs.NGAYSINH = hs_tk.NGAYSINH;
                    hs.SDT = hs_tk.SDT;
                    hs.DIACHI = hs_tk.DIACHI;
                    db.Table_HocSinhs.InsertOnSubmit(hs);
                    db.SubmitChanges();
                   
                    return RedirectToAction("DangNhap");
                }          

            return this.DangKy();
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
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ttDangNhappart()
        {
            HocSinh_TK tk = (HocSinh_TK)Session["User"];
            return PartialView(tk);
        }
	}
}