﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
using AppTS.ViewModels;

namespace AppTS.XuLy
{
    public class HocSinh
    {
        public static List<HocSinh_TK> GetInfoHS_byIDTK(int ID_TK)
        {
            dbQL_NTTDataContext db = new dbQL_NTTDataContext();
            var model = from a in db.Table_HocSinhs
                        join b in db.Table_TaiKhoans on a.ID_TK equals b.ID_TK
                        where a.ID_TK == ID_TK
                        select new HocSinh_TK()
                        {
                            ID_HS = a.ID_HS,
                            ID_TK = a.ID_TK,
                            HOTENHS = a.HOTENHS,
                            DIACHI = a.DIACHI,
                            TRUONGCAP3 = a.TRUONGCAP3,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                            PASSWORD = b.PASSWORD,
                            ADMIN = b.ADMIN,
                            NGAYSINH = a.NGAYSINH,
                            USERNAME = b.USERNAME
                        };
            return model.ToList();
        }

        public static List<HocSinh_TK> GetInfoHS_bySDT(string SDT)
        {
            dbQL_NTTDataContext db = new dbQL_NTTDataContext();
            var model = from a in db.Table_HocSinhs
                        where a.SDT == SDT
                        select new HocSinh_TK()
                        {
                            ID_HS = a.ID_HS,
                            ID_TK = a.ID_TK,
                            HOTENHS = a.HOTENHS,
                            DIACHI = a.DIACHI,
                            TRUONGCAP3 = a.TRUONGCAP3,
                            SDT = a.SDT,
                            EMAIL = a.EMAIL,
                            NGAYSINH = a.NGAYSINH,
                            ID_CHUYENNGANH = a.ID_CHUYENNGANH
                        };
            return model.ToList();
        }

        public static List<LichSuXetTuyen> getLichSuDangKy(string SDT)
        {
            dbQL_NTTDataContext db = new dbQL_NTTDataContext();
            var model = from a in db.Table_ChuyenNganhs
                        join b in db.Table_TrungTuyens
                        on a.ID_CHUYENNGANH equals b.ID_CHUYENNGANH
                        where b.SDT == SDT
                        select new LichSuXetTuyen()
                        {
                           ID_CHUYENNGANH = a.ID_CHUYENNGANH,
                           MANGANH = (int) a.MANGANH,
                           NGAYDANGKY = (DateTime)b.NGAYDANGKY,
                           TENCHUYENNGANH = a.TENCHUYENNGANH,
                           SODIENTHOAI = b.SDT,
                        };
            return model.OrderByDescending(m=>m.NGAYDANGKY).ToList();
        }

        public static List<string> ListName_Truong(string a)
        {
           
           Data_TruongPTTH data_truong  =  new Data_TruongPTTH();
           string[] data = data_truong.data_thpt;           
           return data.Where(x => x.ToLower().Contains(a.ToLower())).Select(x => x).Distinct().ToList();
                
        }
    }
}