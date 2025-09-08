using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCounter(IUserService _userService) : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.blogCount = await _client.GetFromJsonAsync<int>("blogs/GetCount");
            ViewBag.courseCount = await _client.GetFromJsonAsync<int>("courses/GetCount");
            ViewBag.courseCategoryCount = await _client.GetFromJsonAsync<int>("courseCategories/GetCount");
            ViewBag.testimonialCount = await _client.GetFromJsonAsync<int>("testimonials/GetCount");
            return View();
        }
    }
}
