namespace BaiThucHanhLINQ;

public class Bai5_1
{
    public static void Run()
    {

        var dsMon = DuLieu.DS_Mon();

        Console.WriteLine("\nDanh sach mon hoc ban dau:");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var mon in dsMon)
        {
            Console.WriteLine(
                $"{mon.MaMon,-8} | {mon.TenMon,-45} | {mon.He,-3} | {mon.SoTiet,3} tiet"
            );
        }

        var cauA = dsMon
            .Where(x => x.TenMon.StartsWith("Lap trinh"));

        Console.WriteLine("\na. Cac mon hoc co ten bat dau bang 'Lap trinh':");

        foreach (var mon in cauA)
        {
            Console.WriteLine(
                $"   {mon.MaMon,-8} | {mon.TenMon}"
            );
        }

        var cauB = dsMon
            .Where(x => x.He == "CD")
            .OrderByDescending(x => x.SoTiet)
            .ThenBy(x => x.MaMon);

        Console.WriteLine("\nb. Cac mon thuoc he 'CD', sap xep so tiet giam dan, ma mon tang dan:");

        foreach (var mon in cauB)
        {
            Console.WriteLine(
                $"   {mon.MaMon,-8} | {mon.SoTiet,3} tiet | {mon.TenMon}"
            );
        }

        var cauC = dsMon
            .Where(x => x.TenMon.ToLower().Contains("web"))
            .Select(x => new
            {
                x.TenMon,
                x.He
            });

        Console.WriteLine("\nc. Cac mon co ten chua tu 'web':");

        foreach (var mon in cauC)
        {
            Console.WriteLine(
                $"   {mon.TenMon,-45} | He: {mon.He}"
            );
        }

        var cauD = dsMon
            .Where(x => x.He == "KTV")
            .OrderBy(x => x.MaMon);

        Console.WriteLine("\nd. Cac mon thuoc he 'KTV', sap xep tang dan theo MaMon:");

        foreach (var mon in cauD)
        {
            Console.WriteLine(
                $"   {mon.MaMon,-8} | {mon.TenMon}"
            );
        }
    }
}