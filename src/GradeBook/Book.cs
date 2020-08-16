using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book 
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

        public void ShowStats()
        {
            if(grades.Count <= 0)
            {
                Console.WriteLine("There are no grades in this book.");
            } else {

                var aveGrade = 0.0;
                var maxGrade = double.MinValue;
                var minGrade = double.MaxValue;

                foreach (var number in grades)
                {
                    minGrade = Math.Min(number, minGrade);
                    maxGrade = Math.Max(number, maxGrade);
                    aveGrade += number;
                }

                aveGrade /= grades.Count;

                Console.WriteLine($"Stats for: {title}");
                Console.WriteLine($"The average grade is {aveGrade:N2}%");
                Console.WriteLine($"The lowest grade is {minGrade:N2}%");
                Console.WriteLine($"The highest grade is {maxGrade:N2}%"); 

            }

        }

    }
}