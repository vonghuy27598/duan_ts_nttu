using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.ViewModels;

namespace AppTS.XuLy
{
    public class CNganh
    {
        public static List<ChuyenNganhFull> ChuyenNganhFull()
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = (from a in data.Table_ChuyenNganhs
                         join b in data.Table_Nganhs on a.ID_NGANH equals b.ID_NGANH
                         select new ChuyenNganhFull()
                         {
                             ID_NGANH = b.ID_NGANH,
                             ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                             TENCHUYENNGANH = a.TENCHUYENNGANH,
                             TENNGANH = b.TENNGANH,
                             SOLUONG = (data.Table_ChuyenNganhs.Where(m => m.ID_NGANH == b.ID_NGANH).Count()),

                         }).Distinct();
            return model.OrderBy(m => m.ID_CHUYENNGANH).ToList();
        }

        public static List<ChuyenNganhFull> ChuyenNganhFull_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_ChuyenNganhs
                        join b in data.Table_Nganhs on a.ID_NGANH equals b.ID_NGANH
                        where a.ID_CHUYENNGANH == id
                        select new ChuyenNganhFull()
                        {
                            ID_NGANH = b.ID_NGANH,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = a.TENCHUYENNGANH,
                            TENNGANH = b.TENNGANH,
                        };
            return model.OrderByDescending(m => m.ID_CHUYENNGANH).ToList();
        }
        public static List<ChuyenNganhFull> ChuyenNganhFull_byID_select(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_ChuyenNganhs
                        join b in data.Table_Nganhs on a.ID_NGANH equals b.ID_NGANH
                        where a.ID_NGANH == id
                        select new ChuyenNganhFull()
                        {
                            ID_NGANH = b.ID_NGANH,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = a.TENCHUYENNGANH,
                            TENNGANH = b.TENNGANH,
                        };
            return model.OrderByDescending(m => m.ID_CHUYENNGANH).ToList();
        }
        public static List<ChuyenNganhFull> ChuyenNganhFull_byNAMEGROUP_child(string TENNGANH)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_ChuyenNganhs
                        join b in data.Table_Nganhs on a.ID_NGANH equals b.ID_NGANH
                        where b.TENNGANH == TENNGANH
                        select new ChuyenNganhFull()
                        {
                            ID_NGANH = b.ID_NGANH,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            TENCHUYENNGANH = a.TENCHUYENNGANH,
                            TENNGANH = b.TENNGANH,
                        };
            return model.OrderBy(m => m.ID_CHUYENNGANH).ToList();
        }

        public List<string> ListName(string keyword)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            return data.Table_ChuyenNganhs.Where(x => x.TENCHUYENNGANH.Contains(keyword)).Select(x => x.TENCHUYENNGANH).ToList();
        }

        public static List<ChuyenNganhFull> Search(string keyword)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = (from a in data.Table_ChuyenNganhs
                         join b in data.Table_Nganhs on a.ID_NGANH equals b.ID_NGANH
                         where a.TENCHUYENNGANH.Contains(keyword)
                         select new ChuyenNganhFull()
                         {
                             ID_NGANH = b.ID_NGANH,
                             ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                             TENCHUYENNGANH = a.TENCHUYENNGANH,
                             TENNGANH = b.TENNGANH,
                         }).Distinct();
            return model.OrderBy(m => m.TENCHUYENNGANH).ToList();
        }

        public static List<ChuyenNganhFull> getChiTiet_ByIDCN(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_ChuyenNganhs
                        join b in data.Table_CTCNs on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where b.ID_CHUYENNGANH == id
                        select new ChuyenNganhFull()
                        {
                            ID_NGANH = a.ID_NGANH,
                            ID_CTCN = b.ID_CTCN,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            MOTA = b.MOTA,
                            HINHANH = b.HINHANH,
                            TENCHUYENNGANH = a.TENCHUYENNGANH,
                        };
            return model.OrderBy(m => m.ID_CTCN).ToList();
        }
    }
}