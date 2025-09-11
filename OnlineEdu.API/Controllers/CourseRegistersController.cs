using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(ICourseRegisterService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetMyCourses/{id}")]
        public IActionResult GetMyCourses(int id)
        
        {
            var values = _service.TGetAllWithCourseAndCategory(x => x.AppUserId == id);
            var mappedValue = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValue);
        }

        [HttpPost]
        public IActionResult RegisterToCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var newCourseRegister = _mapper.Map<CourseRegister>(createCourseRegisterDto);
            _service.TCreate(newCourseRegister);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            var updateModel = _mapper.Map<CourseRegister>(updateCourseRegisterDto);
            _service.TUpdate(updateModel);
            return Ok("Updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
    }
}
