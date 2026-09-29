using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh01
{
    public class MangSoNguyen
    {
        private int[] a;
        private int n;

        public void NhapMang()
        {
            Console.Write("Nhap so phan tu cua mang (n): ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                n = 0;
                Console.WriteLine("So phan tu khong hop le!");
                return;
            }

            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap phan tu a[{i}]: ");
                a[i] = int.Parse(Console.ReadLine());
            }
        }

        public void InMang()
        {
            if (n == 0) return;
            Console.Write("Cac phan tu trong mang: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        public void TimMaxMin(out int max, out int min)
        {
            if (n == 0)
            {
                max = 0; min = 0; return;
            }

            max = a[0];
            min = a[0];
            for (int i = 1; i < n; i++)
            {
                if (a[i] > max) max = a[i];
                if (a[i] < min) min = a[i];
            }
        }

        private bool LaNguyenTo(int so)
        {
            if (so < 2) return false;
            for (int i = 2; i <= Math.Sqrt(so); i++)
            {
                if (so % i == 0) return false;
            }
            return true;
        }

        public int[] LayMangSoNguyenTo()
        {
            List<int> danhSachNT = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (LaNguyenTo(a[i]) && !danhSachNT.Contains(a[i]))
                {
                    danhSachNT.Add(a[i]);
                }
            }

            return danhSachNT.ToArray();
        }
    }

    public class Bai15
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 15: THAO TAC VOI MANG ---");
            MangSoNguyen mang = new MangSoNguyen();

            mang.NhapMang();
            mang.InMang();

            mang.TimMaxMin(out int max, out int min);
            Console.WriteLine($"\nPhan tu lon nhat la: {max}");
            Console.WriteLine($"Phan tu nho nhat la: {min}");

            int[] mangNT = mang.LayMangSoNguyenTo();
            Console.Write("\nCac so nguyen to co trong mang la: ");
            if (mangNT.Length > 0)
            {
                foreach (int so in mangNT)
                {
                    Console.Write(so + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Khong co so nguyen to nao.");
            }
        }
    }
}