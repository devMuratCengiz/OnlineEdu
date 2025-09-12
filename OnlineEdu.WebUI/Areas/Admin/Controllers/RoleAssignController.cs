using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController : Controller
    {
        private readonly HttpClient _client;
        private readonly IUserService _service;

        public RoleAssignController(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _service = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _service.GetAllUsersAsync();
           
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var values = await _service.GetUserForRoleAssign(id);

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {

            var result = await _client.PostAsJsonAsync("roleAssigns", assignRoleList);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(assignRoleList);
        }
    }
}
