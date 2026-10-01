namespace BaiThucHanhLINQ;

public class DuLieu
{
    public static List<MonHoc> DS_Mon()
    {
        return new List<MonHoc>
        {
            new MonHoc
            {
                MaMon = "HP2_1",
                TenMon = "Nen tang C#",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP2_2",
                TenMon = "Cong nghe ADO.NET",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP3_1",
                TenMon = "Lap trinh Windows Forms",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP3_2",
                TenMon = "Xay dung ung dung Windows Forms",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP4_1",
                TenMon = "Lap trinh Web voi HTML, CSS va JavaScript",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP4_2",
                TenMon = "Xay dung ung dung Web voi ASP.NET",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP5_1",
                TenMon = "Lap trinh CSDL SQL Server can ban",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "HP5_2",
                TenMon = "Lap trinh CSDL SQL Server nang cao",
                He = "KTV",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "JLCB",
                TenMon = "Joomla co ban",
                He = "CD",
                SoTiet = 72
            },

            new MonHoc
            {
                MaMon = "LINQ",
                TenMon = "Language-Integrated Query",
                He = "CD",
                SoTiet = 64
            },

            new MonHoc
            {
                MaMon = "DAWEB",
                TenMon = "Do an thuc te Web voi ASP.NET",
                He = "CD",
                SoTiet = 40
            },

            new MonHoc
            {
                MaMon = "DAWIN",
                TenMon = "Do an thuc te Windows Forms",
                He = "CD",
                SoTiet = 40
            },

            new MonHoc
            {
                MaMon = "CC++",
                TenMon = "Lap trinh huong doi tuong voi C/C++",
                He = "CD",
                SoTiet = 128
            },

            new MonHoc
            {
                MaMon = "JQUE",
                TenMon = "JQuery",
                He = "CD",
                SoTiet = 22
            },

            new MonHoc
            {
                MaMon = "XML",
                TenMon = "Cong nghe XML",
                He = "CD",
                SoTiet = 32
            },

            new MonHoc
            {
                MaMon = "CRYS",
                TenMon = "Crystal Report trong Visual Studio",
                He = "CD",
                SoTiet = 32
            },

            new MonHoc
            {
                MaMon = "BWEB",
                TenMon = "HTML, CSS va JavaScript",
                He = "CD",
                SoTiet = 32
            },

            new MonHoc
            {
                MaMon = "XYZ",
                TenMon = "Chua dat ten mon",
                He = "",
                SoTiet = 0
            }
        };
    }

    public static List<He> DS_He()
    {
        return new List<He>
        {
            new He
            {
                MaHe = "KTV",
                TenHe = "Ky thuat vien"
            },

            new He
            {
                MaHe = "CD",
                TenHe = "Chuyen de"
            },

            new He
            {
                MaHe = "QT",
                TenHe = "Chung chi quoc te"
            }
        };
    }
}