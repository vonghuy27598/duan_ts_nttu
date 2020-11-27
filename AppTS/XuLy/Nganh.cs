using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.ViewModels;
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
                            SOLUONG = a.SOLUONG,
                            TENNGANH = a.TENNGANH,
                        };
            return model.OrderByDescending(m => m.ID_NGANH).ToList();
        }
    }
}