using System;

namespace Lab02_ThucHanh02.Phan3_KeThuaDaHinh
{
    public class SinhVien : IComparable<SinhVien>
    {
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(string hoTen, double diemTB)
        {
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        public int CompareTo(SinhVien other)
        {
            if (other == null) return 1;

            return this.DiemTB.CompareTo(other.DiemTB);
        }

        public override string ToString()
        {
            return $"Ho ten: {HoTen,-15} | Diem TB: {DiemTB,4:F1}";
        }
    }

    public class Bai3_1
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 3.1: DUNG ARRAY.SORT SAP XEP DOI TUONG ---");

            SinhVien[] danhSachSV = new SinhVien[]
            {
                new SinhVien("Nguyen Van A", 7.5),
                new SinhVien("Tran Thi B", 9.0),
                new SinhVien("Le Van C", 5.5),
                new SinhVien("Pham Thi D", 8.2)
            };

            Console.WriteLine("[1] Danh sach sinh vien ban dau:");
            InDanhSach(danhSachSV);

            Array.Sort(danhSachSV);

            Console.WriteLine("\n[2] Danh sach sinh vien SAU KHI SAP XEP (Theo Diem TB tang dan):");
            InDanhSach(danhSachSV);
        }

        private static void InDanhSach(SinhVien[] ds)
        {
            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.ToString());
            }
        }
    }
}