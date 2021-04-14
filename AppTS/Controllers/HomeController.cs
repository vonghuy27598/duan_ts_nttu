using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTS.Models;
using AppTS.ViewModels;
using AppTS.XuLy;

namespace AppTS.Controllers
{
    public class HomeController : BaseController
    {
        dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Main()
        {
            HttpCookie user_noname = Request.Cookies["ID_USER_NONAME"];
            if (user_noname == null)
            {
                Guid CartGUID = Guid.NewGuid();
                HttpCookie UserCookie = new HttpCookie("ID_USER_NONAME", CartGUID.ToString());
                UserCookie.HttpOnly = true;
                //Đặt thời hạn cho cookie
                UserCookie.Expires = DateTime.MaxValue;
                //Lưu thông tin vào cookie
                HttpContext.Response.SetCookie(UserCookie);
            }
            //get Cookie          
            HttpCookie User = Request.Cookies["user"];
            if (User != null)
            {
                Session["User"] = (HocSinh.GetInfoHS_byIDTK(int.Parse(User.Value))).SingleOrDefault();
            }
            return View();
        }
        public ActionResult DangKyXetTuyen()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult MoTaNganh(int id)
        {
            Table_Nganh ng = new Table_Nganh();
            var model = Nganh.NganhFull_byID(id);
            return View(model.Single());
        }
        public ActionResult MoTaChuyenNganh(int id)
        {
            Table_ChuyenNganh cn = new Table_ChuyenNganh();
            ViewData["Chitiet"] = CNganh.getChiTiet_ByIDCN(id);
            //Get tên chuyên ngành by id ngành
            var model = from a in db.Table_ChuyenNganhs where a.ID_CHUYENNGANH == id select a;
            return View(model.Single());
        }
        public PartialViewResult Header()
        {
            var model = Nganh.NganhFull();
            return PartialView(model);
        }
        public PartialViewResult Header_TuVan()
        {

            return PartialView();
        }
        public PartialViewResult Header_KhaoSat()
        {

            return PartialView();
        }
        public PartialViewResult Menu(int id)
        {
            var model = CNganh.ChuyenNganhFull_byID_select(id);
            return PartialView(model);

        }
        public ActionResult PhuongAnTS()
        {
            return View();
        }
        public ActionResult CacNganhDaoTao()
        {
            return View();
        }
        public ActionResult ThacSiCNTT()
        {
            return View();
        }
        public ActionResult ThacSiQTKD()
        {
            return View();
        }
        public ActionResult ThacSiTCNH()
        {
            return View();
        }
        public ActionResult ThacSiDuLich()
        {
            return View();
        }
        public ActionResult CacChuyenganh(int id)
        {
            var model = Nganh.getChuyenNganh_byNganh(id);
            ViewData["tohop"] = from a in db.Table_ToHops select a;
            return View(model);
        }
        public ActionResult ChiTietCacNganh()
        {
            var nganh = Request.QueryString["id_nganh"];
            var model = from a in db.Table_Nganhs select a;
            if (nganh.Equals("1"))
            {
                Session["ct_nganh"] = "1";
                model = from a in db.Table_Nganhs.OrderBy(m => m.TENNGANH) select a;
            }
            else if (nganh.Equals("2"))
            {
                Session["ct_nganh"] = "2";

            }
            else if (nganh.Equals("3"))
            {
                Session["ct_nganh"] = "3";

            }
            else if (nganh.Equals("4"))
            {
                Session["ct_nganh"] = "4";

            }
            else if (nganh.Equals("5"))
            {
                Session["ct_nganh"] = "5";

            }
            else if (nganh.Equals("6"))
            {
                Session["ct_nganh"] = "6";

            }
            else if (nganh.Equals("7"))
            {
                Session["ct_nganh"] = "7";

            }
            else if (nganh.Equals("8"))
            {
                Session["ct_nganh"] = "8";

            }
            else if (nganh.Equals("9"))
            {
                Session["ct_nganh"] = "9";

            }
            ViewData["tohop"] = from a in db.Table_ToHops select a;
            return View(model);
        }

        public ActionResult ChiTietRiengCacNganh(int id)
        {
            var model = Nganh.getChiTietNganh(id);
            return View(model);
        }


