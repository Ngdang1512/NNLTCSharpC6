using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh01
{
    public class MangHaiChieu
    {
        private int[,] A;
        private int n;
        private int m;

        public void SinhMangNgauNhien()
        {
            Console.Write("Nhap so dong (n): ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Nhap so cot (m): ");
            m = int.Parse(Console.ReadLine());

            A = new int[n, m];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = rand.Next(10, 101);
                }
            }
        }

        public void InMang()
        {
            if (A == null) return;

            Console.WriteLine("\n--- Ma tran duoc sinh ngau nhien ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void TraVeMangChanLe(out int[] mangChan, out int[] mangLe)
        {
            List<int> danhSachChan = new List<int>();
            List<int> danhSachLe = new List<int>();

            if (A != null)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (A[i, j] % 2 == 0)
                        {
                            danhSachChan.Add(A[i, j]);
                        }
                        else
                        {
                            danhSachLe.Add(A[i, j]);
                        }
                    }
                }
            }

            mangChan = danhSachChan.ToArray();
            mangLe = danhSachLe.ToArray();
        }
    }

    public class Bai17
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 17: MANG 2 CHIEU VA SO NGAU NHIEN ---");
            MangHaiChieu mang = new MangHaiChieu();

            mang.SinhMangNgauNhien();
            mang.InMang();

            mang.TraVeMangChanLe(out int[] chan, out int[] le);

            Console.WriteLine("\nCac so chan trong mang la:");
            Console.WriteLine(string.Join(", ", chan));

            Console.WriteLine("\nCac so le trong mang la:");
            Console.WriteLine(string.Join(", ", le));
        }
    }
}