using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.ViewModels;
using AppTS.Models;

namespace AppTS.XuLy
{
    public class NghienCuu
    {
        public static List<NghienCuuFull> NghienCuuFull()
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = (from a in data.Table_NghienCuus
                         select new NghienCuuFull()
                         {
                             ID_NGHIENCUU = a.ID_NGHIENCUU,
                             TENNGHIENCUU = a.TENGHIENCUU,
                             //ANHBIA = a.ANHBIA,
                         }).Distinct();
            return model.OrderBy(m => m.ID_NGHIENCUU).ToList();
        }

        public static List<NghienCuuFull> NghienCuuFull_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_NghienCuus
                        where a.ID_NGHIENCUU == id
                        select new NghienCuuFull()
                        {
                            ID_NGHIENCUU = a.ID_NGHIENCUU,
                            TENNGHIENCUU = a.TENGHIENCUU,
                            //ANHBIA = a.ANHBIA,
                        };
            return model.OrderByDescending(m => m.ID_NGHIENCUU).ToList();
        }
        public static List<NghienCuuFull> getchitiet_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_NghienCuus
                        join c in data.Table_CTNCs on a.ID_NGHIENCUU equals c.ID_NGHIENCUU
                        where c.ID_NGHIENCUU == id
                        select new NghienCuuFull()
                        {
                            ID_CTNC = c.ID_CTNC,
                            ID_NGHIENCUU = a.ID_NGHIENCUU,
                            MOTA = c.MOTA,
                            HINHANH = c.HINHANH,
                            TENNGHIENCUU = a.TENGHIENCUU,
                        };
            return model.OrderByDescending(m => m.ID_NGHIENCUU).ToList();
        }
    }
}