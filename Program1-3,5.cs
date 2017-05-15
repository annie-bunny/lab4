using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTest
{

    class Program
    {

        class Arrs
        {

            public static void PrintAnyArr(string name, Array A)
            {
                Console.WriteLine(name);
                int n = A.Rank;
                if (n == 1)
                {
                    var en = A.GetEnumerator();

                    en.MoveNext();
                    if (en.Current.GetType() == Type.GetType("System.Int32"))
                        for (int i = 0; i < A.GetLength(0); i++)
                            Console.Write(A.GetValue(i) + " ");
                    else
                        foreach (int[] mas in A)
                        {
                            for (int i = 0; i < mas.GetLength(0); i++)
                                Console.Write(mas.GetValue(i) + " ");
                            Console.WriteLine();
                        }
                }
                if (n == 2) //матрица
                {
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            Console.Write(A.GetValue(i, j) + " ");
                        }
                        Console.WriteLine();
                    }

                }
                if (n > 2)
                {
                    throw new NotSupportedException("Массивы размерностью 3 и более не поддерживаются");
                }

            }

            public static void PrintAnyArr2(string name, Array arr)
            {
                Console.WriteLine("Массив - " + name);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine("\n");
            }

            //Вывод массива типа Object
            public static void PrintObjectAr(string name, object ar)
            {
                Array newAr = ar as Array;
                if (newAr == null)
                {
                    Console.WriteLine("Ошибка! Это не массив");
                    return;
                }
                else
                {
                    Console.WriteLine(name);
                    int rank = newAr.Rank;
                    Console.WriteLine(newAr.Rank);
                    if (rank == 1)
                    {
                        if (ar.GetType() == Type.GetType("System.Object[]"))
                        {
                            foreach (int value in newAr)
                                Console.Write("{0} ", value);
                            Console.WriteLine();
                        }
                        else
                        {
                            foreach (object[] row in newAr)
                            {
                                for (int i = 0; i < row.GetLength(0); i++)
                                    Console.Write("{0} ", row.GetValue(i));
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < newAr.GetLength(0); i++)
                        {
                            for (int j = 0; j < newAr.GetLength(1); j++)
                                Console.Write("{0} ", newAr.GetValue(i, j));
                            Console.WriteLine();
                        }
                    }
                }
            }

            //Вывод массивов разных типов
            public static void PrintArObj(string name, object[] ar)
            {
                Console.WriteLine(name);

                foreach (object value in ar)
                    Console.WriteLine(value + " ");
            }

        }


        static void Main(string[] args)
        {

            int[] A = { 6, 2, 9, 5 };
            int[] A1 = { 3, 6, 2, 4 };
            int[,] B = { { 4, 2, 3 }, { 4, 8, 6 } };
            int[][] C = new int[3][]
			 {
				new int[] {1,2,3},
				new int[] {4,5,6,7,8},
				new int[] {9}
			 };

            Arrs.PrintAnyArr("Одномерный массив", A);
            Console.WriteLine();
            Arrs.PrintAnyArr("Матрица", B);
            Console.WriteLine();
            Arrs.PrintAnyArr("Усеченный массив", C);

            //
            Arrs.PrintAnyArr2("A", A);
            Arrs.PrintAnyArr2("A1", A1);

            Array.Copy(A, A1, 3);

            Arrs.PrintAnyArr2("A1", A1);

            int[] X = { 1, 2, 3, 3, 2, 1 };
            Arrs.PrintAnyArr2("X", X);

            Console.Write("Введите число: ");
            int p = int.Parse(Console.ReadLine());

            int iprew = Array.IndexOf(X, p);
            int ilast = Array.LastIndexOf(X, p);

            if (iprew != -1)
            {
                Console.WriteLine("Индекс первого вхождения " + iprew + " в массиве X");
                Console.WriteLine("Индекс последнего вхождения " + ilast + " в массиве X\n");
            }
            else Console.WriteLine("Не найдено\n");

            Arrs.PrintAnyArr2("A1", A1);

            Array.Reverse(A1);
            Arrs.PrintAnyArr2("reverse A1", A1);

            Array.Sort(A1);
            Arrs.PrintAnyArr2("sort A1", A1);

            Console.Write("Введите число: ");
            p = int.Parse(Console.ReadLine());
            Console.WriteLine("Индекс первого вхождения вашего числа в массив A1: " + Array.BinarySearch(A1, p) + "\n");

            //Класс Object и массивы

            int[,] A2 = { { 4, 2, 3 }, { 4, 8, 6 }, {4, 7, 5 } };



            Arrs.PrintAnyArr("", A2);
            Console.WriteLine("GetLength выводит количество элементов заданного измерения, для двумерного массива 3х3 результатом будет - 3");
            Console.WriteLine("Пример - {0}", A2.GetLength(0));
            Console.WriteLine("Length выводит общее количество элементов заданного массива, для массива 3х3 результатом будет - 9");
            Console.WriteLine("Пример - {0}", A2.Length);
            
            //
            object[] ar = { 1, 2, 3, 4, 5 };

            object[][] ar2 = {
                             new object[3] {1,2,3},
                             new object[3] {4,5,6}
                         };

            object[,] ar3 = { { 1, 2 }, { 3, 4 } };

            Arrs.PrintObjectAr("Одномерный массив", ar);
            Arrs.PrintObjectAr("Усеченный", ar2);
            Arrs.PrintObjectAr("Двумерный массив", ar3);
            

            //Вывод массивов разных типов
            
            int[] intAr = { 1, 2, 3 };
            double[] dAr = { 1.1, 2.2, 3.3 };
            string[] strAr = { "ONE", "TWO", "THREE" };

            Arrs.PrintArObj("Строковый", strAr);
        }

    }

}