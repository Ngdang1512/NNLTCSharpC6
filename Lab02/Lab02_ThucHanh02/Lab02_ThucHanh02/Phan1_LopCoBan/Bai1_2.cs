using System;

namespace Lab02_ThucHanh02.Phan1_LopCoBan
{
    public class Point
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Input()
        {
            Console.Write("  Nhap x: ");
            x = double.Parse(Console.ReadLine());

            Console.Write("  Nhap y: ");
            y = double.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point operator -(Point a)
        {
            return new Point(-a.X, -a.Y);
        }

        public double KhoangCach(Point b)
        {
            return Math.Sqrt(Math.Pow(this.X - b.X, 2) + Math.Pow(this.Y - b.Y, 2));
        }

        public static double KhoangCach(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public Point TrungDiem(Point b)
        {
            return new Point((this.X + b.X) / 2, (this.Y + b.Y) / 2);
        }

        public static Point TrungDiem(Point a, Point b)
        {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }
    }

    public class Bai1_2
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 1.2: LOP POINT TRONG MAT PHANG ---");

            Point A = new Point();
            Console.WriteLine("Nhap toa do diem A:");
            A.Input();

            Point B = new Point();
            Console.WriteLine("Nhap toa do diem B:");
            B.Input();

            Console.WriteLine("\n--- Kiem tra ket qua ---");
            Console.Write("- Diem A: "); A.Output();
            Console.Write("- Diem B: "); B.Output();

            Point C = A + B;
            Console.WriteLine($"- A + B = {C}");
            Console.WriteLine($"- Diem doi xung cua A (lay am) = {-A}");

            Console.WriteLine($"- Khoang cach A den B (Member Method): {A.KhoangCach(B):F2}");
            Console.WriteLine($"- Khoang cach A den B (Static Method): {Point.KhoangCach(A, B):F2}");

            Point I1 = A.TrungDiem(B);
            Point I2 = Point.TrungDiem(A, B);
            Console.WriteLine($"- Trung diem cua AB (Member Method): {I1}");
            Console.WriteLine($"- Trung diem cua AB (Static Method): {I2}");
        }
    }
}