using Microsoft.EntityFrameworkCore;

namespace StudentAPI;

public class StudentService
{
    private readonly StudentDBContext _context;

    public StudentService(StudentDBContext context)
    {
        _context = context;
    }

    public List<Student> GetStudents()
    {
        return _context.Students.ToList();
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        var list = _context.Students.ToListAsync();
        //Task.Delay(1000);
        return await list;
    }



    public Student GetStudent(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void UpdateStudent(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }

    // Write a method PopulateData that will add a given number of students to the database and ensure the sum of Eng, Mat, Sci would lead to grades are evenly distributed where possible. 
    // Let every student have 2 names.
    // Use constructor to generate the student.
    public void PopulateData(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            string name = "Student" + i;
            int mat = random.Next(0, 101);
            int eng = random.Next(0, 101);
            int sci = random.Next(0, 101);
            _context.Students.Add(new Student(i, name, mat, eng, sci));
        }
        _context.SaveChanges();
    }



}
