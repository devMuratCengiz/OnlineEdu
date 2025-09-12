using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCounter : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCounter(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
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
