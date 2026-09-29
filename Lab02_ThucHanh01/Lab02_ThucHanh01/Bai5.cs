using System;

namespace Lab02_ThucHanh01
{
    public class Bai5
    {
        public static void Run()
        {
            double x = 0, y = 0;
            int chon = 0;

            do
            {
                Console.WriteLine("--- MENU ---");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                if (int.TryParse(Console.ReadLine(), out chon))
                {
                    switch (chon)
                    {
                        case 1:
                            Console.Write("Nhap x: ");
                            x = double.Parse(Console.ReadLine());
                            Console.Write("Nhap y: ");
                            y = double.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine($"Ket qua {x}^{y} la: {Math.Pow(x, y)}");
                            break;
                        case 3:
                            Console.WriteLine($"Can bac 2 cua {x} la: {Math.Sqrt(x)}");
                            Console.WriteLine($"Can bac 2 cua {y} la: {Math.Sqrt(y)}");
                            break;
                        case 4:
                            Console.WriteLine("Thoat chuong trinh.");
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
            } while (chon != 4);
        }
    }
}