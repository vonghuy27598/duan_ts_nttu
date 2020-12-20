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
    public class DangKyCNController : Controller
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
        
    }
}