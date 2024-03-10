using Microsoft.AspNetCore.Mvc;


namespace StudentAPI;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet(Name = "GetStudents")]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _studentService.GetStudentsAsync();
        if (students == null)

            return NotFound();
        else
            return students;

    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<Student> GetStudent(int id)
    {
        var students = _studentService.GetStudent(id);
        if (students == null)

            return NotFound(new {Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found" });
        else
            return students;
    }

    [HttpPost(Name = "AddStudent")]
    public ActionResult Post([FromBody] Student student)
    {
        _studentService.AddStudent(student);
        return CreatedAtAction(nameof(Post), new { id = student.Id }, new {Student =student, Code=700, Description="Student added successfully"})
        ;


    }

    [HttpPut(Name = "UpdateStudent")]
    public void Put([FromBody] Student student)
    {
        _studentService.UpdateStudent(student);
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    public void Delete(int id)
    {
        _studentService.DeleteStudent(id);
    }

    

    [HttpPatch("{id}", Name = "PatchStudentMarks")]
    public ActionResult UpdateMatMarks(int id, int Marks)
    {
        var s = _studentService.GetStudent(id);
        if (s == null)
        {
            return NotFound(new { Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found" });
        }
        else
        {
            s.Mat = Marks;
            _studentService.UpdateStudent(s);
            return Ok(new { Student = s, Code = 700, Description = "Student updated successfully" });
        }
    }

    [HttpPatch("Marks/{id}", Name = "PatchStudent_Marks")]
    public ActionResult UpdateMarks(int id, int Mat, int Eng, int Sci)
    {
        var s = _studentService.GetStudent(id);
        if (s == null)
        {
            return NotFound(new { Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found" });
        }
        else
        {
            s.Mat = Mat;
            s.Eng = Eng;
            s.Sci = Sci;
            _studentService.UpdateStudent(s);
            return Ok(new { Student = s, Code = 700, Description = "Student marks updated successfully" });
        }

        
    }

   public struct PatchStudentMarks
    {
        public int Mat { get; set; }
        public int Eng { get; set; }
        public int Sci { get; set; }
    }

    [HttpPatch("AllMarks/{id}", Name = "PatchStudent_Marks2")]

    public ActionResult UpdateMarks(int id, [FromBody] PatchStudentMarks marks)
    {
        var s = _studentService.GetStudent(id);
        var s_Old = new PatchStudentMarks { Mat = s.Mat, Eng = s.Eng, Sci = s.Sci };
        if (s == null)
        {
            return NotFound(new { Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found" });
        }
        else
        {
            
            s.Mat = marks.Mat;
            s.Eng = marks.Eng;
            s.Sci = marks.Sci;
            _studentService.UpdateStudent(s);
            return Ok(new { Student = s, Old = s_Old, Code = 700, Description = "Student marks updated successfully" });
            
        }
    }
    /*public async Task<List<Student>> GetStudentsAsync()
    {
        return await Task.FromResult(_studentService.GetStudents());
    }*/




}
