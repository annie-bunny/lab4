using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        class Vector
        {
            private int Start;
            private int End;
            private int Length;
            private int[] ar;
            private static Random rnd = new Random();

            public Vector(int S, int E)
            {
                if (S > E)
                {
                    Console.WriteLine("Неверный ввод границ");
                }
                else
                {
                    Start = S;
                    End = E;
                    Length = E - S;
                    ar = new int[Length];
                }
            }

            public void CreateAr()
            {
                for (int i = 0; i < ar.Length; i++)
                    ar[i] = rnd.Next(0, 9);
            }

            public void GetElement(int number)
            {
                if (number > End || number < Start)
                {
                    Console.WriteLine("Выход за пределы массива");
                    return;
                }
                else
                {
                    Console.WriteLine("Под номером {0} находится элемент - {1}", number, ar[number - Start]);
                }
            }

            public static void PrintAr(string s, Vector v)
            {
                Console.WriteLine(s);
                for (int i = 0; i < v.ar.Length; i++)
                    Console.Write(v.ar[i] + " ");
                Console.WriteLine();
            }

            public static Vector SumAr(Vector a, Vector b)
            {
                Vector c = new Vector(a.Start, a.End);
                for (int i = 0; i < a.Length; i++)
                    c.ar[i] = a.ar[i] + b.ar[i];
                return c;
            }

            public static Vector SubAr(Vector a, Vector b)
            {
                Vector c = new Vector(a.Start, a.End);
                for (int i = 0; i < a.Length; i++)
                    c.ar[i] = a.ar[i] - b.ar[i];
                return c;
            }

            public static void Del_na_skolar(Vector a, int temp)
            {
                Vector c = new Vector(a.Start, a.End);
                for (int i = 0; i < a.Length; i++)
                    a.ar[i] /= temp;
            }
            public static void Ymn_na_skolar(Vector a, int temp)
            {
                Vector c = new Vector(a.Start, a.End);
                for (int i = 0; i < a.Length; i++)
                    a.ar[i] *= temp;
            }
        }
        static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 8), v2 = new Vector(3, 8), v3, v4;
            v1.CreateAr();
            Vector.PrintAr("Первый массив", v1);
            v2.CreateAr();
            Vector.PrintAr("Второй массив", v2);
            v3 = Vector.SumAr(v1, v2);
            Vector.PrintAr("Сумма массивов", v3);
            v4 = Vector.SubAr(v1, v2);
            Vector.PrintAr("Разность массивов", v4);
            Vector.Del_na_skolar(v3, 2);
            Vector.PrintAr("Деление суммы на сколяр", v3);
            Vector.Ymn_na_skolar(v4, 2);
            Vector.PrintAr("Умножение разности на сколяр", v4);
            v4.GetElement(6);
        }
    }
}
