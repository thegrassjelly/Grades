using System;
using System.Collections.Generic;
using System.IO;
using Grade;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Using ThrowAwayGradeBook class (inherited from GradeBook)
            var book = CreateGradeBook();

            try
            {
                using (var stream = File.Open("grades.txt", FileMode.Open))
                using (var reader = new StreamReader(stream))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not locate the file grades.txt. {0}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No access. {0}", ex);
            }


            foreach (var grade in book)
            {
                
            }


            try
            {
                //Console.WriteLine("Please Enter a name for the book");
                //book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid name. {0}", ex);
            }

            var stats = book.ComputeStatistics();

            Console.WriteLine("The average grade is {0}", stats.AverageGrade);
            Console.WriteLine("The lowest grade is {0}", stats.LowestGrade);
            Console.WriteLine("The highest grade is {0}", stats.HighestGrade);
            Console.WriteLine("The letter grade is {0}", stats.LetterGrade);
            Console.WriteLine(stats.Description);

            //int num = 20;
            //WriteBytes(num);
            //WriteBytes(stats.AverageGrade);

            //WriteNames(
            //    "A",
            //    "B",
            //    "C",
            //    "D",
            //    "E"
            //    );

            //book.NameChange += OnNameChange;
            //book.NameChange += OnNameChange2;
            //book.Name = "Allen's Book";
            //WriteNames(book.Name);

            //Arrays();
            //Immutable();
            //PassByValueAndRef();

            Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Scott's Book");
            return book;
        }

        static void GiveBookAName(ref GradeBook book)
        {
            book.Name = "The Gradebook";
        }

        static void IncNumber(ref int num)
        {
            num = 42;
        }

        private static void PassByValueAndRef()
        {
            var g1 = new GradeBook();
            var g2 = g1;

            GiveBookAName(ref g1);
            Console.WriteLine(g2.Name);

            int x1 = 4;
            IncNumber(ref x1);
            Console.WriteLine(x1);
        }

        private static void Immutable()
        {
            string name = " Scoot ";
            name = name.Trim();

            var date = new DateTime(2017, 1, 1);
            date = date.AddHours(25);

            Console.WriteLine(name);
            Console.WriteLine(date);
        }

        private static void Arrays()
        {
            var grades = new float[3];

            AddGrades(grades);

            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }
        }

        private static void AddGrades(float[] grades)
        {
            grades[0] = 91f;
            grades[1] = 89.1f;
            grades[2] = 75f;
        }

        // int param
        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytesArray(bytes);
        }

        // float param
        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytesArray(bytes);
        }

        // Print byte arrays
        private static void WriteBytesArray(byte[] bytes)
        {
            foreach (var b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }

        // infinite params using arrays (string)
        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        // Delegates and Events
        private static void OnNameChange(object sender, EventArgs args)
        {
            Console.WriteLine("Name change from {0} to {1}", sender, args);
        }

        // Delegates and Events
        private static void OnNameChange2(object sender, EventArgs args)
        {
            Console.WriteLine("***");
        }
    }
}