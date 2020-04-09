using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GradeBook
{

    class Program
    {
        
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott's gradebook");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade: {stats.Average:N2}  \nHighest grade: {stats.High} \nLowest grade: {stats.Low} \nLetter grade: {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            //loop until q or quit
            while (true)
            {
                Console.WriteLine("Please enter a grade. Type q to quit.");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    Console.WriteLine("Finished entering new grades. Computing statistics.");
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }

   
}
