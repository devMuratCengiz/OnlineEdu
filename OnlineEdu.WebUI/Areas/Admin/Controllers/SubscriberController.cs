using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("subscribers");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("subscribers/" + id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriberDto createSubscriberDto)
        {
            await _client.PostAsJsonAsync("subscribers", createSubscriberDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
