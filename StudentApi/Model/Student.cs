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
