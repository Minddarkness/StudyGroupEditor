namespace StudyGroupEditor.Models.DatabaseModels;

public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }

    public Course()
    {
        Groups = new List<Group>();
    }
}