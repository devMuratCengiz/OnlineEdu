using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.BlogDtos
{
    public class ResultBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }

        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDto BlogCategory { get; set; }

        public AppUser Writer { get; set; }
        public int WriterId { get; set; }
    }
}
