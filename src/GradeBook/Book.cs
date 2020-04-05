using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook 
{
    public class Book
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
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
            }

            result.Average = grades.Average();
            result.High = highGrade;
            result.Low = lowGrade;

            return result;
        }

        List<double> grades;
        string name;
    }
}