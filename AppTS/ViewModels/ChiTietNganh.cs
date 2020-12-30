using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class ChiTietNganh
    {
        public int? ID_CHUYENNGANH { get; set; }
        public int? ID_NGANH { get; set; }
        public string HINHANH_NGANH { get; set; }
        public string TENCHUYENNGANH { get; set; }
        public string MOTA { get; set; }
        public string HINHANH_CHUYENNGANH { get; set; }
        public string MUCTIEU { get; set; }
        public string DIEMNOIBAT { get; set; }
        public string COHOI { get; set; }
        
    }
}