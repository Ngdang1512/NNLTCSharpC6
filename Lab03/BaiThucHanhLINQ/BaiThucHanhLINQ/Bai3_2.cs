namespace BaiThucHanhLINQ;

public class Bai3_2
{
    public static void Run()
    {

        string[] monAn =
        {
            "Bun bo Hue",
            "Hu tieu heo",
            "Banh canh",
            "Banh mi",
            "Nuoc Ca phe",
            "Mi quang",
            "Com tam",
            "Nuoc Chanh day",
            "Mi xao",
            "Bun rieu",
            "Banh cuon",
            "Mi goi",
            "Bun cha",
            "Hu tieu Nam vang"
        };

        Console.WriteLine("\nMang ban dau:");

        foreach (var x in monAn)
        {
            Console.WriteLine("   " + x);
        }

        int doDaiNganNhat = monAn.Min(x => x.Length);
        int doDaiDaiNhat = monAn.Max(x => x.Length);

        var nganNhat = monAn
            .Where(x => x.Length == doDaiNganNhat);

        var daiNhat = monAn
            .Where(x => x.Length == doDaiDaiNhat);

        Console.WriteLine("\na. Phan tu co chieu dai ngan nhat:");

        foreach (var x in nganNhat)
        {
            Console.WriteLine($"   {x} ({x.Length} ky tu)");
        }

        Console.WriteLine("\n   Phan tu co chieu dai dai nhat:");

        foreach (var x in daiNhat)
        {
            Console.WriteLine($"   {x} ({x.Length} ky tu)");
        }

        var cauB = monAn
            .GroupBy(x => x.Split(' ')[0])
            .OrderBy(x => x.Key);

        Console.WriteLine("\nb. Phan nhom theo tu dau tien:");

        foreach (var nhom in cauB)
        {
            Console.WriteLine($"   Nhom {nhom.Key}:");

            foreach (var x in nhom)
            {
                Console.WriteLine("      - " + x);
            }
        }

        int cauC = monAn
            .Count(x => x.Split(' ')[0] == "Banh");

        Console.WriteLine("\nc. So phan tu co tu dau tien la 'Banh':");
        Console.WriteLine($"   {cauC}");
    }
}