using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyGroupEditor.Models.DatabaseModels;
using StudyGroupEditor.Models.ViewModels;

namespace StudyGroupEditor.Controllers;

public class EditGroupController : Controller
{
    private readonly UniversityContext _universityContext;
    
    public EditGroupController(UniversityContext universityContext)
    {
        _universityContext = universityContext;
    }
    
    public IActionResult Index(Group group)
    {
        //return View(new EditGroupModel(group));
        return View(group);
    }

    [HttpPost]
    public ActionResult EditGroupName(Group group)
    {
        _universityContext.Entry(group).State = EntityState.Modified;
        _universityContext.SaveChanges();
        return RedirectToAction(nameof(Index), group);
    }
    
    // public IActionResult EditGroupName()
    // {
    //     throw new NotImplementedException();
    // }
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> EditGroupName(int id, [Bind("GroupID,Name")]Group group)
    // {
    //     string newName = group.Name;
    //     
    //     if (id != group.GroupId)
    //     {
    //         return NotFound();
    //     }
    //
    //
    //     group = await _universityContext.Groups.FindAsync(id);
    //     if (group == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     group.Name = newName;
    //     
    //     // if (ModelState.IsValid)
    //     // {
    //         try
    //         {
    //             _universityContext.Update(group);
    //             await _universityContext.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!GroupExists(group.GroupId))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }
    //         return RedirectToAction(nameof(Index), group);
    //     //}
    //     return RedirectToAction(nameof(Index), group);
    // }

    private bool GroupExists(int groupGroupId)
    {
        return true;
    }
}