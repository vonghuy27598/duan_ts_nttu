using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class HocSinh_TK
    {
        public int? ID_HS { get; set; }
        public string HOTENHS { get; set; }
       
        public bool? GIOITINH { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public string TRUONGCAP3 { get; set; }
        public int? ID_CHUYENNGANH { get; set; }
        public int? ID_TK { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public bool? ADMIN { get; set; }
        public string CODE { get; set; }
    }
}