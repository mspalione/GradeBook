using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] //[Fact] is an attribute. goes looking for Fact "decorations" to know what to test as pass or fail.
        public void BookCalculatesAnAverageGrade()
        {
            // arrange all test data and arrange all objects and values that you will use
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act envoke a method to perform a calculation, do something that produces the actual result 
            var result = book.GetStatistics();

            // assert assert something about the value that was computed inside of act
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
