using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("coursecategories/" + id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _client.PostAsJsonAsync("coursecategories", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>("coursecategories/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("coursecategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
