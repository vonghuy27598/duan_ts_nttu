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
using System.Net.Mail;
using System.Net;

namespace AppTS.Controllers
{
    public class HocSinhController : BaseController
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

            var link = "";
            if (Request.QueryString["link"] != null)
            {
                link = Request.QueryString["link"];
            }
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
                        //Tạo cookie
                        Session["User"] = (HocSinh.GetInfoHS_byIDTK(tk.ID_TK)).SingleOrDefault();
                        HttpCookie UserCookie = new HttpCookie("user", (tk.ID_TK).ToString());
                        UserCookie.HttpOnly = true;
                        //Đặt thời hạn cho cookie                   
                        UserCookie.Expires = DateTime.Now.AddDays(365);
                        //Lưu thông tin vào cookie                 
                        HttpContext.Response.SetCookie(UserCookie);
                        if (link.Equals("xettuyen"))
                        {
                            return RedirectToAction("DangKyXetTuyen", "HocSinh");
                        }
                        else if (link.Equals("DuDoan"))
                        {
                            return RedirectToAction("DuDoan", "TuVan");
                        }
                        else if (link.Equals("DinhHuong"))
                        {
                            return RedirectToAction("DinhHuong", "TuVan");
                        }
                        else if (link.Equals("") || link.Equals("null"))
                        {
                            return RedirectToAction("Main", "Home");
                        }
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
        public ActionResult DangNhapSDT(FormCollection collection)
        {

            var link = "";
            if (Request.QueryString["link"] != null)
            {
                link = Request.QueryString["link"];
            }
            var sdt = collection["SDT"];
            var matkhau = collection["MatKhau"];
            string tdn = sdt;
            if (String.IsNullOrEmpty(sdt))
            {
                ViewBag.Mess = string.Format("Số điện thoại không được rỗng");
            }
            else
            {
                AppTS.Models.Table_TaiKhoan tk = db.Table_TaiKhoans.SingleOrDefault(m => m.USERNAME == sdt && m.PASSWORD == Str_Encoder(matkhau));
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

                    if (link.Equals("xettuyen"))
                    {
                        if (tk.ADMIN == true)
                        {
                            return RedirectToAction("QuanLyXetTuyen", "DangKyCN");
                        }
                        else
                        {
                            return RedirectToAction("DangKyXetTuyen", "HocSinh");
                        }
                    }
                    else if (link.Equals("DuDoan"))
                    {
                        return RedirectToAction("DuDoan", "TuVan");
                    }
                    else if (link.Equals("DinhHuong"))
                    {
                        return RedirectToAction("DinhHuong", "TuVan");
                    }
                    else if (link.Equals("") || link.Equals("null"))
                    {
                        return RedirectToAction("Main", "Home");
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Số điện thoại hoặc mật khẩu không đúng";
                }
            }
            return View();
        }

        public ActionResult DoiMK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMK(FormCollection collection)
        {
            HocSinh_TK tk = (HocSinh_TK)Session["User"];

            var matkhaucu = collection["MatKhauCu"];
            var matkhau = collection["MatKhau"];
            var nlmatkhau = collection["NhapLaiMatKhau"];
            var upMK = db.Table_TaiKhoans.First(m => m.ID_TK == tk.ID_TK);

            if (Str_Encoder(matkhaucu) == tk.PASSWORD)
            {
                if (matkhau == nlmatkhau)
                {
                    upMK.PASSWORD = Str_Encoder(matkhau);
                    UpdateModel(upMK);
                    db.SubmitChanges();
                    Response.Write("<script>alert('Đổi mật khẩu thành công')</script>");
                    return RedirectToAction("Main", "Home");
                }
                else
                {
                    ViewData["LoiMK"] = "Mật khẩu KHÔNG trùng khớp";
                }
            }
            else
            {
                ViewData["LoiMk1"] = "Mật khẩu cũ không đúng";
            }
            return this.DoiMK();
        }

