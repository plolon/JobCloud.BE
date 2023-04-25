using JobCloud.BE.Domain.Models;

namespace JobCloud.BE.Application
{
    public static class MockResponses
    {
        public static async Task<IEnumerable<Offer>> GetMockedOffers()
        {
            return new List<Offer>()
            {
                new Offer() {Id = 1, CompanyName = "CumArch", Link = "google.pl", 
                    TechStack =await StringToLanguages(new string[]{".net", "java", "sql" }), 
                    SalaryB2B = null, SalaryUop = new SalaryRange(3000, 5000)},
                new Offer() {Id = 1, CompanyName = "NetBubu", Link = "google.pl", 
                    TechStack =await StringToLanguages(new string[]{"javascript", "css", "html" }), 
                    SalaryB2B = new SalaryRange(10000, 15000), SalaryUop = new SalaryRange(9000, 13000)},
                new Offer() {Id = 1, CompanyName = "SomeBank", Link = "google.pl", 
                    TechStack =await StringToLanguages(new string[]{"scala", "sql", "python" }), 
                    SalaryB2B = new SalaryRange(24000, 30000), SalaryUop = new SalaryRange(21000, 25000)},
            };
        }
        private static async Task<ICollection<Language>> StringToLanguages(string[] languages)
        {
            int i = 1;
            var response = new List<Language>();
            languages.ToList().ForEach(language =>
                response.Add(new Language() { Id = i++, Name = language }));
            return response;
        }
    }
}