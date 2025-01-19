using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.ViewModels;

public class EditTaskViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public DateTime Deadline { get; set; } = DateTime.UtcNow;
}