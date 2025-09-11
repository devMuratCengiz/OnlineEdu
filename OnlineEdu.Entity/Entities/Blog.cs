using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }

        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
        public virtual AppUser Writer { get; set; }
        public int? WriterId { get; set; }
    }
}
