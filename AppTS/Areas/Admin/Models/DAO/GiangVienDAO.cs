using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.Areas.Admin.Models.ViewModel;
namespace AppTS.Areas.Admin.Models.DAO
{
    public class GiangVienDAO
    {
        public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();


        #region DAO Giảng viên KHOA
        //Lấy dữ liệu danh sách giảng viên khoa CNTT

        public static List<GiangVien> getDataGV_KHOA()
        {
            var model = from a in db.Table_GiangViens
                        select new GiangVien()
                        {
                            ID_GV = a.ID_GV,
                            HOGV = a.HOGV,
                            TENGV = a.TENGV,
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            HOCVI = a.HOCVI

                        };
            return model.OrderBy(m => m.ID_GV).ToList();
        }

        //Lấy thông tin giảng viên theo id
        public static List<GiangVien> getDataGV_KHOA_byIDGV(int id_gv)
        {
            var model = from a in db.Table_GiangViens
                        where a.ID_GV == id_gv
                        select new GiangVien()
                        {
                            ID_GV = a.ID_GV,
                            HOGV = a.HOGV,
                            TENGV = a.TENGV,
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            HOCVI = a.HOCVI

                        };
            return model.OrderBy(m => m.ID_GV).ToList();
        }

        //Lấy danh sách giảng viên theo chuyên ngành
        public static List<GiangVien> getDataGV_KHOA_byNganh(int id_nganh)
        {
            var model = from a in db.Table_GiangViens
                        where a.ID_CHUYENNGANH == id_nganh
                        select new GiangVien()
                        {
                            ID_GV = a.ID_GV,
                            HOGV = a.HOGV,
                            TENGV = a.TENGV,
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            HOCVI = a.HOCVI
                        };
            return model.OrderBy(m => m.ID_GV).ToList();
        }
        #endregion

        #region DAO Giảng viên Doanh nghiệp

        //Lấy dữ liệu danh sách giảng viên khoa CNTT

        public static List<GiangVien> getDataGV_DOANHNGHIEP()
        {
            var model = from a in db.Table_GiangVienDNs
                        select new GiangVien()
                        {
                            ID_GV = a.ID_GVDN,
                            HOGV = a.HOGVDN,
                            TENGV = a.TENGVDN,
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                           
                            HOCVI = a.HOCVI

                        };
            return model.OrderBy(m => m.ID_GV).ToList();
        }

        //Lấy thông tin giảng viên theo id
        public static List<GiangVien> getDataGV_DOANHNGHIEP_byIDGV(int id_gv)
        {
            var model = from a in db.Table_GiangVienDNs
                        where a.ID_GVDN == id_gv
                        select new GiangVien()
                        {
                            ID_GV = a.ID_GVDN,
                            HOGV = a.HOGVDN,
                            TENGV = a.TENGVDN,
                            GIOITINH = (bool)a.GIOITINH,
                            NGAYSINH = (DateTime)a.NGAYSINH,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            DIACHI = a.DIACHI,
                         
                            HOCVI = a.HOCVI

                        };
            return model.OrderBy(m => m.ID_GV).ToList();
        }

       

        #endregion

    }
}