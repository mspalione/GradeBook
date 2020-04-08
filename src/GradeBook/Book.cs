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
            Name = name;
        }

        //public void AddLetterGrade(char letter)
        //{
        //    switch (letter)
        //    {
        //        case 'A':
        //            AddGrade(90);
        //            break;
        //        case 'B':
        //            AddGrade(80);
        //            break;
        //        case 'C':
        //            AddGrade(70);
        //            break;
        //        case 'D':
        //            AddGrade(60);
        //            break;
        //        case 'F':
        //            AddGrade(50);
        //            break;
        //        default:
        //            AddGrade(0);
        //            break;
        //    }
        //}

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Grade must be greater than or equal to 0 and less than or equal to 100.");
                throw new ArgumentException($"Invalid {nameof(grade)}.");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var highGrade = double.MinValue;            
            var lowGrade = double.MaxValue;

            var index = 0;
            var count = grades.Count;
            //foreach(double grade in grades) 
            while (index < count)
            {
                if (grades[index] > highGrade)
                {
                    highGrade = grades[index];
                }

                if (grades[index] < lowGrade)
                {
                    lowGrade = grades[index];
                }
                index++;
            } 

            result.Average = grades.Average();
            result.High = highGrade;
            result.Low = lowGrade;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        List<double> grades;
        public string Name;
    }
}