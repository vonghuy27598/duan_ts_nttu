using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.Areas.Admin.Models.ViewModel
{
    public class Nganh
    {
        //Ngành
        public int? ID_NGANH { get; set; }
        public string TENNGANH { get; set; }
        public string MOTA { get; set; }
        public int SOLUONGSV { get; set; }

        //Chuyên ngành
        public int? ID_CHUYENNGANH { get; set; }
        public string TENCHUYENNGANH { get; set; }


    }
}