using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyGroupEditor.Models.DatabaseModels;
using StudyGroupEditor.Models.ViewModels;

namespace StudyGroupEditor.Controllers;

public class AddStudentController : Controller
{
    private readonly UniversityContext _universityContext;

    public AddStudentController(UniversityContext universityContext)
    {
        _universityContext = universityContext;
    }
    
    public async Task<IActionResult> Index(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var groups = 
            await _universityContext.Groups
                .Include(g => g.Teacher)
                .ThenInclude(t => t.Organizations)
                .ThenInclude(org => org.Employees)
                .Include(g => g.Employees)
                .ThenInclude(e => e.Organization)
                .ToListAsync();
        
        var group = groups.FirstOrDefault(g => g.GroupId == id.Value);
        
        if (group == null)
        {
            return NotFound();
        }
        
        return View(new AddStudentPageModel(group));
    }
    
    public async Task<IActionResult> GetEmployees(int id)
    {
        var organizations =
            await _universityContext.Organizations
                .Include(org => org.Employees)
                .ToListAsync();;
        
        var organization = organizations.FirstOrDefault(org => org.OrganizationId == id);
        
        if (organization == null)
        {
            return NotFound();
        }
        
        return PartialView(organization.Employees.ToList());
    }
    

    [HttpPost]
    public async Task<IActionResult> AddStudent(Employee employee)
    {
        _universityContext.Employees.Add(employee);
        await _universityContext.SaveChangesAsync();
        return RedirectToAction("Index", "EditGroup", employee);
    }
}