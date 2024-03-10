using Microsoft.EntityFrameworkCore;

namespace StudentAPI;

public class StudentDBContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Name.db");
        //optionsBuilder.UseInMemoryDatabase("Name");
    }
   

}
