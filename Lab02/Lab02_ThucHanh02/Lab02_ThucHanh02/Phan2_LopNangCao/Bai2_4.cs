using System;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class MangHaiChieu
    {
        private int[,] a;
        private int n;
        private int m;

        public MangHaiChieu()
        {
            n = 0;
            m = 0;
            a = new int[0, 0];
        }

        public MangHaiChieu(int dong, int cot)
        {
            n = dong;
            m = cot;
            a = new int[n, m];
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                {
                    return a[i, j];
                }
                throw new IndexOutOfRangeException("Chi so vuot qua pham vi mang!");
            }
            set
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                {
                    a[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua pham vi mang!");
                }
            }
        }

        public void Nhap()
        {
            Console.Write("Nhap so dong (n): ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0) n = 2;

            Console.Write("Nhap so cot (m): ");
            if (!int.TryParse(Console.ReadLine(), out m) || m <= 0) m = 3;

            a = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Xuat()
        {
            if (n == 0 || m == 0)
            {
                Console.WriteLine("Mang rong.");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private bool LaNguyenTo(int so)
        {
            if (so < 2) return false;
            for (int k = 2; k <= Math.Sqrt(so); k++)
            {
                if (so % k == 0) return false;
            }
            return true;
        }

        public void TimSoNguyenTo()
        {
            Console.Write("Cac so nguyen to trong mang la: ");
            bool coSoNT = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaNguyenTo(a[i, j]))
                    {
                        Console.Write(a[i, j] + "\t");
                        coSoNT = true;
                    }
                }
            }

            if (!coSoNT)
            {
                Console.Write("Khong co so nguyen to nao.");
            }
            Console.WriteLine();
        }
    }

    public class Bai2_4
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.4: LOP MANG 2 CHIEU ---");

            MangHaiChieu mang = new MangHaiChieu();

            Console.WriteLine("[1] Nhap mang 2 chieu:");
            mang.Nhap();

            Console.WriteLine("\n[2] Xuat mang 2 chieu:");
            mang.Xuat();

            Console.WriteLine("\n[3] Tim so nguyen to:");
            mang.TimSoNguyenTo();

            Console.WriteLine("\n[4] Kiem tra Indexer 2 chieu (Gan phan tu [0,0] = 999):");
            try
            {
                mang[0, 0] = 999;
                mang.Xuat();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }
    }
}