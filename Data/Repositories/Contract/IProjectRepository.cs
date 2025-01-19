using Entities;

namespace Data.Repositories.Contract;

public interface IProjectRepository : IRepository<Project>
{
    List<Project> GetAllProjects();
}