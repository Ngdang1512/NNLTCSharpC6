namespace BaiThucHanhLINQ;

public class Bai2_1
{
    public static void Run()
    {
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

        var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);

        Console.WriteLine("\na. Cac so chia het cho 4 va 3: ");
        foreach (var x in cauA)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();

        var cauB = mangSo.Where(x => x <= 3);

        Console.WriteLine("\nb. Cac so <= 3: ");
        foreach (var x in cauB)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();

        var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);

        Console.WriteLine("\nc. Day moi:");
        foreach (var x in cauC)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }
}