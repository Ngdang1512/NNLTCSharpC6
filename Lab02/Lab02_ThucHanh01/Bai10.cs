using System;

namespace Lab02_ThucHanh01
{
    public class Bai10
    {
        public static bool KiemTraDoiXung(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        public static void Run()
        {
            Console.WriteLine("--- BAI 10: KIEM TRA CHUOI DOI XUNG ---");

            Console.Write("Nhap chuoi can kiem tra: ");
            string chuoi = Console.ReadLine();

            if (KiemTraDoiXung(chuoi))
            {
                Console.WriteLine($"Chuoi \"{chuoi}\" la chuoi doi xung.");
            }
            else
            {
                Console.WriteLine($"Chuoi \"{chuoi}\" KHONG phai la chuoi doi xung.");
            }
        }
    }
}