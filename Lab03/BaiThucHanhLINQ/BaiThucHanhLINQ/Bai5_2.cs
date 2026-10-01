namespace BaiThucHanhLINQ;

public class Bai5_2
{
    public static void Run()
    {

        var dsMon = DuLieu.DS_Mon();

        int cauA = dsMon.Count();

        Console.WriteLine("\na. Tong so mon hien co:");
        Console.WriteLine($"   {cauA} mon");

        int cauB = dsMon
            .Count(x => x.TenMon.StartsWith("Lap trinh"));

        Console.WriteLine("\nb. So mon co ten bat dau bang 'Lap trinh':");
        Console.WriteLine($"   {cauB} mon");

        int cauC = dsMon
            .Where(x => x.He == "KTV")
            .Sum(x => x.SoTiet);

        Console.WriteLine("\nc. Tong so tiet cua he KTV:");
        Console.WriteLine($"   {cauC} tiet");

        var cauD = dsMon
            .GroupBy(x => x.He)
            .Select(g => new
            {
                He = g.Key,
                TongSoMon = g.Count()
            });

        Console.WriteLine("\nd. Tong so mon cua moi he:");

        foreach (var x in cauD)
        {
            string he = string.IsNullOrEmpty(x.He)
                ? "Chua khai bao"
                : x.He;

            Console.WriteLine(
                $"   He: {he,-15} | Tong so mon: {x.TongSoMon}"
            );
        }

        var cauE = dsMon
            .GroupBy(x => x.SoTiet)
            .Select(g => new
            {
                SoTiet = g.Key,
                TongSoMon = g.Count()
            })
            .OrderByDescending(x => x.SoTiet);

        Console.WriteLine("\ne. Phan nhom theo SoTiet:");

        foreach (var x in cauE)
        {
            Console.WriteLine(
                $"   {x.SoTiet,3} tiet | {x.TongSoMon} mon"
            );
        }

        int soTietCaoNhat = dsMon.Max(x => x.SoTiet);

        var cauF = dsMon
            .Where(x => x.SoTiet == soTietCaoNhat);

        Console.WriteLine("\nf. Mon hoc co so tiet cao nhat:");

        foreach (var mon in cauF)
        {
            Console.WriteLine(
                $"   {mon.MaMon,-8} | {mon.TenMon,-40} | {mon.SoTiet} tiet"
            );
        }

        var cauG = dsMon
            .GroupBy(x => x.He)
            .Select(g => new
            {
                He = g.Key,
                TongSoMon = g.Count(),
                TongSoTiet = g.Sum(x => x.SoTiet),
                SoTietCaoNhat = g.Max(x => x.SoTiet),
                SoTietThapNhat = g.Min(x => x.SoTiet)
            });

        Console.WriteLine("\ng. Thong ke theo He:");

        foreach (var x in cauG)
        {
            string he = string.IsNullOrEmpty(x.He)
                ? "Chua khai bao"
                : x.He;

            Console.WriteLine($"   He: {he}");
            Console.WriteLine($"      Tong so mon      : {x.TongSoMon}");
            Console.WriteLine($"      Tong so tiet     : {x.TongSoTiet}");
            Console.WriteLine($"      So tiet cao nhat : {x.SoTietCaoNhat}");
            Console.WriteLine($"      So tiet thap nhat: {x.SoTietThapNhat}");
        }

        var cauH = dsMon
            .GroupBy(x => x.He);

        Console.WriteLine("\nh. Cac mon hoc duoc phan nhom theo He:");

        foreach (var nhom in cauH)
        {
            string he = string.IsNullOrEmpty(nhom.Key)
                ? "Chua khai bao"
                : nhom.Key;

            Console.WriteLine($"   He: {he}");

            foreach (var mon in nhom)
            {
                Console.WriteLine(
                    $"      {mon.MaMon,-8} | {mon.TenMon}"
                );
            }
        }

        var cauI = dsMon
            .GroupBy(x => x.SoTiet)
            .OrderBy(x => x.Key);

        Console.WriteLine("\ni. Cac mon hoc phan nhom theo SoTiet tang dan:");

        foreach (var nhom in cauI)
        {
            Console.WriteLine($"   So tiet: {nhom.Key}");

            foreach (var mon in nhom)
            {
                Console.WriteLine(
                    $"      {mon.MaMon,-8} | {mon.TenMon}"
                );
            }
        }

        var cauJ = dsMon
            .Where(x => x.He == "KTV")
            .Where(x =>
                x.MaMon.StartsWith("HP2") ||
                x.MaMon.StartsWith("HP3") ||
                x.MaMon.StartsWith("HP4") ||
                x.MaMon.StartsWith("HP5"))
            .OrderBy(x => x.MaMon)
            .GroupBy(x => x.MaMon.Substring(0, 3));

        Console.WriteLine("\nj. He KTV phan nhom theo HP2, HP3, HP4, HP5:");

        foreach (var nhom in cauJ)
        {
            Console.WriteLine($"   Nhom {nhom.Key}:");

            foreach (var mon in nhom)
            {
                Console.WriteLine(
                    $"      {mon.MaMon,-8} | {mon.TenMon}"
                );
            }
        }

        var cauK = dsMon
            .Where(x => x.SoTiet > 40)
            .GroupBy(x => x.He);

        Console.WriteLine("\nk. Phan nhom theo He, chi lay mon co SoTiet > 40:");

        foreach (var nhom in cauK)
        {
            string he = string.IsNullOrEmpty(nhom.Key)
                ? "Chua khai bao"
                : nhom.Key;

            Console.WriteLine($"   He: {he}");

            foreach (var mon in nhom.OrderBy(x => x.MaMon))
            {
                Console.WriteLine(
                    $"      {mon.MaMon,-8} | {mon.SoTiet,3} tiet | {mon.TenMon}"
                );
            }
        }
    }
}