using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;
using System.Security.Claims;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignsController(IUserService _service, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager, IHttpContextAccessor _contextAccessor) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var values = await _service.GetAllUsersAsync();
            var userList = (from user in values
                            select new UserListDto
                            {
                                Id = user.Id,
                                NameSurname = user.FirstName + " " + user.LastName,
                                UserName = user.UserName,
                                Roles = _userManager.GetRolesAsync(user).Result.ToList()
                            }).ToList();
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserForRoleAssign(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
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

            return Ok(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleDtos)
        {
            var userId = int.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await _service.GetUserByIdAsync(userId);
            foreach (var item in assignRoleDtos)
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

            return Ok("Completed");
        }
    }
}
