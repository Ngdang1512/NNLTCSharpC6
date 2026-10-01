using System;

namespace Lab02_ThucHanh01
{
    public class Bai4
    {
        public static void Run()
        {
            int x, y;

            Console.Write("Nhap so nguyen x: ");
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Loi: Gia tri x ban vua nhap khong phai la so nguyen!");
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            if (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Loi: Gia tri y ban vua nhap khong phai la so nguyen!");
                return;
            }

            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }
    }
}