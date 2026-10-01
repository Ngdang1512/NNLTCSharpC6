using System;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public interface ISoSanh
    {
        int SoSanh(object obj);
    }

    public class SanPham : ISoSanh
    {
        public string TenSP { get; set; }
        public double Gia { get; set; }

        public SanPham(string ten, double gia)
        {
            TenSP = ten;
            Gia = gia;
        }

        public int SoSanh(object obj)
        {
            SanPham spKhac = obj as SanPham;
            if (spKhac == null) return 1;

            return this.Gia.CompareTo(spKhac.Gia);
        }

        public override string ToString()
        {
            return $"San pham: {TenSP,-15} | Gia: {Gia,10:N0} VND";
        }
    }

    public class MangTongQuat
    {
        public static void MySort(object[] mang)
        {
            for (int i = 0; i < mang.Length - 1; i++)
            {
                for (int j = i + 1; j < mang.Length; j++)
                {
                    ISoSanh phanTu1 = mang[i] as ISoSanh;

                    if (phanTu1 != null)
                    {
                        if (phanTu1.SoSanh(mang[j]) > 0)
                        {
                            object temp = mang[i];
                            mang[i] = mang[j];
                            mang[j] = temp;
                        }
                    }
                }
            }
        }
    }

    public class Bai3_2
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.2: MO PHONG ARRAY.SORT BANG INTERFACE ---");

            SanPham[] danhSachSP = new SanPham[]
            {
                new SanPham("Laptop Dell", 25000000),
                new SanPham("Chuot Logitech", 450000),
                new SanPham("Ban phim cơ", 1200000),
                new SanPham("Man hinh LG", 4500000)
            };

            Console.WriteLine("[1] Danh sach truoc khi sap xep:");
            InDanhSach(danhSachSP);

            MangTongQuat.MySort(danhSachSP);

            Console.WriteLine("\n[2] Danh sach SAU KHI sap xep (Theo Gia tang dan):");
            InDanhSach(danhSachSP);
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