        public ActionResult ChiTietRiengSong_LienNganh(int id)
        {

            ViewBag.Mess = id;
            return View();
        }
        public ActionResult ChiTietRiengVienQuocTe(int id)
        {
            List<VienQuocTe> listdata = new List<VienQuocTe>();
            if (id == 1)
            {
                listdata.Add(new VienQuocTe(1, "Kế toán", "Kế toán tài chính", "A00, A01, D01, D07", "Kế toán được xem là ngành học tiềm năng cho sự chuyển dịch lao động trong khối ASEAN. Sinh viên theo học ngành Kế toán - Tài chính sẽ được cung cấp những kiến thức về khung pháp lý, hệ thống chuẩn mực kế toán kiểm toán, các quy định về đạo đức nghề nghiệp như: Dự toán, phân bổ ngân sách, quản lý doanh thu.", "Kế toán viên, Kế toán tổng hợp, Nhân viên thủ quỹ, Chuyên viên kiểm toán, Chuyển viên tín dụng, Chuyên viên tư vấn thuế, Chuyên viên tài chính", "Microeconomics, Macroeconomics, Business and the Business Environment, Principles of Accounting, Business Law, Management Accounting, Marketing Essentials, Business Statistics, Corporate Finance, Intermediate Accounting 1, Information System Management/ Management, Information System, Ethics in Accounting, Financial Markets, Intermediate Accounting 2, International Accounting, Auditing, Cost Accounting, Monetary and Banking, Taxation, Accounting Software, Banking Accounting, Merging And Acquistion", "1 - ke toan copy.png", "ct_ketoan.jpg"));
            }
            else if (id == 2)
            {
                listdata.Add(new VienQuocTe(2, "Quản trị kinh doanh", "Kinh doanh quốc tế, Marketing", "A00, A01, D01, D07", "Trong môi trường cạnh tranh toàn cầu, Quản trị kinh doanh là ngành học cực kỳ quan trọng cho các nhà quản trị tương lai. Chương trình học cung cấp cho bạn những kiến thức nền tảng liên quan đến lĩnh vực kinh tế, môi trường kinh doanh, quản lý doanh nghiệp, các kỹ năng tự duy, phân tích, đàm phán, xây dựng chiến lược cũng như quản trị nhân sự.", "Chuyên viên đối ngoại, Chuyên viên xuất nhập khẩu, Chuyên viên marketing, Chuyên viên nghiên cứu thị trường, Chuyên viên hoạch định tài chính, Quản lý nguồn nhân lực", "Microeconomics, Macroeconomics, Business and the Business Environment, Principles of Accounting, Business Law, Management Accounting, Marketing Essentials, Business Statistics,Financial Management, Organizational Behavior, Information System Management/ Management, Information System, Human Resource Management, Operations Management, Managing a Successful Business Project, Strategic Management, Business Event Management, International Bussiness, Sales Management, Taxation, Exporting and Importing Documentation and Procedures, Managerial Decision Making, Understanding and Leading Change", "2 - quan tri kinh doanh copy.png", "ct_kd.jpg"));
            }
            else if (id == 3)
            {
                listdata.Add(new VienQuocTe(3, "Luật kinh tế", "Luật kinh tế", "A00, A01, D01, D07", "Luật kinh tế là ngành học “đắt giá” trước ngưỡng cửa hội nhập. Sinh viên ngành Luật Kinh tế được cung cấp kiến thức và kỹ năng chuyên sâu về pháp luật, thực tiễn pháp lý, pháp luật trong kinh doanh, khả năng nghiên cứu và xử lý những vấn đề pháp lý đặt ra trong thực tiễn hoạt động kinh doanh của doanh nghiệp và quản lý nhà nước đối với doanh nghiệp.", "Chuyên viên tư vấn pháp luật tại các doanh nghiệp, Chuyên viên thực hiện dịch vụ pháp lý tại các tổ chức dịch vụ pháp luật, Chuyên viên lập pháp; hành pháp; tư pháp trong các cơ quan nhà nước; luật sư kinh tế", "Microeconomics, Legal Logic, Macroeconomics, Business and the Business Environment, Principles of Accounting, Civil Law 1, Constitutional Law, Administrative Law, Civil Law 2, Commercial Law 1, Criminal Law, Public International Law, Law on Civil Procedure, Commercial Law 2, Labour Law, Law on Criminal Procedure, English for Lawyer, Private International Law, Comparative Law, Intellectual Property Law, International Trade Law, Law on Environment and Land, Banking Law, Competition Law, Law on Im-Export and Customs", "3 - luat kinh te.png", "ct_luat.jpg"));
            }
            else if (id == 4)
            {
                listdata.Add(new VienQuocTe(4, "Quản trị khách sạn", "Quản trị khách sạn", "A00, A01, C00, D07", "Quản trị khách sạn là ngành học luôn thu hút sự quan tâm của giới trẻ. Sinh viên theo học ngành này được trang bị những kiến thức chuyên sâu về nghiệp vụ quản lý dựa trên các tiêu chuẩn của ngành như: kiến thức tổng hợp về văn hóa các vùng miền và các nước, dịch vụ ăn uống, nghiệp vụ lễ tân, quản lý khách sạn và tổ chức sự kiện.", "Quản lý dịch vụ ẩm thực Quan hệ khách hàng và truyền thông, Quản lý nhân sự, Điều hành và tổ chức sự kiện, Thiết kế và điều phối tours", "Microeconomics, Macroeconomics, Business and the Business Environment, Principles of Accounting, Business Law, Marketing in Hospitality, Business Statistics, Human resource management for Service Industries, Customer Services, Hospitality Services, The Contemporary Hospitality Industries, Information System Management, The Developing Manager, Facilities Operation and Management, Finance in Hospitality, Resource Management in Hospitality, Hospitality Operation Management, Hospitality Contract and Event Management, Room Devision Operation Management, Food and Beverage Operation Management, Sale Development and Merchandising, Sustainable Tourism Development", "4 - qtks.png", "ct_ks.jpg"));

            }
            else if (id == 5)
            {
                listdata.Add(new VienQuocTe(5, "Công nghệ thông tin", "Kỹ thuật phần mềm", "A00, A01, D01, D07", "Ngành Công nghệ thông tin, đặc biệt là kỹ thuật phần mềm có trình độ chuyên môn cao luôn được săn đón bởi các nhà tuyển dụng trong và ngoài nước. Theo học tại NIIE, sinh viên được đào tạo chuyên sâu về quy trình phát triển, gia công hay ứng dụng hệ thống phần mềm; các kiến thức về phân tích, thiết kế, phát triển, kiểm thử, vận hành, bảo trì phần mềm của hệ thống máy tính.", "Lập trình phát triển ứng dụng, Kỹ sư hệ thống phần mềm, Kỹ sư kiểm thử phần mềm, Kỹ sư quy trình sản xuất phần mềm, Chuyên viên phân tích thiết kế dữ liệu.", "Programming, Discrete maths, Database Design and Development, Security, Advanced Programming, Data Structure and Algorithms, Software Technology, Web Application Design and Development, IT Project Management, Operating  Systems, Business Information System (strategic IS), Business Intelligence (IT), Application program interfaces, Networking, Programming for Mobile Devices, Application Development, Cloud computing, Database Management Systems, E-Commerce & Strategy", "5 - CNTT.png", "ct_cntt.jpg"));

            }
            else if (id == 6)
            {
                listdata.Add(new VienQuocTe(6, "Công nghệ kỹ thuật ô tô", "Công nghệ kỹ thuật ô tô", "A00, A01, D01, D07", "Công nghệ kỹ thuật ô tô được xem là ngành công nghiệp mũi nhọn trong chiến lược công nghệ hóa đất nước và xu hướng hội nhập sâu rộng. Theo đó, việc đào tạo đội ngũ kỹ sư ô tô tại Việt Nam đang trở nên cấp bách trước thực tế ngày càng có nhiều doanh nghiệp tham gia sản xuất, lắp ráp và lượng tiêu thụ ô tô trên thị trường tăng nhanh đáng kể.", "Chuyên viên kỹ thuật, Chuyên viên kiểm định chất lượng phương tiện, Chuyên viên tại các công ty sản xuất kinh doanh các lĩnh vực liên quan tới ngành cơ khí động lực", "Introduction to Automotive Engineering Technology, Engineering Mathematics, Material Engineering, Applied Mechanics, Fluid Mechanics & Thermodynamic Engineering, Engineering Drawing, Occupational Safety and Health, English for Automotive Engineering, Electrical and Electronics Engineering, Hydraulic - Pneumatic Technology, Foundation of Mechanical Enginneering, Internal Combustion Engine Mechanics, Principles of Internal Combustion Engine, Microcontroller, Theory of Vehicles, Automotive Mechanics, Automotive Sensors and Actuators, Automotive Electrical & Electronics Systems, Project in Automotive Automated Control Systems, Maintenance Engineering, Engineering Design, Automotive Repair and Maintenance, Automotive Inspection and Diagnosis Technology, Electric and Hybrid Vehicles, Course Project", "6 - CNKT o to.png", "ct_oto.jpg"));

            }
            else if (id == 7)
            {
                listdata.Add(new VienQuocTe(7, "Logistics và quản lý chuỗi cung ứng", "Logistics và quản lý chuỗi cung ứng", "A00, A01, D01, D07", "Logistics và Quản lý chuỗi cung ứng được xem là “làn gió mới” có sức hút lớn trong bối cảnh kinh tế hiện nay bởi đây là ngành đào tạo mang tính chất liên ngành về phát triển và quản trị các dịch vụ vận chuyển trong quá trình sản xuất kinh doanh. Theo học ngành này, sinh viên sẽ được cung cấp các nền tảng vững chắc trong lĩnh vực cung ứng và hậu cần.", "Chuyên viên quản lý kho vận, Điều hành vận tải; chuyên viên quản lý xuất/nhập khẩu, Chuyên viên kế hoạch sản xuất, Chuyên viên phân tích logistics, Chuyên viên cung ứng - thu mua; chuyên viên phân tích chuỗi cung ứng.", "Microeconomics, Macroeconomics, Introduction to Logistics and Supply Chain  Management, Business and the Business Environment, Operations Management, Business Law, Purchasing and Supply Management, Transportation Management, Marketing Essentials , Financial Management, Warehouse Management and Inventory Control, Organizational Behavior, International Bussiness, Distribution Channel Management, Human Resource Management, E-commerce, International Logistics, Logistics Information System, Electives, Import and Export Rules and Documents, Electives, Strategic Management", "7 - logistics.png", "ct_logic.jpg"));

            }
            ViewData["QuocTe"] = listdata;
            return View();
        }
        public ActionResult DangCapNhat()
        {

            return View();
        }
        public ActionResult TienIchHocTap()
        {
            return View();
        }
        public ActionResult ChiTietTienIch()
        {
            var nganh = Request.QueryString["id_tienich"];
            if (nganh.Equals("1"))
            {
                Session["ct_tienich"] = "1";
            }
            else if (nganh.Equals("2"))
            {
                Session["ct_tienich"] = "2";

            }
            else if (nganh.Equals("3"))
            {
                Session["ct_tienich"] = "3";

            }
            else if (nganh.Equals("4"))
            {
                Session["ct_tienich"] = "4";

            }
            else if (nganh.Equals("5"))
            {
                Session["ct_tienich"] = "5";

            }
            else if (nganh.Equals("6"))
            {
                Session["ct_tienich"] = "6";

            }
            else if (nganh.Equals("7"))
            {
                Session["ct_tienich"] = "7";

            }
            return View();
        }
        public ActionResult ChiTietThacSi()
        {
            return View();
        }
        public ActionResult DieuKienDuThi()
        {
            return View();
        }
        public ActionResult QuanLyThacSi()
        {
            Session["check"] = "ok";
            var model = ListThacSi.getDanhSach();
            return View(model);
        }
        [HttpPost]
        public JsonResult sortByDate_cus(DateTime date)
        {

            var result = ListThacSi.getDanhSach_byDate(date);
            Session["download"] = "cus";
            Session["cus_date"] = date;
            return Json(new
            {
                status = result
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DangKyThacSi()
        {

            if (Session["User"] != null)
            {
                HocSinh_TK tk = (HocSinh_TK)Session["User"];
                string[] list = new string[] { "Công nghệ Thông tin", "Tài chính - Ngân hàng", "Quản trị kinh doanh", "Du lịch" };
                var getList = list.ToList();
                SelectList setList = new SelectList(getList);
                ViewBag.MajorName = setList;
                return View(tk);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DangKyThacSi(HocSinh_TK tk)
        {
            Table_dkThacSi dk = new Table_dkThacSi();
            dk.HOTEN = tk.HOTENHS;
            dk.NGAYSINH = tk.NGAYSINH;
            dk.SDT = tk.SDT;
            dk.EMAIL = tk.EMAIL;
            dk.TENNGANH = tk.TENCHUYENNGANH;
            dk.NAM = DateTime.Now.Year;
            db.Table_dkThacSis.InsertOnSubmit(dk);
            db.SubmitChanges();
            ViewBag.Message = "Bạn đã đăng ký thành công.";

            return View(tk);
            //return RedirectToAction("Main","Home");
        }

      
        public PartialViewResult part_Thacsi()
        {
            return PartialView();
        }
        public PartialViewResult part_SongNganh()
        {
            return PartialView();
        }
        public PartialViewResult part_LienXuyen()
        {
            return PartialView();
        }
        public PartialViewResult part_TrungCap()
        {
            return PartialView();
        }
        public PartialViewResult part_QuocTe()
        {
            return PartialView();
        }
        public PartialViewResult part_Anh()
        {
            return PartialView();
        }
        public PartialViewResult part_Sinh()
        {
            return PartialView();
        }
        public PartialViewResult part_Ly()
        {
            return PartialView();
        }
        public PartialViewResult part_Hoa()
        {
            return PartialView();
        }
        public PartialViewResult part_Toan()
        {
            return PartialView();
        }
        public PartialViewResult part_BoDeThi()
        {
            return PartialView();
        }
        public ActionResult ChiTietBoDeThi(string id)
        {
            Session["id_chitietdethi"] = id;
            return View();
        }

        public ActionResult VongQuanhNTTU()
        {
            return View();
        }


    }
}