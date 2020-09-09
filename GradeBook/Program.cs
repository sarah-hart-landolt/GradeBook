﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Sarah's Grade Book");
            book.GradeAdded += OnGradedAdded;

            
            while (true)
            {
               
                Console.WriteLine($"Enter a grade or 'q' to quit");

                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
             
            }



            var stats = book.GetStatistics();
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");


            static void OnGradedAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added");
            }

        }
    }
}
