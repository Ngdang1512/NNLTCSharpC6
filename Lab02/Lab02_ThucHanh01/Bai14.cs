using System;

namespace Lab02_ThucHanh01
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ho ten nhan vien: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap muc luong co ban: ");
            if (!double.TryParse(Console.ReadLine(), out double luong))
            {
                luong = 0;
            }
            MucLuong = luong;

            Console.Write("Nhap so ngay vang: ");
            if (!int.TryParse(Console.ReadLine(), out int ngayVang))
            {
                ngayVang = 0;
            }
            SoNgayVang = ngayVang;
        }

        public double TinhLuong()
        {
            return MucLuong - (SoNgayVang * 100000);
        }

        public void Xuat()
        {
            Console.WriteLine($"- Ho ten: {HoTen}");
            Console.WriteLine($"- Muc luong: {MucLuong:N0} VNĐ");
            Console.WriteLine($"- So ngay vang: {SoNgayVang}");
            Console.WriteLine($"=> Luong thuc lanh: {TinhLuong():N0} VNĐ");
        }
    }

    public class Bai14
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 14: TINH LUONG NHAN VIEN ---");

            NhanVien nv = new NhanVien();

            Console.WriteLine("Moi nhap thong tin nhan vien:");
            nv.Nhap();

            Console.WriteLine("\n--- Ket qua ---");
            nv.Xuat();
        }
    }
}