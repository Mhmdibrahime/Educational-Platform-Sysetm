namespace EducationalPlatform1._0.Models.Entities
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string feedBack { get; set; }
        public string Rate { get; set; }
        public Student student { get; set; }
        public string StudentId { get; set; }
    }
}
