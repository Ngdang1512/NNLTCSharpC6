using System;

namespace Lab02_ThucHanh01
{
    public class Bai7
    {
        public static bool KiemTraNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 7: KIEM TRA SO NGUYEN TO ---");

            Console.Write("Nhap so nguyen n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                bool laNguyenTo = KiemTraNguyenTo(n);

                if (laNguyenTo)
                {
                    Console.WriteLine($"{n} la so nguyen to.");
                }
                else
                {
                    Console.WriteLine($"{n} khong phai la so nguyen to.");
                }
            }
            else
            {
                Console.WriteLine("Loi: Vui long nhap mot so nguyen hop le!");
            }
        }
    }
}