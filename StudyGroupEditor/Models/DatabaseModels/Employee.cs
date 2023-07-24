namespace StudyGroupEditor.Models.DatabaseModels;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    
    public int? OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public ICollection<Group> Groups { get; set; }
}