using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Models;
using OnlineEdu.WebUI.Services.UserServices;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController(IUserService _service, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _service.GetAllUsersAsync();
            var userList = (from user in values
                            select new UserViewModel
                            {
                                Id = user.Id,
                                NameSurname = user.FirstName + " " + user.LastName,
                                UserName = user.UserName,
                                Roles = _userManager.GetRolesAsync(user).Result.ToList()
                            }).ToList();
            return View(userList);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            TempData["userId"] = user.Id;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto();
                assignRole.Id = role.Id;
                assignRole.Name = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            var userId = (int)TempData["userId"];
            var user = await _service.GetUserByIdAsync(userId);
            foreach(var item in assignRoleList)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
