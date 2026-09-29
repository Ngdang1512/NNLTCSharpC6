using System;
using System.Collections;
using Lab02_ThucHanh02.Phan1_LopCoBan;

namespace Lab02_ThucHanh02.Phan2_LopNangCao
{
    public class ArrayPoint
    {
        private ArrayList danhSachPoint;

        public ArrayPoint()
        {
            danhSachPoint = new ArrayList();
        }

        public void Add(Point p)
        {
            danhSachPoint.Add(p);
        }

        public int Count
        {
            get { return danhSachPoint.Count; }
        }

        public Point this[int i]
        {
            get
            {
                if (i >= 0 && i < danhSachPoint.Count)
                {
                    return (Point)danhSachPoint[i];
                }
                throw new IndexOutOfRangeException("Chi so vuot qua pham vi danh sach!");
            }
            set
            {
                if (i >= 0 && i < danhSachPoint.Count)
                {
                    danhSachPoint[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua pham vi danh sach!");
                }
            }
        }
    }

    public class Bai2_1
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 2.1: LOP ARRAY POINT VOI INDEXER ---");

            ArrayPoint arrPoint = new ArrayPoint();

            arrPoint.Add(new Point(1, 2));
            arrPoint.Add(new Point(3, 4));
            arrPoint.Add(new Point(-5, 6));

            Console.WriteLine($"Danh sach dang co {arrPoint.Count} diem.");

            for (int i = 0; i < arrPoint.Count; i++)
            {
                Console.WriteLine($"Diem thu {i}: {arrPoint[i]}");
            }

            Console.WriteLine("\nThay doi toa do Diem thu 0 thanh (9, 9)...");
            arrPoint[0] = new Point(9, 9);

            Console.WriteLine($"Diem thu 0 sau khi thay doi: {arrPoint[0]}");
        }
    }
}