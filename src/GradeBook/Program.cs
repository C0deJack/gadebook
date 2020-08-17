using System;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            var book = new Book("Tom's grades");

            book.AddGrade(55.1);
            book.AddGrade(14.1);
            book.AddGrade(5.1);
            book.AddGrade(88.0);

            var stats = book.GetStats();

            Console.WriteLine($"Stats for: {book.Title}");
            Console.WriteLine($"The average grade is {stats.Average:N2}%");
            Console.WriteLine($"The lowest grade is {stats.Low:N2}%");
            Console.WriteLine($"The highest grade is {stats.High:N2}%"); 
        }
    }

}