        public ActionResult QuenMK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuenMK(string EmailCF)
        {
            string messe = " ";
            bool status = false;
            var account = from a in db.Table_HocSinhs
                        join b in db.Table_TaiKhoans on a.ID_TK equals b.ID_TK
                        where a.EMAIL == EmailCF
                        select new HocSinh_TK()
                        {
                            ID_HS = a.ID_HS,
                            ID_TK = a.ID_TK,
                            EMAIL = a.EMAIL,
                            CODE = b.CODE
                        };
            var tk = account.Where(m => m.EMAIL == EmailCF).FirstOrDefault();
            var user = db.Table_TaiKhoans.Where(m => m.ID_TK == tk.ID_TK).FirstOrDefault();
            if (account != null)
            {
                string rsCode = EncodeTo64(DateTime.Now.TimeOfDay.ToString());
                GuiEmailXN(tk.EMAIL, rsCode, "DatLaiMK");
                tk.CODE = rsCode;
                var upCode = user.CODE = tk.CODE;
                UpdateModel(upCode);
                db.SubmitChanges();
                messe = "Kiểm tra hộp thư của bạn !!!";
            }
            else
            {
                messe = "Email chưa được đăng ký !!!";
            }
            ViewBag.Message = messe;
            return View();
        }
        [NonAction]
        public void GuiEmailXN(string emailXN, string CodeXN, string emailFor = "DatLaiMK")
        {

            //get link
            var vrfURL = "/HocSinh/" + emailFor + "/" + CodeXN;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, vrfURL);
            //gui thu
            var fromEmail = new MailAddress("qunag7190@gmail.com", "Quang Vlogs");
            var toEmail = new MailAddress(emailXN);
            var fromEmailPass = "270134275";
            //noi dung
            var subject = "";
            var body = "";
            subject = "Đặt lại mật khẩu";
            body = "Chào bạn, <br/> Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn. Vui lòng nhấp vào link dưới đây để đặt lại mật khẩu của bạn: " +
                    "<br/><a href=" + link + "> Đặt lại mật khẩu </a>";
            //smtp
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPass)
            };
            //gui mail di
            using (var mess = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(mess);
        }
        public ActionResult DatLaiMK(string id)
        {
            Session["Check"] = "ok";
            var user = db.Table_TaiKhoans.Where(m => m.CODE == id).FirstOrDefault();
            if (user != null)
            {
                ResetPassword rs = new ResetPassword();
                rs.ReserCode = id;
                return View(rs);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatLaiMK(ResetPassword rs)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = db.Table_TaiKhoans.Where(m => m.CODE == rs.ReserCode).FirstOrDefault();
                if (user != null)
                {
                    if (rs.Password == rs.RePassword)
                    {
                        user.PASSWORD = Str_Encoder(rs.Password);
                        user.CODE = "";
                        db.SubmitChanges();

                        message = "Đặt lại mật khẩu thành công";
                        Session["Check"] = null;
                    }
                    else
                    {
                        message = "Xác nhận mật khẩu không trùng khớp";
                    }
                }
            }
            else
            {
                message = "Lỗi";
            }
            ViewBag.Message = message;
            return View(rs);
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(HocSinh_TK hs_tk)
        {
            var link = "";
            if (Request.QueryString["link"] != null)
            {
                link = Request.QueryString["link"];
            }
            bool tontaisdt = db.Table_HocSinhs.Any(m => hs_tk.SDT == m.SDT);
            bool tontaitk = db.Table_HocSinhs.Any(m => hs_tk.EMAIL == m.EMAIL);
            if (tontaisdt)
            {
                ViewData["LoiSDT"] = "Số điện thoại đã được sử dụng";
            }
            else
            {
                if (tontaitk)
                {
                    ViewData["LoiUS"] = "Email này đã được sử dụng";
                }
                else
                {
                    Table_TaiKhoan tk = new Table_TaiKhoan();
                    tk.USERNAME = hs_tk.SDT;
                    if (hs_tk.PASSWORD != null)
                    {
                        tk.PASSWORD = Str_Encoder(hs_tk.PASSWORD);
                    }
                    else
                    {
                        tk.PASSWORD = null;
                    }

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
                    ViewBag.Message = "Bạn đã đăng ký thành công.";

                    return View();
                }
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
        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            if (Request.Cookies["user"] != null)
            {
                var user = new HttpCookie("user")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Response.SetCookie(user);
            }
            return RedirectToAction("Main", "Home");
        }
        public ActionResult ttDangNhappart()
        {
            HocSinh_TK tk = (HocSinh_TK)Session["User"];
            return PartialView(tk);
        }

        public ActionResult DangKyXetTuyen()
        {

            setDDlistNganh();

            if (Session["User"] != null)
            {
                HocSinh_TK tk = (HocSinh_TK)Session["User"];
                ViewData["getLichSu"] = HocSinh.getLichSuDangKy(tk.SDT);
                return View(tk);
            }
            else
            {
                return RedirectToAction("DangNhapSDT", "HocSinh", new { link = "xettuyen" });
            }

        }

        //dropdown ngành
        public void setDDlistNganh(int? selectedId = null)
        {

            ViewBag.Nganh = new SelectList(Nganh.getKhoiNganh_ddl(), "ID_NGANH", "TENNGANH", selectedId);
        }
        //getTenNganh
        [HttpPost]
        public JsonResult getTenNganh(int id_khoinganh)
        {
            var result = Nganh.getKhoiNganh(id_khoinganh);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        //getToHop
        [HttpPost]
        public JsonResult getToHop(int id_chuyennganh)
        {
            var result = Nganh.getToHop(id_chuyennganh);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        //getMon_ToHop  
        public JsonResult getMon_ToHop(string to_hop)
        {
            var result = Nganh.getMon_ToHop(to_hop);
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }

        //submit xét tuyển
        [HttpPost]
        public JsonResult submit_XetTuyen(float tongdiem, string tohop, int nganh, float mon1, float mon2, float mon3, string hoten, string diachi, string truong, string sdt, string email)
        {
            Table_TrungTuyen trungtuyen = new Table_TrungTuyen();
            trungtuyen.HOTEN = hoten;
            trungtuyen.DIACHI = diachi;
            trungtuyen.TRUONG = truong;
            trungtuyen.SDT = sdt;
            trungtuyen.EMAIL = email;
            trungtuyen.TENTOHOP = tohop;
            trungtuyen.MON1 = mon1;
            trungtuyen.MON2 = mon2;
            trungtuyen.MON3 = mon3;
            trungtuyen.NGAYDANGKY = DateTime.Now;
            trungtuyen.ID_CHUYENNGANH = nganh;
            bool trung = true;
            if (tongdiem < 18)
            {
                trung = false;
            }
            trungtuyen.TRUNGTUYEN = trung;
            db.Table_TrungTuyens.InsertOnSubmit(trungtuyen);
            db.SubmitChanges();
            return Json(new
            {

            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult test()
        {

            return View();
        }
        public JsonResult ListNameTruong(string a)
        {
            var data = HocSinh.ListName_Truong(a);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}