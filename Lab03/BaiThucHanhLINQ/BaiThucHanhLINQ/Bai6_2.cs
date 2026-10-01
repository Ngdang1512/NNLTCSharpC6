namespace BaiThucHanhLINQ;

public class Bai6_2
{
    public static void Run()
    {

        var dsMon = DuLieu.DS_Mon();
        var dsHe = DuLieu.DS_He();

        var cauA =
            from h in dsHe
            join m in dsMon
            on h.MaHe equals m.He
            select new
            {
                h.TenHe,
                m.MaMon,
                m.TenMon
            };

        Console.WriteLine("\na. Ten he, Ma mon, Ten mon:");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var x in cauA)
        {
            Console.WriteLine(
                $"   {x.TenHe,-20} | {x.MaMon,-8} | {x.TenMon}"
            );
        }


        var cauB =
            from h in dsHe
            join m in dsMon
            on h.MaHe equals m.He
            into nhomMon
            from m in nhomMon.DefaultIfEmpty()
            select new
            {
                h.MaHe,
                h.TenHe,
                MaMon = m != null ? m.MaMon : "Khong co",
                TenMon = m != null ? m.TenMon : "Khong co mon"
            };

        Console.WriteLine("\nb. Liet ke ca nhung he chua co mon hoc:");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var x in cauB)
        {
            Console.WriteLine(
                $"   {x.MaHe,-5} | {x.TenHe,-20} | {x.MaMon,-10} | {x.TenMon}"
            );
        }


        var heVaMon =
            from h in dsHe
            join m in dsMon
            on h.MaHe equals m.He
            into nhomMon
            from m in nhomMon.DefaultIfEmpty()
            select new
            {
                MaHe = h.MaHe,
                TenHe = h.TenHe,
                MaMon = m != null ? m.MaMon : "Khong co",
                TenMon = m != null ? m.TenMon : "Khong co mon"
            };

        var monChuaCoHe =
            from m in dsMon
            where string.IsNullOrEmpty(m.He)
                  || !dsHe.Any(h => h.MaHe == m.He)
            select new
            {
                MaHe = "Khong co",
                TenHe = "Chua khai bao he",
                MaMon = m.MaMon,
                TenMon = m.TenMon
            };

        var cauC = heVaMon.Concat(monChuaCoHe);

        Console.WriteLine("\nc. Liet ke ca he chua co mon va mon chua khai bao he:");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var x in cauC)
        {
            Console.WriteLine(
                $"   {x.MaHe,-10} | {x.TenHe,-20} | {x.MaMon,-10} | {x.TenMon}"
            );
        }


        var heChuaCoMon =
            from h in dsHe
            where !dsMon.Any(m => m.He == h.MaHe)
            select h;

        var monChuaKhaiBaoHe =
            from m in dsMon
            where string.IsNullOrEmpty(m.He)
                  || !dsHe.Any(h => h.MaHe == m.He)
            select m;

        Console.WriteLine("\nd. Chi liet ke he chua co mon va mon chua khai bao he:");

        Console.WriteLine("   He chua co mon:");

        foreach (var h in heChuaCoMon)
        {
            Console.WriteLine(
                $"      {h.MaHe,-5} | {h.TenHe}"
            );
        }

        Console.WriteLine("\n   Mon chua khai bao he:");

        foreach (var m in monChuaKhaiBaoHe)
        {
            Console.WriteLine(
                $"      {m.MaMon,-8} | {m.TenMon}"
            );
        }


        var cauE =
            (from m in dsMon
             join h in dsHe
             on m.He equals h.MaHe
             orderby m.SoTiet descending
             select new
             {
                 h.TenHe,
                 m.MaMon,
                 m.TenMon,
                 m.SoTiet
             })
            .Take(5);

        Console.WriteLine("\ne. 5 mon hoc dau tien co so tiet giam dan:");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var x in cauE)
        {
            Console.WriteLine(
                $"   {x.SoTiet,3} tiet | {x.TenHe,-20} | {x.MaMon,-8} | {x.TenMon}"
            );
        }


        var cauF =
            from h in dsHe
            join m in dsMon
            on h.MaHe equals m.He
            into nhomMon
            select new
            {
                h.MaHe,
                h.TenHe,
                TongSoMon = nhomMon.Count()
            };

        Console.WriteLine("\nf. Tong so mon hoc cua moi he:");
        Console.WriteLine("--------------------------------------------------");

        foreach (var x in cauF)
        {
            Console.WriteLine(
                $"   {x.MaHe,-5} | {x.TenHe,-20} | {x.TongSoMon} mon"
            );
        }


        int cauG = dsMon
            .Select(x => x.SoTiet)
            .Distinct()
            .Count();

        Console.WriteLine("\ng. So loai SoTiet khac nhau:");
        Console.WriteLine($"   {cauG} loai");


        var cauH = dsMon
            .FirstOrDefault(x =>
                x.TenMon.StartsWith("Lap trinh"));

        Console.WriteLine("\nh. Mon hoc dau tien co ten bat dau bang 'Lap trinh':");

        if (cauH != null)
        {
            Console.WriteLine(
                $"   {cauH.MaMon,-8} | {cauH.TenMon,-40} | {cauH.SoTiet} tiet"
            );
        }
        else
        {
            Console.WriteLine("   Khong tim thay mon hoc.");
        }


        var cauI = dsHe
            .GroupJoin(
                dsMon,
                h => h.MaHe,
                m => m.He,
                (h, ds) => new
                {
                    He = h,
                    DanhSachMon = ds
                }
            );

        Console.WriteLine("\ni. Liet ke cac mon theo tung he, co danh so thu tu:");

        foreach (var nhom in cauI)
        {
            Console.WriteLine(
                $"   He {nhom.He.MaHe} - {nhom.He.TenHe}:"
            );

            int stt = 1;

            foreach (var mon in nhom.DanhSachMon)
            {
                Console.WriteLine(
                    $"      {stt}. {mon.MaMon,-8} | {mon.TenMon}"
                );

                stt++;
            }

            if (!nhom.DanhSachMon.Any())
            {
                Console.WriteLine("      Khong co mon hoc.");
            }
        }
    }
}