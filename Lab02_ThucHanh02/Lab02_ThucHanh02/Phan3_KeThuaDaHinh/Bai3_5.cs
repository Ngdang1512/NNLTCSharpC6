using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhap ma nhan vien: ");
            MaNV = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap luong co ban (VND): ");
            if (!double.TryParse(Console.ReadLine(), out double lcb)) lcb = 0;
            LuongCoBan = lcb;
        }

        public virtual void Xuat()
        {
            Console.Write($"- Ma NV: {MaNV,-5} | Ho ten: {HoTen,-15} | LCB: {LuongCoBan,10:N0}");
        }

        public abstract double TinhLuong();
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public int SoHopDong { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so hop dong da ky: ");
            if (!int.TryParse(Console.ReadLine(), out int shd)) shd = 0;
            SoHopDong = shd;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoHopDong * 500000);
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($" | Loai: Kinh Doanh | Thuc lanh: {TinhLuong(),10:N0} VND");
        }
    }

    public class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so luong san pham: ");
            if (!int.TryParse(Console.ReadLine(), out int ssp)) ssp = 0;
            SoSanPham = ssp;
        }

        public override double TinhLuong()
        {
            double luong = LuongCoBan + (SoSanPham * 1000);

            if (SoSanPham > 3000)
            {
                luong += luong * 0.05;
            }
            return luong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($" | Loai: San Xuat   | Thuc lanh: {TinhLuong(),10:N0} VND");
        }
    }

    public class Bai3_5
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.5: TINH LUONG NHAN VIEN (DA HINH - CAP NHAT) ---");

            List<NhanVien> danhSach = new List<NhanVien>();

            Console.Write("Nhap so luong nhan vien can them: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) n = 2;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhan vien thu {i + 1} ---");
                Console.Write("Chon loai (1: Kinh doanh, 2: San xuat): ");
                string loai = Console.ReadLine();

                NhanVien nv;
                if (loai == "1") nv = new NhanVienKinhDoanh();
                else nv = new NhanVienSanXuat();

                nv.Nhap();
                danhSach.Add(nv);
            }

            Console.WriteLine("\n=== DANH SACH LUONG NHAN VIEN ===");
            double tongLuongCongTy = 0;
            foreach (NhanVien nv in danhSach)
            {
                nv.Xuat();
                tongLuongCongTy += nv.TinhLuong();
            }

            Console.WriteLine($"\n=> Tong quy luong phai tra: {tongLuongCongTy:N0} VND");
        }
    }
}