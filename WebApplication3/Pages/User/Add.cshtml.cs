using Data.Repositories.Contract;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementApp.Pages.User;

public class Add : PageModel
{
    private readonly IUserRepository _userRepository;

    public Add(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [BindProperty] public AddUserViewModel? UserVm { get;  set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (UserVm != null)
        {
            var newUser = new Entities.User
            {
                Name = UserVm.Name,
                Email = UserVm.Email,
                Role = UserVm.Role,
            };

            _userRepository.Add(newUser);
        }

        return RedirectToPage("/User/Show");
    }
}