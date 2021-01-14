using AppTS.Models;
using AppTS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.XuLy
{
    public class ListTrungTuyen
    {
        public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();

        public static List<TrungTuyen> getDanhSach()
        {
            var model = from a in db.Table_TrungTuyens
                        join b in db.Table_ChuyenNganhs on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        select new TrungTuyen()
                        {
                            ID = a.ID,
                            HOTEN = a.HOTEN,
                            SDT = a.SDT,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            TENTOHOP = a.TENTOHOP,
                            NGAYDANGKY = a.NGAYDANGKY
                        };
            return model.OrderBy(m => m.ID).ToList();
        }
        public static List<TrungTuyen> getDanhSach_toDay()
        {
            var model = from a in db.Table_TrungTuyens
                        join b in db.Table_ChuyenNganhs on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where a.NGAYDANGKY == DateTime.Now
                        select new TrungTuyen()
                        {
                            ID = a.ID,
                            HOTEN = a.HOTEN,
                            SDT = a.SDT,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            TENTOHOP = a.TENTOHOP,
                            NGAYDANGKY = a.NGAYDANGKY
                        };
            return model.OrderBy(m => m.ID).ToList();
        }

        public static List<TrungTuyen> getDanhSach_byDate(DateTime date)
        {
            var model = from a in db.Table_TrungTuyens
                        join b in db.Table_ChuyenNganhs on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where a.NGAYDANGKY == date
                        select new TrungTuyen()
                        {
                            ID = a.ID,
                            HOTEN = a.HOTEN,
                            SDT = a.SDT,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            TENTOHOP = a.TENTOHOP,
                            NGAYDANGKY = a.NGAYDANGKY
                        };
            return model.OrderBy(m => m.ID).ToList();
        }
    }
}