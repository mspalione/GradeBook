using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{

    class Program
    {
        
        static void Main(string[] args)
        {
            var book = new Book("Scott's gradebook");
            book.AddGrade(55.1);
            book.AddGrade(92.1);
            book.AddGrade(77.5);

            book.ShowStatistics();
        }
    }
}
