using System;
using System.Collections;
using System.IO;
using Grades;

namespace Grade
{
    public interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter textWriter);
        string Name { get; set; }
        event NameChangeDelegate NameChange;

        void DoSomething();

    }

    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter textWriter);

        private string _name;

        public event NameChangeDelegate NameChange;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value)
                {
                    var oldVal = _name;
                    _name = value;
                    if (NameChange != null)
                    {
                        var args = new NameChangeEventArgs();
                        args.OldValue = oldVal;
                        args.NewValue = value;
                        NameChange(this, args);
                    }
                }
            }
        }

        public void DoSomething()
        {
            //..
        }

        public abstract IEnumerator GetEnumerator();
    }
}
