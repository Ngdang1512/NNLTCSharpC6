using System.Text;

namespace BaiThucHanhLINQ;

public class Bai2_2
{
    public static void Run()
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string[] mangChuoi =
        {
            "đầu", "lòng", "hai", "ả", "tố", "nga",
            "Thúy", "Kiều", "là", "chị", "em",
            "là", "Thúy", "Vân"
        };

        var cauA = mangChuoi
            .Where(x => x.Length == 4)
            .OrderBy(x => x[0]);

        Console.WriteLine("\na. Cac phan tu co 4 ky tu:");

        foreach (var x in cauA)
        {
            Console.WriteLine("   " + x);
        }

        var cauB = mangChuoi
            .Select(x => $"{x.ToLower()} - {x.ToUpper()}");

        Console.WriteLine("\nb. Chu thuong - CHU HOA:");

        foreach (var x in cauB)
        {
            Console.WriteLine("   " + x);
        }

        var cauC = mangChuoi
            .Where(x => x.ToLower().Contains("u"));

        Console.WriteLine("\nc. Cac phan tu co chua ky tu 'u':");

        foreach (var x in cauC)
        {
            Console.WriteLine("   " + x);
        }

        var cauD = mangChuoi
            .Where(x => char.IsUpper(x[0]));

        Console.WriteLine("\nd. Cac tu bat dau bang chu in hoa:");
        Console.Write("   ");

        foreach (var x in cauD)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }
}