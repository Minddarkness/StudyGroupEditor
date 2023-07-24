using Microsoft.EntityFrameworkCore;

namespace StudyGroupEditor.Models.DatabaseModels;

public class UniversityContext  : DbContext
{
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    
    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
}