using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook 
{
    class Book
    {
        //Constructor writes like a method, must have the same name as the class, and cannot have a return type.
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(double grade in grades) 
            {
                if(grade > highGrade) 
                {
                    highGrade = grade;
                }

                if(grade < lowGrade)
                {
                    lowGrade = grade;
                }

                result += grade;
            }
            var total = grades.Count;
            var average = grades.Average();

            Console.WriteLine($"Average grade: {average:N2}  \nHighest grade: {highGrade} \nLowest grade: {lowGrade} ");
        }

        List<double> grades;
        string name;
    }
}