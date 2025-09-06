using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TeacherSocialsDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetSocialByTeacherId/{id}")]
        public IActionResult GetSocialByTeacherId(int id)
        {
            var values = _service.TGetFilteredList(x=>x.TeacherId == id);
            var result = _mapper.Map<List<ResultTeacherSocialDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            var result = _mapper.Map<ResultTeacherSocialDto>(value);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var newValue = _mapper.Map<TeacherSocial>(createTeacherSocialDto);
            _service.TCreate(newValue);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var newValue = _mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            _service.TUpdate(newValue);
            return Ok("Updated");
        }
    }
}
