﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }

        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
    }
}
