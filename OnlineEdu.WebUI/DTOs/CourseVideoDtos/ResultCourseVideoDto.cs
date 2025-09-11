﻿using OnlineEdu.WebUI.DTOs.CourseDtos;

namespace OnlineEdu.WebUI.DTOs.CourseVideoDtos
{
    public class ResultCourseVideoDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
        public string VideoUrl { get; set; }
        public int VideoNumber { get; set; }
    }
}
