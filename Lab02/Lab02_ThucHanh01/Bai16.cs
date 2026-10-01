using System;

namespace Lab02_ThucHanh01
{
    public class Bai16
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 16: SAP XEP MANG HO TEN ---");

            Console.Write("Nhap so luong nguoi (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("So luong khong hop le!");
                return;
            }

            string[] danhSachHoTen = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap ho ten nguoi thu {i + 1}: ");
                danhSachHoTen[i] = Console.ReadLine();
            }

            Array.Sort(danhSachHoTen);

            Console.WriteLine("\n--- Danh sach ho ten sau khi sap xep ---");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}. {danhSachHoTen[i]}");
            }
        }
    }
}