using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper, IBlogService _service) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _service.TGetBlogsWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.TGetBlogWithCategory(id);
            var mappedValue = _mapper.Map<ResultBlogDto>(value);
            return Ok(mappedValue);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.TDelete(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = _mapper.Map<Blog>(createBlogDto);
            _service.TCreate(newValue);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var newValue = _mapper.Map<Blog>(updateBlogDto);
            _service.TUpdate(newValue);
            return Ok("Updated");
        }

        [HttpGet("GetBlogsByWriterId/{id}")]
        public IActionResult GetBlogsByWriterId(int id)
        {
            var values = _service.TGetBlogsWithCategoriesByWriterId(id);
            var mappedValues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("GetCount")]
        public IActionResult GetCount()
        {
            var count = _service.TCount();
            return Ok(count);
        }
    }
}
