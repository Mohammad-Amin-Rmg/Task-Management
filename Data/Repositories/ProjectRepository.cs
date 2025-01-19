using Data.Repositories.Contract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(ApplicationDbContext context) : Repository<Project>(context), IProjectRepository
{
    private readonly ApplicationDbContext _context = context;

    public List<Project> GetAllProjects()
    {
        return _context
            .Projects
            .Include(x => x.Users!)
            .ToList();
    }
}