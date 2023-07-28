using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyGroupEditor.Models.DatabaseModels;
using StudyGroupEditor.Models.ViewModels;

namespace StudyGroupEditor.Controllers;

public class HomeController : Controller
{
    private readonly UniversityContext _universityContext;
    
    public HomeController(UniversityContext universityContext)
    {
        _universityContext = universityContext;
    }
    
    public async Task<IActionResult> Index()
    {
        var groups = 
            await _universityContext.Groups
                .Include(g => g.Teacher)
                .Include(g => g.Employees)
                .ToListAsync();
        return View(groups);
    }

    // public IActionResult AddGroup()
    // {
    //     return RedirectToAction("Index", "AddGroup");
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // public IActionResult EditGroup(Group group)
    // {
    //     return RedirectToAction("Index", "EditGroup", group);
    // }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var groups = 
            await _universityContext.Groups
                .Include(g => g.Teacher)
                .Include(g => g.Employees)
                .ToListAsync();
        
        var group = groups.FirstOrDefault(g => g.GroupId == id.Value);
        
        if (group == null)
        {
            return NotFound();
        }
        
        return RedirectToAction("Index", "EditGroup", group);
    }
}