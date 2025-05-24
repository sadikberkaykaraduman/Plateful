using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restorant.WebUI.Dtos.IdentityDtos;
using SignalR.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Restorant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Setting")]
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto
            {
                Name = value.Name,
                Surname = value.Surname,
                Mail = value.Email,
                Username = value.UserName
            };
            return View(userEditDto);
        }

        [HttpPost]
        [Route("Index")]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            return View(userEditDto);
        }
    }
}
