namespace StudyGroupEditor.Models.DatabaseModels;

public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; }
    
    public int? TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int? CourseId { get; set; }
    public Course Course { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
}