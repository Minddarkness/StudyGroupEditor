namespace StudyGroupEditor.Models.DatabaseModels;

public class Teacher
{
    public int TeacherId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public ICollection<Organization> Organizations { get; set; }
    public ICollection<Group> Groups { get; set; }

    public Teacher()
    {
        Organizations = new List<Organization>();
        Groups = new List<Group>();
    }
}