using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.Areas.Admin.Models.ViewModel
{
    public class SinhVien
    {
        public int? ID_HS { get; set; }
        public string HOTENHS { get; set; }
      
        public bool GIOITINH { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public int? ID_CHUYENNGANH { get; set; }
        public string TENCHUYENNGANH { get; set; }
        public int? ID_TK { get; set; }
    }
}