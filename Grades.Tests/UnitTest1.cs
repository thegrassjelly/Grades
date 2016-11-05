using System;
using Grade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTest
    {
        [TestMethod]
        public void CalculateHighestGrade()
        {
            var book = new GradeBook();

            book.AddGrade(90f);
            book.AddGrade(50f);

            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual("Not set", book.Name);
        }

        [TestMethod]
        public void PassByValue()
        {
            var book = new GradeBook();
            book.Name = "Not Set";
            SetName(book);
        }

        private void SetName(GradeBook book)
        {
            book.Name = "Name Set";
        }
    }
}
