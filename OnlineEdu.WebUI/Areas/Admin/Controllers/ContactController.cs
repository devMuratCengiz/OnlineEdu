using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("contacts/" + id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            await _client.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateContactDto>("contacts/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync("contacts", updateContactDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
