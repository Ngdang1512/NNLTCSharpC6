using System;

namespace Lab02_ThucHanh02.Phan1_LopCoBan
{
    public class Person
    {
        private string id;
        private string name;
        private int yob;
        private int yod;

        public Person()
        {
            id = "";
            name = "Unknown";
            yob = 0;
            yod = 0;
        }

        public Person(Person otherPerson)
        {
            this.id = otherPerson.id;
            this.name = otherPerson.name;
            this.yob = otherPerson.yob;
            this.yod = otherPerson.yod;
        }

        public void Input()
        {
            Console.Write("Nhap ID: ");
            id = Console.ReadLine();

            Console.Write("Nhap ho ten (Name): ");
            name = Console.ReadLine();

            Console.Write("Nhap nam sinh (YOB): ");
            if (!int.TryParse(Console.ReadLine(), out yob)) yob = 0;

            Console.Write("Nhap nam mat (YOD) - Nhap 0 neu con song: ");
            if (!int.TryParse(Console.ReadLine(), out yod)) yod = 0;
        }

        public void Output()
        {
            string trangThai = (yod == 0) ? "Con song" : $"Da mat nam {yod}";
            Console.WriteLine($"- ID: {id} | Name: {name} | YOB: {yob} | Trang thai: {trangThai}");
        }

        public bool IsLiving()
        {
            return yod == 0;
        }
    }

    public class Bai1_3
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 1.3: LOP PERSON ---");

            Person nguoi1 = new Person();
            Console.WriteLine("Moi nhap thong tin Nguoi 1:");
            nguoi1.Input();

            Console.WriteLine("\nHe thong tu dong tao Nguoi 2 sao chep tu Nguoi 1...");
            Person nguoi2 = new Person(nguoi1);

            Console.WriteLine("\n--- Thong tin ---");
            Console.Write("Nguoi 1: ");
            nguoi1.Output();
            Console.WriteLine($"=> Nguoi 1 con song khong? {nguoi1.IsLiving()}");

            Console.Write("\nNguoi 2 (Ban sao): ");
            nguoi2.Output();
        }
    }
}