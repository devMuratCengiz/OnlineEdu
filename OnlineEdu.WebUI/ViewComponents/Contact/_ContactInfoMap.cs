using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactInfoMap : ViewComponent
    {
        private readonly HttpClient _client;

        public _ContactInfoMap(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(value);
        }
    }
}
