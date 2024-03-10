using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI;

[Table("Student")]
public class Student
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Mat { get; set; }
    public int Eng { get; set; }
    public int Sci { get; set; }

    public Student(int id, string name, int mat, int eng, int sci)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        if (id < 0)
        {
            throw new ArgumentException("Id cannot be negative");
        }
        if (mat < 0 || mat > 100)
        {
            throw new ArgumentException("Mat should be between 0 and 100");
        }
        if (eng < 0 || eng > 100)
        {
            throw new ArgumentException("Eng should be between 0 and 100");
        }
        if (sci < 0 || sci > 100)
        {
            throw new ArgumentException("Sci should be between 0 and 100");
        }
        
        
        Id = id;
        Name = name;
        Mat = mat;
        Eng = eng;
        Sci = sci;
    }

    public Student()
    {
    }

    [NotMapped]
    public int TotalMarks
    {
        get
        {
            return Mat + Eng + Sci;
        }
    }

    public double Average
    {
        get
        {
            return TotalMarks / 3;
        }
    }

    [NotMapped]
    public char Grade
    {
        get
        {
            double avg = Average;
            if (avg >= 70)
            {
                return 'A';
            }
            else if (avg >= 60)
            {
                return 'B';
            }
            else if (avg >= 50)

            {
                return 'C';
            }
            else if (avg >= 40)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }

}
