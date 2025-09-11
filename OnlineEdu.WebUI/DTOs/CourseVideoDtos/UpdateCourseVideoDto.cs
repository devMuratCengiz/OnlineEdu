namespace OnlineEdu.WebUI.DTOs.CourseVideoDtos
{
    public class UpdateCourseVideoDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string VideoUrl { get; set; }
        public int VideoNumber { get; set; }
    }
}
