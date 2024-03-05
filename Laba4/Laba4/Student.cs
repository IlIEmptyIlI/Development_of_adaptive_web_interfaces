using System;

namespace Laba4
{
    internal class Student
    {
        public int id;
        private string name;
        protected bool isStudying;
        protected internal double gpa;
        internal int age;

        public Student(int id, string name, int age, double gpa, bool isStudying)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gpa = gpa;
            this.isStudying = isStudying;
        }

        public void WriteTextGPA()
        {
            if (gpa >= 4.0)
            {
                Console.WriteLine("Отличный студент!");
            }
            else if (gpa >= 3.0)
            {
                Console.WriteLine("Хороший студент.");
            }
            else if (gpa >= 2.0)
            {
                Console.WriteLine("Студент среднего уровня.");
            }
            else
            {
                Console.WriteLine("Необходимо больше усилий.");
            }
        }

        public void WriteInfo()
        {
            string studyingStatus = isStudying ? "учится" : "не учится";
            Console.WriteLine($"Студент {name}, возраст: {age}, GPA: {gpa}, статус: {studyingStatus}");
        }
    }
}