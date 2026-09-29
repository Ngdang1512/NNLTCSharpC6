using System;
using Lab02_ThucHanh02.Phan1_LopCoBan;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class DaThuc
    {
        private int n;
        private DonThuc[] dsDonThuc;

        public DaThuc()
        {
            n = 0;
            dsDonThuc = new DonThuc[1];
            dsDonThuc[0] = new DonThuc(0, 0);
        }

        public DaThuc(int bac)
        {
            n = bac < 0 ? 0 : bac;
            dsDonThuc = new DonThuc[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dsDonThuc[i] = new DonThuc(0, i);
            }
        }

        public DonThuc this[int i]
        {
            get
            {
                if (i >= 0 && i <= n) return dsDonThuc[i];
                throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc!");
            }
            set
            {
                if (i >= 0 && i <= n) dsDonThuc[i] = value;
                else throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc!");
            }
        }

        public void Nhap()
        {
            Console.Write("Nhap bac cua da thuc (n): ");
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0) n = 0;

            dsDonThuc = new DonThuc[n + 1];

            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Nhap he so a cho x^{i}: ");
                double heSo = double.Parse(Console.ReadLine());
                dsDonThuc[i] = new DonThuc(heSo, i);
            }
        }

        public void Xuat()
        {
            if (n < 0 || dsDonThuc == null) return;

            string ketQua = "";
            for (int i = n; i >= 0; i--)
            {
                if (dsDonThuc[i].a == 0 && n != 0) continue;

                string dau = (dsDonThuc[i].a > 0 && i != n) ? " + " : (dsDonThuc[i].a < 0 ? " - " : "");
                double heSoIn = Math.Abs(dsDonThuc[i].a);

                if (i == n && dsDonThuc[i].a < 0) dau = "-";

                string donThucStr;
                if (i == 0) donThucStr = $"{heSoIn}";
                else if (i == 1) donThucStr = $"{heSoIn}x";
                else donThucStr = $"{heSoIn}x^{i}";

                ketQua += dau + donThucStr;
            }

            if (string.IsNullOrEmpty(ketQua)) ketQua = "0";
            Console.WriteLine(ketQua);
        }

        public double TinhGiaTri(double x)
        {
            double tong = 0;
            for (int i = 0; i <= n; i++)
            {
                tong += dsDonThuc[i].TinhGiaTri(x);
            }
            return tong;
        }
    }

    public class Bai2_5
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.5: LOP DA THUC ---");
            DaThuc dt = new DaThuc();

            Console.WriteLine("[1] Nhap da thuc:");
            dt.Nhap();

            Console.Write("\n[2] Da thuc vua nhap: P(x) = ");
            dt.Xuat();

            Console.Write("\n[3] Nhap gia tri x de tinh P(x): ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine($"=> Gia tri P({x}) = {dt.TinhGiaTri(x)}");
            }
        }
    }
}