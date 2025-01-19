using Entities;

namespace Data.Repositories.Contract;

public interface IUserRepository : IRepository<User>
{
    List<User> GetAllUsers();
}