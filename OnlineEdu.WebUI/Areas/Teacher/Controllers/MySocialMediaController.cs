using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.TeacherSocialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MySocialMediaController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("teacherSocials/GetSocialByTeacherId/" + user.Id );
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("teacherSocials/" + id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTeacherSocialDto.TeacherId = user.Id;
            await _client.PostAsJsonAsync("teacherSocials", createTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTeacherSocialDto>("teacherSocials/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            updateTeacherSocialDto.TeacherId = user.Id;
            await _client.PutAsJsonAsync("teacherSocials", updateTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
