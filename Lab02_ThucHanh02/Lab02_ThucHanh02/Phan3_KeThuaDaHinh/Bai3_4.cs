using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public class ConsoleMenu
    {
        public delegate void MenuAction(int chucNang);
        public event MenuAction Choose;

        private List<string> danhSachChucNang;

        public ConsoleMenu()
        {
            danhSachChucNang = new List<string>();
        }

        public void ThemChucNang(string tenChucNang)
        {
            danhSachChucNang.Add(tenChucNang);
        }

        public void RunMenu()
        {
            int chon;
            do
            {
                Console.WriteLine("\n=== MENU ===");
                for (int i = 0; i < danhSachChucNang.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {danhSachChucNang[i]}");
                }
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("Thuc hien: ");

                if (int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine($"=> Ban thuc hien chuc nang {chon}");

                    if (chon != 0)
                    {
                        Choose?.Invoke(chon);
                    }
                }
                else
                {
                    chon = -1;
                    Console.WriteLine("Vui long nhap so hop le!");
                }
            } while (chon != 0);
        }
    }

    public class PTBac2Console : ConsoleMenu
    {
        public PTBac2Console()
        {
            ThemChucNang("Giai phuong trinh bac 2");

            this.Choose += XuLyMenu;
        }

        private void XuLyMenu(int chucNang)
        {
            if (chucNang == 1)
            {
                GiaiPTBac2();
            }
            else
            {
                Console.WriteLine("Chuc nang nay chua duoc cai dat.");
            }
        }

        private void GiaiPTBac2()
        {
            Console.WriteLine("\n--- GIAI PHUONG TRINH BAC 2: ax^2 + bx + c = 0 ---");
            Console.Write("Nhap he so a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhap he so b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Nhap he so c: ");
            double c = double.Parse(Console.ReadLine());

            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine(c == 0 ? "Phuong trinh vo so nghiem." : "Phuong trinh vo nghiem.");
                else
                    Console.WriteLine($"Phuong trinh co nghiem duy nhat: x = {-c / b}");
            }
            else
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;
                if (delta < 0)
                {
                    Console.WriteLine("Phuong trinh vo nghiem.");
                }
                else if (delta == 0)
                {
                    Console.WriteLine($"Phuong trinh co nghiem kep: x1 = x2 = {-b / (2 * a)}");
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine($"Phuong trinh co 2 nghiem phan biet:\n x1 = {x1}\n x2 = {x2}");
                }
            }
        }
    }

    public class Bai3_4
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.4: MENU TONG QUAT VOI EVENT ---");

            PTBac2Console app = new PTBac2Console();

            app.RunMenu();
        }
    }
}