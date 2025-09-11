using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.CourseDtos
{
    public class ResultCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CourseCategoryId { get; set; }
        public ResultCourseCategoryDto CourseCategory { get; set; }
    }
}
