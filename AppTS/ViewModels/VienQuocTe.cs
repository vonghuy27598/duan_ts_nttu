using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace AppTS.ViewModels
{
    public class VienQuocTe
    {
        public int id { get; set; }
        public string tennganh { get; set; }
        public string chuyennganh { get; set; }
        public string tohop { get; set; }
        public string gioithieu { get; set; }
        public string cohoi { get; set; }
        public string[] tohopmon;
        public string monhocchuyennganh { get; set; }
        public string hinhanh { get; set; }
        public string giaodien { get; set; }
        public VienQuocTe(int id, string tennganh, string chuyennganh,string tohop, string gioithieu, string cohoi, string monhocchuyennganh, string hinhanh, string giaodien)
        {
            this.id = id;
            this.tennganh = tennganh;
            this.chuyennganh = chuyennganh;
            this.tohop = tohop;
            this.gioithieu = gioithieu;
            this.cohoi = cohoi;          
            this.monhocchuyennganh = monhocchuyennganh;
            this.hinhanh = hinhanh;
            this.giaodien = giaodien;
            tohopmon = new string[] { "Toán, Vật lý, Hóa học","Toán, Vật lý, Tiếng Anh","Toán, Ngữ văn, Tiếng Anh", "Toán, Hóa học, Tiếng Anh","Ngữ văn, Lịch sử, Địa lý"};
        }
       
    }
}