using System;
using System.Collections.Generic;
using Lab02_ThucHanh02.Phan1_LopCoBan;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class PersonList
    {
        private List<Person> danhSach;

        public PersonList()
        {
            danhSach = new List<Person>();
        }

        public PersonList(PersonList other)
        {
            danhSach = new List<Person>();
            foreach (Person p in other.danhSach)
            {
                this.danhSach.Add(new Person(p));
            }
        }

        public void Add(Person x)
        {
            danhSach.Add(x);
        }

        public void Input()
        {
            Console.Write("Nhap so luong nguoi muon them: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\n--- Nhap thong tin Nguoi thu {i + 1} ---");
                    Person p = new Person();
                    p.Input();
                    this.Add(p);
                }
            }
        }

        public void Output()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach trong.");
                return;
            }

            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                danhSach[i].Output();
            }
        }

        public PersonList LivingPeople()
        {
            PersonList ketQua = new PersonList();

            foreach (Person p in danhSach)
            {
                if (p.IsLiving())
                {
                    ketQua.Add(p);
                }
            }

            return ketQua;
        }
    }

    public class Bai2_2
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.2: QUAN LY NHAN KHAU (PERSON LIST) ---");

            PersonList danhSachGoc = new PersonList();

            Console.WriteLine("[1] Tieu trinh nhap danh sach:");
            danhSachGoc.Input();

            Console.WriteLine("\n[2] Danh sach toan bo nhan khau vua nhap:");
            danhSachGoc.Output();

            Console.WriteLine("\n[3] Danh sach nhung nguoi con song:");
            PersonList danhSachConSong = danhSachGoc.LivingPeople();
            danhSachConSong.Output();

            Console.WriteLine("\n[4] Kiem tra Copy Constructor (Sao chep danh sach goc):");
            PersonList danhSachSaoChep = new PersonList(danhSachGoc);
            danhSachSaoChep.Output();
        }
    }
}