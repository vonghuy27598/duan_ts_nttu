using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTS.XuLy
{
    public class DHNN
    {
        double toan, vatly, hoahoc, nguvan, lichsu, dialy, sinhhoc, anhvan;
        string[] list_nganh;
        int[] A00;
        int[] A01;
        int[] A02;
        int[] B00;
        int[] C00;
        int[] D01;
        int[] D07;
        int[] D08;
        int[] D14;
        int[] D15;
        int[] H00;
        int[] H01;
        int[] V00;
        int[] V01;
        int[] N00;
        int[] N01;
        int[] N05;

        public DHNN()
        {
            toan = vatly = hoahoc = nguvan = lichsu = dialy = sinhhoc = anhvan = 0.0;
            list_nganh = new string[] { "Y khoa", "Y học dự phòng", "Dược học", "Điều dưỡng", "Kỹ thuật y sinh", "Vật lý y khoa", "Kỹ thuật xét nghiệm y học", "Công nghệ sinh học", "Công nghệ thực phẩm", "Công nghệ kỹ thuật hóa học", "Quản lý tài nguyên và môi trường", "Công nghệ kỹ thuật ô tô", "Công nghệ kỹ thuật cơ điện tử", "Công nghệ kỹ thuật điện - điện tử", "Kỹ thuật hệ thống cồng nghiệp", "Công nghệ thông tin", "Mạng máy tính và truyền thông dữ liệu", "Kỹ thuật phân mềm", "Kỹ thuật xây dựng", "Kiến trúc", "Thiết kế nội thất", "Kế toán", "Tài chính - Ngân hàng", "Quản trị kinh doanh", "Quản trị nhân lực", "Luật kinh tế", "Logistic và Quản lý chuôi cung ứng", "Marketing", "Thương mại điện tử", "Kinh doanh quốc tế", "Quan hệ quốc tế", "Tâm lý học", "Quan hệ công chúng", "Quản trị khách sạn", "Quản trị nhà hàng và dịch vụ ăn uống", "Du lịch", "Việt Nam học", "Đông phương học", "Tiếng Việt và văn hóa Việt Nam", "Ngôn ngữ Anh", "Ngôn ngữ Trung Quốc", "Truyền thông đa phương tiện", "Thiết kế đồ họa", "Thanh nhạc", "Piano", "Đạo diên điện ảnh, truyền hình", "Diên viên kịch, điện ảnh, truyền hình", "Quay phim" };
            A00 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 29, 33, 34 };
            A01 = new int[] { 2, 3, 4, 5, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 32, 33, 34 };
            A02 = new int[] { 4, 5 };
            B00 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 31 };
            C00 = new int[] { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41 };
            D01 = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41 };
            D07 = new int[] { 2, 3, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
            D08 = new int[] { 6, 7 };
            D14 = new int[] { 30, 31, 32, 35, 36, 37, 38, 39, 40, 41 };
            D15 = new int[] { 30, 35, 36, 37, 38, 39, 40, 41 };
            H00 = new int[] { 19, 20, 42 };
            H01 = new int[] { 19, 20, 42 };
            V00 = new int[] { 19, 20, 42 };
            V01 = new int[] { 19, 20, 42 };
            N00 = new int[] { 44 };
            N01 = new int[] { 43 };
            N05 = new int[] { 45, 46, 47 };
        }
        public void set_Diem(double t, double vl, double hh, double nv, double ls, double dl, double sh, double av)
        {
            toan = t;
            vatly = vl;
            hoahoc = hh;
            nguvan = nv;
            lichsu = ls;
            dialy = dl;
            sinhhoc = sh;
            anhvan = av;
        }

        public void add_Nganh_ID(List<int> _list, int[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                if (_list.Count == 0)
                    _list.Add(ds[i]);
                else
                {
                    if (_list.Contains(ds[i]) == false)
                        _list.Add(ds[i]);
                }
            }
        }

        public List<int> check_Diem()
        {
            List<int> list_ = new List<int>();
            if (toan + vatly + hoahoc >= 18)
                add_Nganh_ID(list_, A00);
            if (toan + vatly + anhvan >= 18)
                add_Nganh_ID(list_, A01);
            if (toan + vatly + sinhhoc >= 18)
                add_Nganh_ID(list_, A02);
            if (toan + hoahoc + sinhhoc >= 18)
                add_Nganh_ID(list_, B00);
            if (nguvan + lichsu + dialy >= 18)
                add_Nganh_ID(list_, C00);
            if (toan + nguvan + anhvan >= 18)
                add_Nganh_ID(list_, D01);
            if (toan + hoahoc + anhvan >= 18)
                add_Nganh_ID(list_, D07);
            if (toan + sinhhoc + anhvan >= 18)
                add_Nganh_ID(list_, D08);
            if (nguvan + lichsu + anhvan >= 18)
                add_Nganh_ID(list_, D14);
            if (nguvan + dialy + anhvan >= 18)
                add_Nganh_ID(list_, D15);
            if (nguvan >= 6)
            {
                add_Nganh_ID(list_, H00);
                add_Nganh_ID(list_, N00);
                add_Nganh_ID(list_, N01);
                add_Nganh_ID(list_, N05);
            }
            if (toan + nguvan >= 12)
            {
                add_Nganh_ID(list_, H01);
                add_Nganh_ID(list_, V01);
            }
            if (toan + vatly >= 12)
                add_Nganh_ID(list_, V00);
            return list_;
        }

        public string[] get_list_Nganh()
        {
            List<int> list_ = new List<int>();
            list_ = check_Diem();
            int count = list_.Count;
            if (count == 0) return null;
            list_.Sort();
            string[] list_ten = new string[count];
            int i = 0;
            foreach (int item in list_)
            {
                list_ten[i] = list_nganh[item];
                i++;
            }
            return list_ten;
        }
    }
}