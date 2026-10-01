namespace BaiThucHanhLINQ;

public class Bai6_1
{
    public static void Run()
    {

        var dsHe = DuLieu.DS_He();

        Console.WriteLine("\nDanh sach he:");
        Console.WriteLine("--------------------------------");

        foreach (var he in dsHe)
        {
            Console.WriteLine(
                $"   {he.MaHe,-5} | {he.TenHe}"
            );
        }
    }
}