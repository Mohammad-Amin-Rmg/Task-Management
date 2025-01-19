using Data;
using Data.Repositories.Contract;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagementApp.Pages.Project;

public class Add : PageModel
{
    private readonly ApplicationDbContext _context;
    public List<SelectListItem> UsersList { get; set; }

    public Add(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public AddProjectViewModel ProjectVm { get; set; }


    public IActionResult OnGet()
    {
        UsersList = _context.Users.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name
        }).ToList();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var project = new Entities.Project()
        {
            Name = ProjectVm.Name,
            Description = ProjectVm.Description,
        };

        _context.Projects.Add(project);
        _context.SaveChanges();

        foreach (var userId in ProjectVm.Users)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Entry(user).Property<int?>("ProjectId").CurrentValue = project.Id;
                project.Users?.Add(user);
            }
        }

        _context.SaveChanges();


        return RedirectToPage("/Project/Show");
    }
}