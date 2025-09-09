using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class TeacherController(IUserService _service) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var teachers = await _service.GetAllTeachers();
            return View(teachers);
        }
    }
}
