using System;
using System.Collections.Generic;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public abstract class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public double Bai1 { get; set; }
        public double Bai2 { get; set; }
        public double Bai3 { get; set; }
        public double TongDiem { get; protected set; }
        public virtual void Nhap()
        {
            Console.Write("Nhap SBD: ");
            SBD = Console.ReadLine();
            Console.Write("Nhap Ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Diem Bai 1: ");
            if (!double.TryParse(Console.ReadLine(), out double b1)) b1 = 0;
            Bai1 = b1;

            Console.Write("Diem Bai 2: ");
            if (!double.TryParse(Console.ReadLine(), out double b2)) b2 = 0;
            Bai2 = b2;

            Console.Write("Diem Bai 3: ");
            if (!double.TryParse(Console.ReadLine(), out double b3)) b3 = 0;
            Bai3 = b3;
        }

        public abstract void TinhTongDiem();

        public virtual void Xuat()
        {
            Console.Write($"- SBD: {SBD,-5} | Ho ten: {HoTen,-15} | Tong diem: {TongDiem,5:F1}");
        }
    }

    public class ThiSinhChuyen : ThiSinh
    {
        public double TiengAnh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Diem Tieng Anh: ");
            if (!double.TryParse(Console.ReadLine(), out double ta)) ta = 0;
            TiengAnh = ta;
        }

        public override void TinhTongDiem()
        {
            double diemThuong = 0;
            if (TiengAnh >= 7 && TiengAnh <= 8) diemThuong = 1;
            else if (TiengAnh >= 9 && TiengAnh <= 10) diemThuong = 2;

            TongDiem = Bai1 + Bai2 + Bai3 + diemThuong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine(" (Doi tuong: Chuyen)");
        }
    }

    public class ThiSinhSieuCup : ThiSinh
    {
        public double CSDL { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Diem CSDL: ");
            if (!double.TryParse(Console.ReadLine(), out double csdl)) csdl = 0;
            CSDL = csdl;
        }

        public override void TinhTongDiem()
        {
            TongDiem = Bai1 + Bai2 + Bai3 + CSDL;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine(" (Doi tuong: Sieu cup)");
        }
    }

    public class Bai3_6
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.6: TINH DIEM THI SINH ---");
            List<ThiSinh> danhSach = new List<ThiSinh>();

            Console.Write("Nhap so luong thi sinh: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) n = 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Thi sinh thu {i + 1} ---");
                Console.Write("Chon doi tuong (1: Chuyen, 2: Sieu cup): ");
                string loai = Console.ReadLine();

                ThiSinh ts;
                if (loai == "1") ts = new ThiSinhChuyen();
                else ts = new ThiSinhSieuCup();

                ts.Nhap();
                ts.TinhTongDiem();
                danhSach.Add(ts);
            }

            Console.WriteLine("\n=== KET QUA CUOC THI ===");
            foreach (ThiSinh ts in danhSach)
            {
                ts.Xuat();
            }
        }
    }
}