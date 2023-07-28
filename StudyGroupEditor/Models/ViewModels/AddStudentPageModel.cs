using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyGroupEditor.Models.DatabaseModels;

namespace StudyGroupEditor.Models.ViewModels;

public class AddStudentPageModel
{
    [BindProperty]
    public Group Group { get; set; }

    [BindProperty] 
    public Employee Employee { get; set; } = new Employee();
    
    public SelectList OrganizationsSelectList { get; private set; } 
    public SelectList EmployeesSelectList { get; private set; }

    private List<Organization> Organizations;
    
    public AddStudentPageModel(Group group)
    {
        Group = group;
        Organizations = group.Teacher.Organizations.ToList();
        var firstOrganization = Organizations.FirstOrDefault();
        OrganizationsSelectList = new SelectList(Organizations, "OrganizationId", "Name", firstOrganization);

        var selectedOrganization = (Organization)OrganizationsSelectList.SelectedValue;
        
        EmployeesSelectList = new SelectList(selectedOrganization.Employees, "EmployeeId", "Name");
    }
}