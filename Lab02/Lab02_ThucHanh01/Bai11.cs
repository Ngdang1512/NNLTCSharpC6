using System;

namespace Lab02_ThucHanh01
{
    public class Bai11
    {
        public static string DaoChuoi(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            char[] charArray = s.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 11: DAO NGUOC CHUOI ---");

            Console.Write("Nhap chuoi can dao nguoc: ");
            string chuoi = Console.ReadLine();

            string chuoiDao = DaoChuoi(chuoi);

            Console.WriteLine($"Chuoi sau khi dao nguoc la: {chuoiDao}");
        }
    }
}