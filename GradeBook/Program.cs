using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Sarah's book");
            book.AddGrade(89.1);
            book.AddGrade(100);
            book.AddGrade(64.1);
            book.AddGrade(75.2);
            book.GetStatistics();

            var stats = book.GetStatistics();
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");


        }
    }
}
