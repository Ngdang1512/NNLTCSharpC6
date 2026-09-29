using System;

namespace Lab02_ThucHanh01
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamThu { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();

            Console.Write("Sinh vien nam thu may: ");
            if (!int.TryParse(Console.ReadLine(), out int nam))
            {
                nam = 1;
            }
            NamThu = nam;
        }

        public void Xuat()
        {
            Console.WriteLine($"- Ma SV: {MaSV} | Ho ten: {HoTen} | Dia chi: {DiaChi} | Sinh vien nam thu: {NamThu}");
        }
    }

    public class Bai13
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 13: NHAP XUAT THONG TIN SINH VIEN ---");

            SinhVien sv = new SinhVien();

            Console.WriteLine("Moi nhap thong tin:");
            sv.Nhap();

            Console.WriteLine("\nThong tin sinh vien vua nhap la:");
            sv.Xuat();
        }
    }
}