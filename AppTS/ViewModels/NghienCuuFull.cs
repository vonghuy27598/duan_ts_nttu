using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppTS.ViewModels
{
    public class NghienCuuFull
    {
        public int? ID_CTNC { get; set; }
        [DisplayName("Mã nghiên cứu")]
        public int? ID_NGHIENCUU { get; set; }
        [DisplayName("Tiêu đề nghiên cứu")]
        [Required(ErrorMessage = "Tiêu đề nghiên cứu không được rỗng")]
        public string TENNGHIENCUU { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Chi tiết không được rỗng")]
        public string MOTA { get; set; }
        public string HINHANH { set; get; }
        public string ANHBIA { set; get; }
    }
}