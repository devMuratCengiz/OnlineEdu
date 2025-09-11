using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController(IGenericService<CourseVideo> _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _service.TGetList();
            var result = _mapper.Map<List<ResultCourseVideoDto>>(values);
            return Ok(result);
        }

        [HttpGet("GetCourseVideosByCourseId/{id}")]
        public IActionResult GetCourseVideosByCourseId(int id)
        {
            var values = _service.TGetFilteredList(x=>x.CourseId == id);
            var result = _mapper.Map<List<ResultCourseVideoDto>>(values);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            var result = _mapper.Map<ResultCourseVideoDto>(value);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseVideoDto createCourseVideoDto)
        {
            var newValue = _mapper.Map<CourseVideo>(createCourseVideoDto);
            _service.TCreate(newValue);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseVideoDto updateCourseVideoDto)
        {
            var newValue = _mapper.Map<CourseVideo>(updateCourseVideoDto);
            _service.TUpdate(newValue);
            return Ok("Updated");
        }
    }
}
