using Data;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementApp.Pages.Report;

public class Kanban : PageModel
{
    private readonly ApplicationDbContext _context;

    public Kanban(ApplicationDbContext context)
    {
        _context = context;
    }

    // Dictionary to hold tasks grouped by status
    public Dictionary<Status, List<TaskBase>> TasksByStatus { get; set; }

    public void OnGet()
    {
        var tasks = _context.TaskBases
            .Include(t => t.AssignedUser)
            .ToList();
        
        
        TasksByStatus = tasks.GroupBy(t => t.Status)
            .ToDictionary(g => g.Key, g => g
                .ToList());
    }
}