using AppTS.Models;
using AppTS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.XuLy
{
    public class ListThacSi
    {
        public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public static List<ThacSi> getDanhSach()
        {
            var model = from a in db.Table_dkThacSis
                        select new ThacSi()
                        {
                            Id = a.ID_USER,
                            HoTen = a.HOTEN,
                            SDT = a.SDT,
                            TenChuyenNganh = a.TENNGANH,
                            Nam = a.NAM
                        };
            return model.OrderBy(m => m.Id).ToList();
        }

        public static List<ThacSi> getDanhSach_byDate(DateTime date)
        {
            var model = from a in db.Table_dkThacSis
                        where a.NAM == date.Year
                        select new ThacSi()
                        {
                            Id = a.ID_USER,
                            HoTen = a.HOTEN,
                            SDT = a.SDT,
                            TenChuyenNganh = a.TENNGANH,
                            Nam = a.NAM
                        };
            return model.OrderBy(m => m.Id).ToList();
        }
    }
}