using Data.Repositories.Contract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository : Repository<User> , IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public List<User> GetAllUsers()
    {
      return _context.Users.ToList();
    }
}