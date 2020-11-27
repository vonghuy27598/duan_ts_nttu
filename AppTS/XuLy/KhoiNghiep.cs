using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.ViewModels;
using AppTS.XuLy;

namespace AppTS.XuLy
{
    public class KhoiNghiep
    {
        public static List<KhoiNghiepFull> KhoiNghiepFull()
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = (from a in data.Table_KhoiNghieps
                         select new KhoiNghiepFull()
                         {
                             ID_KHOINGHIEP = a.ID_KHOINGHIEP,
                             TENKHOINGHIEP = a.TENKHOINGHIEP,
                         }).Distinct();
            return model.OrderBy(m => m.ID_KHOINGHIEP).ToList();
        }

        public static List<KhoiNghiepFull> KhoiNghiepFull_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_KhoiNghieps
                        where a.ID_KHOINGHIEP == id
                        select new KhoiNghiepFull()
                        {
                            ID_KHOINGHIEP = a.ID_KHOINGHIEP,
                            TENKHOINGHIEP = a.TENKHOINGHIEP,
                        };
            return model.OrderByDescending(m => m.ID_KHOINGHIEP).ToList();
        }
        public static List<KhoiNghiepFull> getchitiet_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_KhoiNghieps
                        join c in data.Table_CTKNs on a.ID_KHOINGHIEP equals c.ID_KHOINGHIEP
                        where c.ID_KHOINGHIEP == id
                        select new KhoiNghiepFull()
                        {
                            ID_CTKN = c.ID_CTKN,
                            ID_KHOINGHIEP = a.ID_KHOINGHIEP,
                            MOTA = c.MOTA,
                            HINHANH = c.HINHANH,
                            TENKHOINGHIEP = a.TENKHOINGHIEP,
                        };
            return model.OrderByDescending(m => m.ID_KHOINGHIEP).ToList();
        }
    }
}