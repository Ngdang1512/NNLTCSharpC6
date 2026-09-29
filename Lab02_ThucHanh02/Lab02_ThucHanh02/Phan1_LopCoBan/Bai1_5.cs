using System;

namespace Lab02_ThucHanh02.Phan1_LopCoBan
{
    public class DonThuc
    {
        public double a { get; set; }
        public int n { get; set; }

        public DonThuc()
        {
            a = 0;
            n = 0;
        }

        public DonThuc(double heSo, int bac)
        {
            a = heSo;
            n = bac < 0 ? 0 : bac;
        }

        public void Nhap()
        {
            Console.Write("Nhap he so a (so thuc): ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Nhap bac n (so nguyen khong am): ");
            n = int.Parse(Console.ReadLine());
            if (n < 0) n = 0;
        }

        public void Xuat()
        {
            Console.WriteLine($"{a}x^{n}");
        }

        public double TinhGiaTri(double x)
        {
            return a * Math.Pow(x, n);
        }

        public DonThuc DaoHam()
        {
            if (n == 0) return new DonThuc(0, 0);

            return new DonThuc(a * n, n - 1);
        }
    }

    public class Bai1_5
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 1.5: LOP DON THUC ---");

            DonThuc p = new DonThuc();
            p.Nhap();

            Console.Write("=> Don thuc P(x) vua nhap la: ");
            p.Xuat();

            Console.Write("\nNhap gia tri x de tinh P(x): ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"=> Gia tri cua P({x}) = {p.TinhGiaTri(x)}");

            DonThuc q = p.DaoHam();
            Console.Write("\n=> Dao ham cua don thuc la Q(x) = ");
            q.Xuat();
        }
    }
}