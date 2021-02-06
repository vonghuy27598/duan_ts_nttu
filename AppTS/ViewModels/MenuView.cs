using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class MenuView
    {
        public static bool URL = false;
        public int? ID_NGANH { get; set; }
        public int? ID_CHUYENNGANH { get; set; }
        public string TENNGANH { get; set; }
        public string TENCHUYENNGANH { get; set; }
        public string MOTA { get; set; }
        public string HINHANH { get; set; }
        public int? SOLUONG { get; set; }
        public int? MANGANH { get; set; }
        public string TOHOP { get; set; }
    }
}