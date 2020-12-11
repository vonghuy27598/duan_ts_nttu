using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppTS.ViewModels
{
    public class ChuyenNganh
    {
        public int? ID_CHUYENNGANH { get; set; }
        //[DisplayName("Tên chuyên ngành")]
        //[Required(ErrorMessage = "Tên chuyên ngành không được rỗng")]
        public string TENCHUYENNGANH { get; set; }
        public string MOTA { get; set; }
        public int? ID_NGANH { get; set; }
        public int? SOLUONGSV { get; set; }
        public int? MANGANH { get; set; }
        public string TOHOP { get; set; }
    }
}