using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _service.TGetAllCoursesWithCategories();
            var result = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            var result = _mapper.Map<ResultCourseDto>(value);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            _service.TCreate(newValue);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var newValue = _mapper.Map<Course>(updateCourseDto);
            _service.TUpdate(newValue);
            return Ok("Updated");
        }

        [HttpGet("GetActiveCourses")]
        public IActionResult GetActiveCourses()
        {
            var values = _service.TGetFilteredList(x => x.IsShown == true);
            var result = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(result);
        }

        [HttpGet("GetCoursesByTeacherId/{id}")]
        public async Task<IActionResult> GetCoursesByTeacherId(int id)
        {
            var values = _service.TGetCoursesByTeacherId(id);
            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(values);
        }

        [HttpGet("GetAllCoursesWithCategories")]
        public IActionResult GetAllCoursesWithCategories()
        {
            var values = _service.TGetAllCoursesWithCategories();
            return Ok(values);
        }

        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var count = _service.TCount();
            return Ok(count);
        }

        [HttpGet("GetCoursesByCategoryId/{id}")]
        public IActionResult GetCoursesByCategoryId(int id)
        {
            var values = _service.TGetAllCoursesWithCategories(x=>x.CourseCategoryId == id);
            var result = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(result);
        }
    }
}
