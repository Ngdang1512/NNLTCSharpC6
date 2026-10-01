namespace BaiThucHanhLINQ;

public class Bai3_1
{
    public static void Run()
    {

        int[] mangSo =
        {
            50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85
        };

        Console.WriteLine("\nMang ban dau:");
        Console.Write("   ");

        foreach (var x in mangSo)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();

        int tongPhanTu = mangSo.Count();
        int soChan = mangSo.Count(x => x % 2 == 0);
        int soLe = mangSo.Count(x => x % 2 != 0);

        Console.WriteLine("\na. Thong ke so phan tu:");
        Console.WriteLine($"   Tong so phan tu: {tongPhanTu}");
        Console.WriteLine($"   So phan tu chan: {soChan}");
        Console.WriteLine($"   So phan tu le: {soLe}");

        int tongGiaTri = mangSo.Sum();
        int lonNhat = mangSo.Max();
        int nhoNhat = mangSo.Min();

        Console.WriteLine("\nb. Thong ke gia tri:");
        Console.WriteLine($"   Tong cac gia tri: {tongGiaTri}");
        Console.WriteLine($"   Gia tri lon nhat: {lonNhat}");
        Console.WriteLine($"   Gia tri nho nhat: {nhoNhat}");

        int soGiaTriKhacNhau = mangSo.Distinct().Count();

        Console.WriteLine("\nc. So gia tri khac nhau:");
        Console.WriteLine($"   {soGiaTriKhacNhau}");

        var cauD = mangSo.GroupBy(x => x % 5);

        Console.WriteLine("\nd. Phan nhom theo so du khi chia cho 5:");

        foreach (var nhom in cauD)
        {
            Console.Write($"   Dư {nhom.Key}: ");

            foreach (var x in nhom)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }
    }
}