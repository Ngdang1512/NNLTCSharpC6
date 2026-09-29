using System;

namespace Lab02_ThucHanh01
{
    public class Bai12
    {
        public static int DemSoTu(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            string[] cacTu = s.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return cacTu.Length;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 12: XU LY CHUOI ---");

            Console.Write("Nhap vao mot chuoi gom nhieu tu: ");
            string chuoi = Console.ReadLine();

            string chuoiThuong = chuoi.ToLower();
            Console.WriteLine($"\nChuoi chu thuong: {chuoiThuong}");

            string chuoiHoa = chuoi.ToUpper();
            Console.WriteLine($"Chuoi chu hoa: {chuoiHoa}");

            int soTu = DemSoTu(chuoi);
            Console.WriteLine($"So tu trong chuoi la: {soTu}");
        }
    }
}