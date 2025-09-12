using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TeacherSocialDtos;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MySocialMediaController(HttpClient client, ITokenService tokenService)
        {
            _client = client;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("teacherSocials/GetSocialByTeacherId/" + userId );
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
            var userId = _tokenService.GetUserId;
            createTeacherSocialDto.TeacherId = userId;
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
            var userId = _tokenService.GetUserId;
            updateTeacherSocialDto.TeacherId = userId;
            await _client.PutAsJsonAsync("teacherSocials", updateTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
