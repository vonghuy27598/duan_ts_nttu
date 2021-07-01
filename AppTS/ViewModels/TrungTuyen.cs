using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class TrungTuyen
    {
        [DisplayName("Mã học sinh")]
        public int ID { get; set; }
        [DisplayName("Tên học sinh")]
        public string HOTEN { get; set; }
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }
        [DisplayName("Tên ngành")]
        public string TENCHUYENNGANH { get; set; }
        [DisplayName("Tên khối")]
        public string TENTOHOP { get; set; }
        [DisplayName("Ngày đăng ký")]
        public DateTime? NGAYDANGKY { get; set; }
        public string Email { get; set; }
        public string Truong { get; set; }
        public string DiaChi { get; set; }
        public double? TongDiem { get; set; }
        public bool? Flag { get; set; }
    }
}