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
            var book = new Book("Scott's gradebook");
            //loop until q or quit
            Console.WriteLine("Please enter a grade. Type q to quit.");
            var input = Console.ReadLine();
            var lower = input.ToLower();
            List<double> grades = new List<double>();

            while (true)
            {
            newInput:
                var test = Regex.Replace(input, "[^0-9.]", "");
                if (input == test)
                {
                    var grade = double.Parse(input);
                    Console.WriteLine($"You entered {input}. \nPlease enter the next grade. Type q to quit.");
                    book.AddGrade(grade);
                    grades.Add(grade);
                }
                else if (lower == "q" || lower == "quit")
                {
                    if(grades.Count == 0)
                    {
                        Console.WriteLine("You haven't entered a grade. To quit the program, select 'q' again. Otherwise, enter a grade.");
                        input = Console.ReadLine();
                        lower = input.ToLower();
                        if (lower == "q" || lower == "quit")
                        {
                            goto End;
                        } 
                        else
                        {
                            goto newInput;
                        }
                    }
                    Console.WriteLine("Finished entering new grades. Computing statistics.");
                    break;
                }
                else
                {
                    Console.WriteLine("You did not enter a valid grade. Please only enter numbers between 0 and 100.");
                }
                input = Console.ReadLine();
                lower = input.ToLower();
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade: {stats.Average:N2}  \nHighest grade: {stats.High} \nLowest grade: {stats.Low} \nLetter grade: {stats.Letter}");
        End:
            Console.WriteLine("Program complete.");

        }
    }
}
