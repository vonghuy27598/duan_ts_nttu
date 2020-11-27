using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.Areas.Admin.Models.ViewModel
{
    public class Admin
    {
        public int? ID_ADMIN { get; set; }
        public string HOADMIN { get; set; }
        public string TENADMIN { get; set; }
        public bool GIOITINH { get; set; }
        public string SDT { get; set; }
        public string EMAIl { get; set; }
        public int? ID_TK { get; set; }
    }
}