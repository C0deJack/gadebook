using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();

            List<double> grades = new List<double>() {11.5, 9.5, 8.0, 11.1, 40.3};

            grades.Add(20.2);

            var results = 0.0;

            foreach(var number in grades)
            {
              results += number;
            }

            results /= grades.Count; 

            Console.WriteLine($"The average grade is {results:N1}");
        }
    }

}
