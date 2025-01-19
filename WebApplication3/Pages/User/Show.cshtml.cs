using Data.Repositories.Contract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementApp.Pages.User;

public class Show : PageModel
{
    private readonly IUserRepository _userRepository;

    public Show(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<Entities.User> Users { get; set; }

    public void OnGet()
    {
        Users = _userRepository.GetAllUsers();
    }
}