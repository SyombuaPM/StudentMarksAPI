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
        Task.Delay(1000);
        return  await list;
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
        _context.Students.Remove(student);
        _context.SaveChanges();
    }

}
