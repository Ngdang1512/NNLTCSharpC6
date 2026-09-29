using System;

namespace Lab02_ThucHanh01
{
    public class Bai6
    {
        public static int TimMax(int a, int b, int c)
        {
            int max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            return max;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 6: TIM MAX 3 SO NGUYEN ---");

            Console.Write("Nhap so nguyen thu 1: ");
            int so1 = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen thu 2: ");
            int so2 = int.Parse(Console.ReadLine());

            Console.Write("Nhap so nguyen thu 3: ");
            int so3 = int.Parse(Console.ReadLine());

            int ketQua = TimMax(so1, so2, so3);

            Console.WriteLine($"Gia tri lon nhat trong 3 so {so1}, {so2}, {so3} la: {ketQua}");
        }
    }
}