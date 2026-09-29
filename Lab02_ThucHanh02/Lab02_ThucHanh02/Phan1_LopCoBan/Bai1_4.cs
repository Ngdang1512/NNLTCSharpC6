using System;

namespace Lab02_ThucHanh02.Phan1_LopCoBan
{
    public class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        public PhanSo(int tu, int mau)
        {
            tuSo = tu;
            mauSo = (mau == 0) ? 1 : mau;
            RutGon();
        }

        public PhanSo(PhanSo p)
        {
            tuSo = p.tuSo;
            mauSo = p.mauSo;
        }

        private int TìmUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a | b;
        }

        private void RutGon()
        {
            int ucln = TìmUCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;

            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }

        public override string ToString()
        {
            if (mauSo == 1) return tuSo.ToString();
            if (tuSo == 0) return "0";
            return $"{tuSo}/{mauSo}";
        }

        public static PhanSo operator +(PhanSo a) => new PhanSo(a.tuSo, a.mauSo);
        public static PhanSo operator -(PhanSo a) => new PhanSo(-a.tuSo, a.mauSo);

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo + b.tuSo * a.mauSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo - b.tuSo * a.mauSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.tuSo, a.mauSo * b.mauSo);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo, a.mauSo * b.tuSo);
        }

        public static bool operator >(PhanSo a, PhanSo b) => (double)a.tuSo / a.mauSo > (double)b.tuSo / b.mauSo;
        public static bool operator <(PhanSo a, PhanSo b) => (double)a.tuSo / a.mauSo < (double)b.tuSo / b.mauSo;
        public static bool operator >=(PhanSo a, PhanSo b) => (double)a.tuSo / a.mauSo >= (double)b.tuSo / b.mauSo;
        public static bool operator <=(PhanSo a, PhanSo b) => (double)a.tuSo / a.mauSo <= (double)b.tuSo / b.mauSo;

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return ReferenceEquals(a, b);
            return a.tuSo * b.mauSo == b.tuSo * a.mauSo;
        }

        public static bool operator !=(PhanSo a, PhanSo b) => !(a == b);

        public override bool Equals(object obj)
        {
            if (obj is PhanSo) return this == (PhanSo)obj;
            return false;
        }

        public override int GetHashCode() => tuSo.GetHashCode() ^ mauSo.GetHashCode();
    }

    public class Bai1_4
    {
        public static void Run()
        {
            Console.WriteLine("--- BAI 1.4: LOP PHAN SO ---");

            PhanSo ps1 = new PhanSo(1, 2);
            PhanSo ps2 = new PhanSo(3, 4);

            Console.WriteLine($"Phan so 1: {ps1}");
            Console.WriteLine($"Phan so 2: {ps2}");

            Console.WriteLine("\n--- Phep toan 2 ngoi ---");
            Console.WriteLine($"Cong: {ps1} + {ps2} = {ps1 + ps2}");
            Console.WriteLine($"Tru : {ps1} - {ps2} = {ps1 - ps2}");
            Console.WriteLine($"Nhan: {ps1} * {ps2} = {ps1 * ps2}");
            Console.WriteLine($"Chia: {ps1} / {ps2} = {ps1 / ps2}");

            Console.WriteLine("\n--- Phep toan 1 ngoi ---");
            Console.WriteLine($"Phep am cua {ps1} la {-ps1}");

            Console.WriteLine("\n--- Phep toan so sanh ---");
            Console.WriteLine($"{ps1} > {ps2}: {ps1 > ps2}");
            Console.WriteLine($"{ps1} < {ps2}: {ps1 < ps2}");
            Console.WriteLine($"{ps1} == {ps2}: {ps1 == ps2}");
        }
    }
}