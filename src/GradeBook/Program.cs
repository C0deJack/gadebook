using System;
using System.Collections.Generic;

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

            book.ShowStats();
        }
    }

}
