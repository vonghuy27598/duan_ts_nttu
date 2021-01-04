﻿using System;
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
            list_nganh = new string[] { "Y khoa (Bác sỹ Đa khoa)", "Y học dự phòng (Bác sỹ Y học dự phòng)", "Dược học", "Điều dưỡng", "Kỹ thuật y sinh", "Vật lý y khoa", "Kỹ thuật xét nghiệm y học", "Công nghệ sinh học", "Công nghệ thực phẩm", "Công nghệ kỹ thuật hóa học", "Quản lý tài nguyên và môi trường", "Công nghệ kỹ thuật Ô-tô", "Công nghệ kỹ thuật cơ điện tử", "Công nghệ Kỹ thuật Điện – Điện tử", "Kỹ thuật Hệ thống Công nghiệp", "Công nghệ thông tin", "Mạng máy tính – Truyền thông dữ liệu", "Kỹ thuật phần mềm", "Kỹ thuật xây dựng", "Kiến trúc", "Thiết kế nội thất", "Kế toán", "Tài chính – Ngân hàng", "Quản trị kinh doanh", "Quản trị nhân lực", "Luật kinh tế", "Logistics và Quản lý chuỗi cung ứng", "Marketing", "Thương mại điện tử", "Kinh doanh quốc tế", "Quan hệ quốc tế", "Tâm lý học", "Quan hệ công chúng", "Quản trị khách sạn", "Quản trị nhà hàng và dịch vụ ăn uống", "Du lịch", "Việt Nam học", "Đông phương học", "Tiếng Việt và văn hóa Việt Nam", "Ngôn ngữ Anh", "Ngôn ngữ Trung Quốc", "Truyền thông đa phương tiện", "Thiết kế đồ họa", "Thanh nhạc", "Piano", "Đạo diễn Điện ảnh – Truyền hình", "Diễn viên kịch – Điện ảnh – Truyền hình", "Quay phim" };
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
            double[] list_diemTB = new double[13];
            list_diemTB[0] = (toan + vatly + hoahoc) / 3.0;
            list_diemTB[1] = (toan + vatly + anhvan) / 3.0;
            list_diemTB[2] = (toan + vatly + sinhhoc) / 3.0;
            list_diemTB[3] = (toan + hoahoc + sinhhoc) / 3.0;
            list_diemTB[4] = (nguvan + lichsu + dialy) / 3.0;
            list_diemTB[5] = (toan + nguvan + anhvan) / 3.0;
            list_diemTB[6] = (toan + hoahoc + anhvan) / 3.0;
            list_diemTB[7] = (toan + sinhhoc + anhvan) / 3.0;
            list_diemTB[8] = (nguvan + lichsu + anhvan) / 3.0;
            list_diemTB[9] = (nguvan + dialy + anhvan) / 3.0;
            list_diemTB[10] = nguvan;
            list_diemTB[11] = (toan + nguvan) / 2.0;
            list_diemTB[12] = (toan + vatly) / 2.0;
            double max_diemTB = list_diemTB[0];
            int postion_max = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (max_diemTB < list_diemTB[i])
                {
                    max_diemTB = list_diemTB[i];
                    postion_max = i;
                }
            }

            if (postion_max == 0)
                add_Nganh_ID(list_, A00);
            if (postion_max == 1)
                add_Nganh_ID(list_, A01);
            if (postion_max == 2)
                add_Nganh_ID(list_, A02);
            if (postion_max == 3)
                add_Nganh_ID(list_, B00);
            if (postion_max == 4)
                add_Nganh_ID(list_, C00);
            if (postion_max == 5)
                add_Nganh_ID(list_, D01);
            if (postion_max == 6)
                add_Nganh_ID(list_, D07);
            if (postion_max == 7)
                add_Nganh_ID(list_, D08);
            if (postion_max == 8)
                add_Nganh_ID(list_, D14);
            if (postion_max == 9)
                add_Nganh_ID(list_, D15);
            if (postion_max == 10)
            {
                add_Nganh_ID(list_, H00);
                add_Nganh_ID(list_, N00);
                add_Nganh_ID(list_, N01);
                add_Nganh_ID(list_, N05);
            }
            if (postion_max == 11)
            {
                add_Nganh_ID(list_, H01);
                add_Nganh_ID(list_, V01);
            }
            if (postion_max == 12)
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