using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.DTOs.CourseRegisterDtos
{
    public class ResultCourseRegisterDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
