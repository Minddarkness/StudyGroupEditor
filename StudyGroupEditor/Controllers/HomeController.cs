using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyGroupEditor.Models;
using StudyGroupEditor.Models.DatabaseModels;
using StudyGroupEditor.Models.ViewModels;

namespace StudyGroupEditor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UniversityContext _universityContext;
    
    public HomeController(ILogger<HomeController> logger, UniversityContext universityContext)
    {
        _logger = logger;
        _universityContext = universityContext;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}