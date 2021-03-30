using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.ViewModels
{
    public class ThacSi
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int Id_Nganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int? Nam { get; set; }
    }
}