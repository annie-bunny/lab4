using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        private string name;
        private int sumb;
        private static Random rnd = new Random();

        public void SetValue(string n)
        {
            name = n;
            sumb = rnd.Next(0, 100);
        }

        public override string ToString()
        {
            return "Имя: " + name + ", Кол-во баллов: " + sumb;
        }

        public static Student[] InitAr(Student[] stud)
        {
            for (int i = 0; i < stud.Length; i++)
                stud[i] = new Student();
            return stud;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] stud = new Student[3];
            Student.InitAr(stud);
            for (int i = 0; i < stud.Length; i++)
            {
                stud[i].SetValue("Student" + i);
                Console.WriteLine(stud[i]);
            }
        }
    }
}
