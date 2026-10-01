using System;

namespace Lab02_ThucHanh01
{
    internal class Bai3
    {
        public static void Run()
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            // Tinh luy thua
            double ketQua = Math.Pow(x, y);

            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }
    }
}
