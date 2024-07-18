namespace EducationalPlatform1._0.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
        public string CVV { get; set;}
        public Student? Student { get; set; }
        public string? studentId { get; set; }
        
    }
}
