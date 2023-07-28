using Microsoft.AspNetCore.Mvc;
using StudyGroupEditor.Models.DatabaseModels;
using StudyGroupEditor.Models.ViewModels;

namespace StudyGroupEditor.Controllers;

public class AddGroupController : Controller
{
    private readonly UniversityContext _universityContext;
    
    public AddGroupController(UniversityContext universityContext)
    {
        _universityContext = universityContext;
    }
    
    public IActionResult Index()
    {
        return View(new CreatePageModel(_universityContext.Teachers));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGroup(Group group, Employee employee)
    {
        _universityContext.Groups.Add(group);
        await _universityContext.SaveChangesAsync();
        return RedirectToAction("Index", "EditGroup", group);
    }
}