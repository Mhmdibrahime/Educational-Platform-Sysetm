namespace EducationalPlatform1._0.Models.Entities
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public string Image { get; set; }
        public List<Payment> Payments { get; set; }=new List<Payment>();
        public List<Grade> Grades { get; set; } =new List<Grade>();
        public List<StudentQuiz> studentQuizzes { get; set; }= new List<StudentQuiz>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
        public ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    }
}
