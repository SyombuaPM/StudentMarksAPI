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
            Assert.AreEqual('A', student.Grade);
        }

        [TestMethod]
        public void TestGradeC()
        {
            var student = new Student(1, "Test", 50, 60, 70);
            Assert.AreEqual('B', student.Grade);
        }
        [TestMethod]
        public void TestGradeD()
        {
            var student = new Student(1, "Test", 40, 50, 60);
            Assert.AreEqual('C', student.Grade);
        }

        [TestMethod]
        public void TestGradeF()
        {
            var student = new Student(1, "Test", 30, 40, 50);
            Assert.AreEqual('D', student.Grade);
        }
        [TestMethod]
        public void TestStudentNameCannotBeNullOrEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student(1, "", 30, 40, 50));
            Assert.ThrowsException<ArgumentException>(() => new Student(1, null, 30, 40, 50));
        }

        [TestMethod]
        public void TestStudentScoresCannotBeNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student(1, "Test", -1, 40, 50));
            Assert.ThrowsException<ArgumentException>(() => new Student(1, "Test", 30, -1, 50));
            Assert.ThrowsException<ArgumentException>(() => new Student(1, "Test", 30, 40, -1));
        }

        [TestMethod]
        public void TestStudentScoresBoundaryValues()
        {
            var student = new Student(1, "Test", 0, 0, 0);
            Assert.AreEqual('F', student.Grade);

            student = new Student(1, "Test", 100, 100, 100);
            Assert.AreEqual('A', student.Grade);
        }
    }
}