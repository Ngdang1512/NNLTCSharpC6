using System;
using Lab02_ThucHanh02.Phan1_LopCoBan;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class DayPhanSo
    {
        private int n;
        private PhanSo[] danhSach;

        public DayPhanSo()
        {
            n = 0;
            danhSach = new PhanSo[0];
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong phan so (n): ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                n = 1;
            }

            danhSach = new PhanSo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhap phan so thu {i + 1} ---");
                Console.Write("Nhap tu so: ");
                int tu = int.Parse(Console.ReadLine());

                Console.Write("Nhap mau so: ");
                int mau = int.Parse(Console.ReadLine());

                danhSach[i] = new PhanSo(tu, mau);
            }
        }

        public void Xuat()
        {
            if (n == 0) return;

            Console.Write("Day phan so vua nhap: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(danhSach[i]);
                if (i < n - 1) Console.Write(" ; ");
            }
            Console.WriteLine();
        }

        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1);

            for (int i = 0; i < n; i++)
            {
                tong = tong + danhSach[i];
            }

            return tong;
        }
    }

    public class Bai2_6
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.6 (2.4 cu): DAY PHAN SO ---");
            DayPhanSo dayPS = new DayPhanSo();

            Console.WriteLine("[1] Nhap thong tin:");
            dayPS.Nhap();

            Console.WriteLine("\n[2] Xuat thong tin:");
            dayPS.Xuat();

            Console.WriteLine("\n[3] Tinh tong:");
            PhanSo tong = dayPS.TinhTong();
            Console.WriteLine($"=> Tong cua {dayPS.GetType().Name} tren la: {tong}");
        }
    }
}