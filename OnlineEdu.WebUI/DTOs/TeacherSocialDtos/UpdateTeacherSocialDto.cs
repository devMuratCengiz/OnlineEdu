namespace OnlineEdu.WebUI.DTOs.TeacherSocialDtos
{
    public class UpdateTeacherSocialDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int TeacherId { get; set; }
    }
}
