namespace JobCloud.BE.Domain.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Link { get; set; }
        public ICollection<Language> TechStack { get; set; }
        public SalaryRange? SalaryUop { get; set; }
        public SalaryRange? SalaryB2B { get; set; }
    }
}
