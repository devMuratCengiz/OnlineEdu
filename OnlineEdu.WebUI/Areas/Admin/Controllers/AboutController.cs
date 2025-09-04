using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.Helpers;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
           var response =  await _client.DeleteAsync("abouts/" + id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            var response = await _client.PostAsJsonAsync("abouts", createAboutDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateAboutDto>("abouts/"+id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("abouts", updateAboutDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
