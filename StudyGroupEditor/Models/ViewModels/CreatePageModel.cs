using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyGroupEditor.Models.DatabaseModels;

namespace StudyGroupEditor.Models.ViewModels;

public class CreatePageModel
{
    [BindProperty]
    public Group Group { get; set; } = new();

    public SelectList TeachersSelectList { get; } 
    
    public CreatePageModel(IEnumerable<Teacher> teachers)
    {
        TeachersSelectList = new SelectList(teachers, "TeacherId", "Name");
    }
}