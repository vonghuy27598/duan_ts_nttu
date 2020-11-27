using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.Areas.Admin.Models.ViewModel
{
    public class TaiKhoan
    {
        public int? ID_TK { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public bool ADMIN { get; set; }
    }
}