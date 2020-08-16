using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string title)
        {
            grades = new List<double>();
            this.title = title;
        }

        List<double> grades;
        public string title;

        public void AddGrade(double grade)
        {
            if(grade < 0 || grade > 100)
            {
                throw new Exception("grade out of range");
            }
            else
            {
                grades.Add(grade);
            }
        }

        public Stats GetStats()
        {
            var result = new Stats();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            if(grades.Count <= 0)
            {
                Console.WriteLine("There are no grades in this book.");
            } 
            else
            {
                foreach (var grade in grades)
                {
                    result.Low = Math.Min(grade, result.Low);
                    result.High = Math.Max(grade, result.High);
                    result.Average += grade;
                }

                result.Average /= grades.Count;
            }

            return result;

        }



    }
}