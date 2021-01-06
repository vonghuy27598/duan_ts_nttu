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
                        select new TrungTuyen()
                        {
                            ID = a.ID,
                            HOTEN = a.HOTEN,
                            DIACHI = a.DIACHI,
                            TRUONG = a.TRUONG,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            NGAYDANGKY = a.NGAYDANGKY,
                            TENTOHOP = a.TENTOHOP,
                            ID_CHUYENGANH = a.ID_CHUYENNGANH,
                            MON1 = a.MON1,
                            MON2 = a.MON2,
                            MON3 = a.MON3,
                            TRUNGTUYEN = a.TRUNGTUYEN
                        };
            return model.OrderBy(m => m.ID).ToList();
        }
    }
}