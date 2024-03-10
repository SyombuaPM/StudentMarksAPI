using StudentAPI;

namespace StudentApi.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestTotalMarks()
        {
            var student = new Student(1, "Test", 70, 80, 90);
            Assert.AreEqual(240, student.TotalMarks);
        }

        [TestMethod]
        public void TestAverage()
        {
            var student = new Student(1, "Test", 70, 80, 90);
            Assert.AreEqual(80, student.Average);
        }

        [TestMethod]
        public void TestGradeA()
        {
            var student = new Student(1, "Test", 70, 80, 90);
            Assert.AreEqual('A', student.Grade);
        }

        [TestMethod]
        public void TestGradeB()
        {
            var student = new Student(1, "Test", 60, 70, 80);
            Assert.AreEqual('B', student.Grade);
        }

        [TestMethod]
        public void TestGradeC()
        {
            var student = new Student(1, "Test", 50, 60, 70);
            Assert.AreEqual('C', student.Grade);
        }
        [TestMethod]
        public void TestGradeD()
        {
            var student = new Student(1, "Test", 40, 50, 60);
            Assert.AreEqual('D', student.Grade);
        }

        [TestMethod]
        public void TestGradeF()
        {
            var student = new Student(1, "Test", 30, 40, 50);
            Assert.AreEqual('F', student.Grade);
        }
    }
}