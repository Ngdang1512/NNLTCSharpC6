using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap muc luong co ban (VND): ");
            if (!double.TryParse(Console.ReadLine(), out double luong)) luong = 0;
            MucLuong = luong;

            Console.Write("Nhap so ngay vang: ");
            if (!int.TryParse(Console.ReadLine(), out int ngay)) ngay = 0;
            SoNgayVang = ngay;
        }

        public double TinhLuongThucLanh()
        {
            double thucLanh = MucLuong - (SoNgayVang * 100000);

            return thucLanh < 0 ? 0 : thucLanh;
        }

        public void Xuat()
        {
            Console.WriteLine($"- Ho ten: {HoTen,-15} | Luong CB: {MucLuong,10:N0} | Vang: {SoNgayVang,2} ngay | Thuc lanh: {TinhLuongThucLanh(),10:N0} VND");
        }
    }

    public class PhongBan
    {
        private List<NhanVien> danhSachNV;

        public PhongBan()
        {
            danhSachNV = new List<NhanVien>();
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong nhan vien trong phong ban (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) n = 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhap thong tin nhan vien thu {i + 1} ---");
                NhanVien nv = new NhanVien();
                nv.Nhap();
                danhSachNV.Add(nv);
            }
        }

        public void Xuat()
        {
            if (danhSachNV.Count == 0)
            {
                Console.WriteLine("Phong ban hien chua co nhan vien.");
                return;
            }

            Console.WriteLine("\n--- DANH SACH NHAN VIEN ---");
            foreach (NhanVien nv in danhSachNV)
            {
                nv.Xuat();
            }
        }

        public double TinhTongLuong()
        {
            double tong = 0;
            foreach (NhanVien nv in danhSachNV)
            {
                tong += nv.TinhLuongThucLanh();
            }
            return tong;
        }
    }

    public class Bai2_7
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.5: TINH LUONG NHAN VIEN PHONG BAN ---");
            PhongBan pb = new PhongBan();

            Console.WriteLine("[1] Nhap thong tin phong ban:");
            pb.Nhap();

            Console.WriteLine("\n[2] Xuat thong tin phong ban:");
            pb.Xuat();

            Console.WriteLine("\n[3] Tinh tong luong:");
            double tongLuong = pb.TinhTongLuong();
            Console.WriteLine($"=> Tong luong phai tra cho phong ban la: {tongLuong:N0} VND");
        }
    }
}