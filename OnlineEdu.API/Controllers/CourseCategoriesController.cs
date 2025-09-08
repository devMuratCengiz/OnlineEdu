using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(IGenericService<CourseCategory> _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _service.TGetList();
            var result = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            var result = _mapper.Map<ResultCourseCategoryDto>(value);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _service.TCreate(newValue);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _service.TUpdate(newValue);
            return Ok("Updated");
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _service.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var count = _service.TCount();
            return Ok(count);
        }
    }
}
