using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.ViewModels;
using AppTS.Models;
namespace AppTS.XuLy
{
    public class Nganh
    {
        public static List<MenuView> NganhFull()
        {
            dbQL_NTTDataContext db = new dbQL_NTTDataContext();
            var model = from a in db.Table_Nganhs
                        join b in db.Table_CTNs
                        on a.ID_NGANH equals b.ID_NGANH
                        select new MenuView()
                        {
                            ID_NGANH = a.ID_NGANH,
                            TENNGANH = a.TENNGANH,
                            MOTA = b.MOTA,
                            HINHANH = b.HINHANH,
                            SOLUONG = (db.Table_Nganhs.Where(m => m.ID_NGANH == a.ID_NGANH).Count()),
                        };
            return model.ToList();
        }
        public static List<MenuView> NganhFull_byID(int id)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_Nganhs
                        join b in data.Table_CTNs
                        on a.ID_NGANH equals b.ID_NGANH
                        where a.ID_NGANH == id
                        select new MenuView()
                        {
                            ID_NGANH = a.ID_NGANH,
                            MOTA = b.MOTA,
                            HINHANH = b.HINHANH,
                            
                            TENNGANH = a.TENNGANH,
                        };
            return model.OrderByDescending(m => m.ID_NGANH).ToList();
        }

        // get khối ngành
        public static List<MenuView> getKhoiNganh_ddl()
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_Nganhs                         
                        select new MenuView()
                        {
                           ID_NGANH = a.ID_NGANH,
                           TENNGANH = a.TENNGANH                          
                        };
            return model.OrderBy(m => m.TENNGANH).ToList();
        }

        // get tên ngành by id_khoinganh
        public static List<ChuyenNganh> getKhoiNganh(int id_khoinganh)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_Nganhs
                        join b in data.Table_ChuyenNganhs
                        on a.ID_NGANH equals b.ID_NGANH
                        where b.ID_NGANH == id_khoinganh
                        select new ChuyenNganh()
                        {
                            ID_NGANH = a.ID_NGANH,
                            ID_CHUYENNGANH = b.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            MANGANH = b.MANGANH,
                            TOHOP = b.TOHOP

                        };
            return model.OrderBy(m => m.TENCHUYENNGANH).ToList();
        }

        //get tổ hợp by id_chuyennganh
       
        public static List<ChuyenNganh> getToHop(int id_chuyennganh)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_Nganhs
                        join b in data.Table_ChuyenNganhs
                        on a.ID_NGANH equals b.ID_NGANH
                        where b.ID_CHUYENNGANH == id_chuyennganh
                        select new ChuyenNganh()
                        {
                            ID_NGANH = a.ID_NGANH,
                            ID_CHUYENNGANH = b.ID_CHUYENNGANH,
                            TENCHUYENNGANH = b.TENCHUYENNGANH,
                            MANGANH = b.MANGANH,
                            TOHOP = b.TOHOP

                        };
            return model.OrderBy(m => m.TENCHUYENNGANH).ToList();
        }

        //getMon_ToHop
        public static List<ToHop> getMon_ToHop(string tohop)
        {
            dbQL_NTTDataContext data = new dbQL_NTTDataContext();
            var model = from a in data.Table_ToHops
                        where a.TENTOHOP.Contains(tohop)
                        select new ToHop()
                        {
                           IDTOHOP = a.IDTOHOP,
                           TENTOHOP = a.TENTOHOP,
                           MON1 = a.MON1,
                           MON2 = a.MON2,
                           MON3 = a.MON3,
                        };
            return model.OrderBy(m => m.IDTOHOP).ToList();
        }
        
    }
}