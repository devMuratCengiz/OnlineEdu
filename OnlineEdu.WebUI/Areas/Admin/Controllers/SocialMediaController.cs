using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("socialmedias/" + id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            await _client.PostAsJsonAsync("socialmedias", createSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSocialMediaDto>("socialmedias/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _client.PutAsJsonAsync("socialmedias", updateSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
