using System;

namespace Lab02_ThucHanh02.Phan1_LopCoBan
{
    public class SinhVien
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ho ten sinh vien: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap nam sinh: ");
            if (!int.TryParse(Console.ReadLine(), out int nam))
            {
                nam = 2005;
            }
            NamSinh = nam;
        }

        public int TinhTuoi()
        {
            int namHienTai = DateTime.Now.Year;
            return namHienTai - NamSinh;
        }

        public void Xuat()
        {
            Console.WriteLine($"- Ho ten: {HoTen}");
            Console.WriteLine($"- Nam sinh: {NamSinh}");
            Console.WriteLine($"=> Tuoi hien tai: {TinhTuoi()}");
        }
    }

    public class Bai1_1
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 1.1: TINH TUOI SINH VIEN ---");

            SinhVien sv = new SinhVien();

            sv.Nhap();

            Console.WriteLine("\n--- Ket qua ---");
            sv.Xuat();
        }
    }
}