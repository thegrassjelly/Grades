using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Grades;

namespace Grade
{
    public class GradeBook : GradeTracker
    {
        protected List<float> _grades;

        private string _name;

        public GradeBook(string name = "There is no name")
        {
            Console.WriteLine("GradeBook ctor");
            Name = name;
            _grades = new List<float>();
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }  
        }
        
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook statistics method");
            GradeStatistics stats = new GradeStatistics();

            var sum = 0f;

            foreach (var grade in _grades)
            {
                // Compare and replace grades in the List<T>
                // Base comparison of 0 for highest grade to ensure replacement in init
                // Base comparison of float.MaxValue grade to ensure replacement in init
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = (float)Math.Round(sum / _grades.Count);
            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            int i = 0;
            while (i < _grades.Count)
            {
                textWriter.WriteLine(_grades[i]);
                i++;
            }

            textWriter.WriteLine("**********");
        }
    }
}
