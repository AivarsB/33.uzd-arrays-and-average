using System;
using System.Collections.Generic;

namespace _33.uzd_arrays_and_average
{
    class Program
    {
        static void Main(string[] args)

        //{
        //    string[] studentsNames = new[] { "Janis", "Juris" };
        //    int[] student1Rating = new[] { 4, 5, 6, 7, 8 };
        //    int[] student2Rating = new[] { 5, 6, 7, 8, 9, 4, 5, 6, 1, 1 };

        //    foreach (var studentName in studentsNames)
        //    {
        //        Console.WriteLine(studentName);
        //    }

        //    Console.WriteLine(GetAverageValue(student1Rating));

        //    Console.WriteLine(GetAverageValue(student2Rating));



        //}

        //static double GetAverageValue(int[] values)
        //{
        //    var sum = 0;

        //    foreach (var value in values)
        //    {
        //        sum += value;
        //    }

        //    return sum / values.Length;
        //}

        {

            // var names = new[] { "Janis", "Peteris" };             //  versija 1
            var grades1 = new[] { 3, 5, 6, 7, 8, 7, 6, 5 };
            var grades2 = new[] { 3, 5, 4, 7, 5, 7, 2, 1 };

            // pēdējās metodes pie metodēm:           // pateiocoties atslēgas vārdam params

            var sum1 = SumValues(grades1);
            var sum2 = SumValues(new[] { 1, 5, 5 });
            var sum3 = SumValues(1, 5, 7);
            var sum4 = SumValues(4, 6, 8, 9, 2, 3, 4, 5, 6, 7, 8);

            PrintWithDefaultValues(name: "Gusts");
            PrintWithDefaultValues(name: "Janis", age: 13);
            PrintWithDefaultValues(name: "Petersss", age: 15, goesToSchool: true);

            return;                 // ar šo mēs apturam visu zemāk esošo 

            var studentDictionary = new Dictionary<string, int[]>();    // versija 2

            studentDictionary.Add("Janis", grades1);                       // versija 2
            studentDictionary.Add("Peteris", grades2);                      // versija 2

            while (true)
            {
                var newStudentWithGrades = addGrades();
                studentDictionary.Add(newStudentWithGrades.Item1, newStudentWithGrades.Item2);
                Console.WriteLine("Add another student (Y/N)? ");
                if (Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase))            // it kā kļūda ir te
                {
                    continue;
                }
                break;
            }


            // UZDEVUMS: pielikt studentu un viņa atzīmes

            //Console.Write("Enter name: ");
            //string name3 = Console.ReadLine();

            //Console.Write("Enter number of grades: ");
            //var numberOfGrades = Console.ReadLine();

            //int grades3 = new[numberOfGrades];


            //for (int i = 0; i < numberOfGrades; i++)
            //{
            //    Console.WriteLine($"Enter grade {i}: ");
            //    grades3[i] = Console.ReadLine();
            //}

            //studentDictionary.Add(name3, grades3);   

            addGrades();

            foreach (var item in studentDictionary)                         // versija 2
            {
                PrintAverageValue(item.Key, item.Value);
            }

            //PrintAverageValue(names[0], grades1);             // versija 1
            //PrintAverageValue(names[1], grades2);             // versija 1



        }

        private static Tuple<string, int[]> addGrades()
        {
            // 1. get student name

            Console.Write("Enter name: ");
            var studentName = Console.ReadLine();

            // 2. get student grades
            Console.Write("Enter grades separated by [,]: ");
            var userInput = Console.ReadLine();
            var gradeParts = userInput.Split(',');
            var grades = new int[gradeParts.Length];
            for (int i = 0; i < gradeParts.Length; i++)
            {
                grades[i] = int.Parse(gradeParts[i]);
            }

            return new Tuple<string, int[]>(studentName, grades);


        }

        static void PrintAverageValue(string studentName, int[] grades)
        {
            Console.WriteLine(studentName);


            double sum = 0;

            foreach (var grade in grades)
            {
                sum += grade;
            }

            var avg = sum / grades.Length;
            Console.WriteLine(avg.ToString("F"));               // noformatē lai ir 2 zīmes aiz komata

        }

        // vēl viens veids kā pierakstīt metodes
        static int SumValues(params int[] values)               // params nozīmē ka var pievienot kaut ko daudz reizes
        {
            var sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }

            return sum;
        }

        // metožu overload kad ar vienu vārdu vairāki parametri
        static void Print()
        {                               // šis ir bodijs, tam jābūt obligāti pie metodēm, kas neattiecas uz objektu orientēto program.

        }

        static void Print(string name)
        {

        }

        static void Print(int name)
        {

        }

        static void PrintWithDefaultValues(string name, int age=10, bool goesToSchool=false)            // defaultās vērtības jau ierakstītas
        {
            Console.WriteLine($"{name} {age} {goesToSchool}");
        }



    }
}

// Izveidot 3 masīvus.Pirmajā masīvā ir studentu vārdi.
// Otrajā masīvā ir pirmā studenta atzīmes.Trešajā masīvā ir otrā studenta atzīmes.
// Izvadīt uz ekrāna studenta vārdu un viņa vidējo atzīmi.
