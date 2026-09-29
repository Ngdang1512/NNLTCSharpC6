using System;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class DaySo
    {
        private int[] a;
        private int n;

        public DaySo()
        {
            n = 0;
            a = new int[0];
        }

        public DaySo(int kichThuoc)
        {
            n = kichThuoc;
            a = new int[n];
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < n)
                {
                    return a[i];
                }
                throw new IndexOutOfRangeException("Chi so vuot qua pham vi mang!");
            }
            set
            {
                if (i >= 0 && i < n)
                {
                    a[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua pham vi mang!");
                }
            }
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong phan tu cua day (n): ");
            if (int.TryParse(Console.ReadLine(), out int soLuong) && soLuong > 0)
            {
                n = soLuong;
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"a[{i}] = ");
                    a[i] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Day so rong.");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + "\t");
            }
            Console.WriteLine();
        }

        public void TimSoChan()
        {
            Console.Write("Cac so chan trong day la: ");
            bool coSoChan = false;

            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    Console.Write(a[i] + "\t");
                    coSoChan = true;
                }
            }

            if (!coSoChan)
            {
                Console.Write("Khong co so chan nao.");
            }
            Console.WriteLine();
        }
    }

    public class Bai2_3
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.3: LOP MANG 1 CHIEU ---");

            DaySo ds = new DaySo();

            Console.WriteLine("[1] Nhap day so:");
            ds.Nhap();

            Console.WriteLine("\n[2] Xuat day so vua nhap:");
            ds.Xuat();

            Console.WriteLine("\n[3] Tim so chan:");
            ds.TimSoChan();

            Console.WriteLine("\n[4] Kiem tra Indexer (Thay doi phan tu vi tri 0 thanh 999):");
            if (ds != null)
            {
                try
                {
                    ds[0] = 999;
                    ds.Xuat();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }
    }
}