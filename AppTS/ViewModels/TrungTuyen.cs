using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class TrungTuyen
    {
        public int ID { get; set; }
        public string HOTEN { get; set; }
        public string DIACHI { get; set; }
        public string TRUONG { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public DateTime? NGAYDANGKY { get; set; }
        public string TENTOHOP { get; set; }
        public int? ID_CHUYENGANH { get; set; }
        public string TENCHUYENNGANH { get; set; }
        public double? MON1 { get; set; }
        public double? MON2 { get; set; }
        public double? MON3 { get; set; }
        public bool? TRUNGTUYEN { get; set; }
    }
}