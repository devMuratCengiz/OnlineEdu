using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Helpers;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task CategoryDropdown()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            ViewBag.categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
        public async Task<IActionResult>Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync("blogs/" + id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Create()
        {
            await CategoryDropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            await _client.PostAsJsonAsync("blogs",createBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            await CategoryDropdown();
            var value = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            await _client.PutAsJsonAsync("blogs",updateBlogDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
