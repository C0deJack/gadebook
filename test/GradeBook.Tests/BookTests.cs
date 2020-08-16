using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(55.2);
            book.AddGrade(21);
            book.AddGrade(11.1);
            book.AddGrade(98.8);

            // act
            var result = book.GetStats();

            // assert
            Assert.Equal(47, result.Average, 0);
            Assert.Equal(98.8, result.High);
            Assert.Equal(11.1, result.Low);
        }
    }
}
