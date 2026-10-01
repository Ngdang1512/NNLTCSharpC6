using System;

namespace Lab02_ThucHanh01
{
    public class Bai9
    {
        public static void TimMaxMin(double a, double b, double c, out double max, out double min)
        {
            max = a;
            min = a;

            if (b > max) max = b;
            if (c > max) max = c;

            if (b < min) min = b;
            if (c < min) min = c;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 9: TIM MAX VA MIN CUA 3 SO THUC ---");

            Console.Write("Nhap so thuc thu nhat (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc thu hai (b): ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc thu ba (c): ");
            double c = double.Parse(Console.ReadLine());

            double giaTriMax, giaTriMin;

            TimMaxMin(a, b, c, out giaTriMax, out giaTriMin);

            Console.WriteLine($"\nKet qua:");
            Console.WriteLine($"- Gia tri lon nhat la: {giaTriMax}");
            Console.WriteLine($"- Gia tri nho nhat la: {giaTriMin}");
        }
    }
}