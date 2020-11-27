using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppTS.ViewModels
{
    public class ChuyenNganhFull
    {
        public int? ID_CTCN { get; set; }
        [DisplayName("Mã chuyên ngành")]
        public int? ID_CHUYENNGANH { get; set; }
        [DisplayName("Tên chuyên ngành")]
        [Required(ErrorMessage = "Tên chuyên ngành không được rỗng")]
        public string TENCHUYENNGANH { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Chi tiết không được rỗng")]
        public string MOTA { get; set; }
        [DisplayName("Số lượng")]
        public int? SOLUONGSV { get; set; }
        public string HINHANH { set; get; }
        [DisplayName("Ngành")]
        public int? ID_NGANH { get; set; }
        public int? SOLUONG { get; set; }
        public string TENNGANH { get; set; }
    }
}