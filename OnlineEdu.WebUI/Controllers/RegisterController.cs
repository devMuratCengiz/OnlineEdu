﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DataAccess.Migrations;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController() : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result = await _client.PostAsJsonAsync("Users/register", userRegisterDto);
            if (ModelState.IsValid)
            {
                return View(userRegisterDto);
            }
            if (!result.IsSuccessStatusCode )
            {
                var errors = await result.Content.ReadFromJsonAsync<List<RegisterResponseDto>>();
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(userRegisterDto);
            }
            return RedirectToAction("SignIn","Login");
        }
    }
}
