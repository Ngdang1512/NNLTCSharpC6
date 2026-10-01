namespace BaiThucHanhLINQ;

public class Bai4_1
{
    public static void Run()
    {

        var dsMon = DuLieu.DS_Mon();

        Console.WriteLine("\nDanh sach mon hoc:");
        Console.WriteLine("--------------------------------------------------");

        foreach (var mon in dsMon)
        {
            Console.WriteLine(
                $"{mon.MaMon,-8} | {mon.TenMon,-45} | {mon.He,-3} | {mon.SoTiet,3} tiet"
            );
        }
    }
}