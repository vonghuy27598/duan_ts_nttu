using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.Areas.Admin.Models.ViewModel;
namespace AppTS.Areas.Admin.Models.DAO
{
    public class SinhVienDAO
    {
        
        public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        //Lấy danh sách thông tin sinh viên
        public static List<SinhVien> getDataSV()
        {
            var model = from a in db.Table_HocSinhs
                        join b in db.Table_ChuyenNganhs
                        on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        select new SinhVien(){
                            ID_HS = a.ID_HS,
                            HOTENHS = a.HOTENHS,
                          
                            GIOITINH =(bool) a.GIOITINH,
                            NGAYSINH = (DateTime) a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH
                          
                        };
            return model.OrderBy(m=>m.ID_HS).ToList();
        }

        //Lấy thông tin sinh viên theo id
        public static List<SinhVien> getDataSV_byID(int ID_SV)
        {
            var model = from a in db.Table_HocSinhs
                        join b in db.Table_ChuyenNganhs
                        on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where a.ID_HS  == ID_SV
                        select new SinhVien()
                        {
                            ID_HS = a.ID_HS,
                            HOTENHS = a.HOTENHS,
                          
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH

                        };
            return model.OrderBy(m => m.ID_HS).ToList();
        }

        //Lọc sinh viên theo ngành
        public static List<SinhVien> getSinhVien_byIDNGANH(int ID_CHUYENNGANH)
        {
           var model = from a in db.Table_HocSinhs
                        join b in db.Table_ChuyenNganhs
                        on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where a.ID_CHUYENNGANH == ID_CHUYENNGANH
                        select new SinhVien(){
                            ID_HS = a.ID_HS,
                            HOTENHS = a.HOTENHS,
                         
                            GIOITINH =(bool) a.GIOITINH,
                            NGAYSINH = (DateTime) a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH
                          
                        };
            return model.OrderBy(m=>m.ID_HS).ToList();
        }
        

    }
}