using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppTS.ViewModels
{
    public class KhoiNghiepFull
    {
        public int? ID_CTKN { get; set; }
        [DisplayName("Mã khởi nghiệp")]
        public int? ID_KHOINGHIEP { get; set; }
        [DisplayName("Tiêu đề khởi nghiệp")]
        [Required(ErrorMessage = "Tiêu đề khởi nghiệp không được rỗng")]
        public string TENKHOINGHIEP { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Chi tiết không được rỗng")]
        public string MOTA { get; set; }
        public string HINHANH { set; get; }
    }
}