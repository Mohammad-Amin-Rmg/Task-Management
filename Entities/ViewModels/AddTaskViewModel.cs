using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.ViewModels;

public class AddTaskViewModel
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public Priority Priority { get; set; }
    [Required] public Status Status { get; set; }
    [Required] public string TaskType { get; set; }
    public DateTime? Estimate { get; set; }
    public BugSeverity? Severity { get; set; }
    public int? ReviewerId { get; set; }
}