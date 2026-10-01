using System;

namespace Lab02_ThucHanh01
{
    public class Bai8
    {
        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 8: HOAN VI HAI SO THUC ---");

            Console.Write("Nhap so thuc thu nhat (x): ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc thu hai (y): ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nTruoc khi hoan vi: x = {x}, y = {y}");

            HoanVi(ref x, ref y);

            Console.WriteLine($"Sau khi hoan vi: x = {x}, y = {y}");
        }
    }
}