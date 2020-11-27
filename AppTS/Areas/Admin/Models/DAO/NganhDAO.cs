using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.Areas.Admin.Models.ViewModel;
namespace AppTS.Areas.Admin.Models.DAO
{
    public class NganhDAO
    {
       public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        ////Lấy dữ liệu ngành
        //public static List<Nganh> getNganh(){
        //    var model = from a in db.Table_Nganhs
        //                select new Nganh(){
        //                    ID_NGANH = a.ID_NGANH,
        //                    TENNGANH = a.TENNGANH,
        //                    SOLUONGSV = (from b in db.Table_HocSinhs where b.ID_NGANH == a.ID_NGANH select b).Count(),
        //                };
        //    return model.OrderBy(m=>m.ID_NGANH).ToList();
        //}

        //Lấy dữ liệu chuyên ngành

        public static List<Nganh> getChuyenNganh()
        {
            var model = from a in db.Table_Nganhs
                        join b in db.Table_ChuyenNganhs
                        on a.ID_NGANH equals b.ID_NGANH
                        select new Nganh()
                        {
                            ID_NGANH = a.ID_NGANH,
                            TENNGANH = a.TENNGANH,
                            ID_CHUYENNGANH = b.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            SOLUONGSV = (from c in db.Table_HocSinhs where c.ID_CHUYENNGANH == b.ID_CHUYENNGANH select c).Count(),
                        };
            return model.OrderBy(m => m.ID_NGANH).ToList();
        }
    }
}