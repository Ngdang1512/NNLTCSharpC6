using System;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public delegate int SoSanhDelegate(object obj1, object obj2);

    public class Sach
    {
        public string TenSach { get; set; }
        public int NamXuatBan { get; set; }

        public Sach(string ten, int nam)
        {
            TenSach = ten;
            NamXuatBan = nam;
        }

        public override string ToString()
        {
            return $"Sach: {TenSach,-20} | Nam XB: {NamXuatBan}";
        }

        public static int SoSanhTheoNamXB(object a, object b)
        {
            Sach s1 = a as Sach;
            Sach s2 = b as Sach;
            if (s1 == null || s2 == null) return 0;

            return s1.NamXuatBan.CompareTo(s2.NamXuatBan);
        }

        public static int SoSanhTheoTen(object a, object b)
        {
            Sach s1 = a as Sach;
            Sach s2 = b as Sach;
            if (s1 == null || s2 == null) return 0;

            return s1.TenSach.CompareTo(s2.TenSach);
        }
    }

    public class MangTongQuatDelegate
    {
        public static void MySort(object[] mang, SoSanhDelegate hamSoSanh)
        {
            for (int i = 0; i < mang.Length - 1; i++)
            {
                for (int j = i + 1; j < mang.Length; j++)
                {
                    if (hamSoSanh(mang[i], mang[j]) > 0)
                    {
                        object temp = mang[i];
                        mang[i] = mang[j];
                        mang[j] = temp;
                    }
                }
            }
        }
    }

    public class Bai3_3
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.3: MO PHONG ARRAY.SORT BANG DELEGATE ---");

            Sach[] thuVien = new Sach[]
            {
                new Sach("Lap trinh C#", 2024),
                new Sach("Co so du lieu", 2019),
                new Sach("Tri tue nhan tao", 2026),
                new Sach("He dieu hanh", 2021)
            };

            Console.WriteLine("[1] Danh sach sach ban dau:");
            InDanhSach(thuVien);

            Console.WriteLine("\n[2] Sap xep theo NAM XUAT BAN (Tang dan):");
            MangTongQuatDelegate.MySort(thuVien, Sach.SoSanhTheoNamXB);
            InDanhSach(thuVien);

            Console.WriteLine("\n[3] Sap xep theo TEN SACH (A -> Z):");
            MangTongQuatDelegate.MySort(thuVien, Sach.SoSanhTheoTen);
            InDanhSach(thuVien);
        }

        private static void InDanhSach(object[] ds)
        {
            foreach (object item in ds)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}