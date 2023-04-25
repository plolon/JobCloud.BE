using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace JobCloud.BE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<object>> GetByLanguage(int languageId)
        {
            return await GetMockedOffers();
        }

        // MOCK
        private async Task<IEnumerable<Offer>> GetMockedOffers()
        {
            return new List<Offer>()
            {
                new Offer("CumArch", new List<string>{".net", "java", "sql"}, "Intern", new EarningPrice(3000, 5000)),
                new Offer("NetBubu", new List<string>{"javascript", "css", "html"}, "Mid", new EarningPrice(9000, 13000)),
                new Offer("someBank", new List<string>{"scala", "sql", "python"}, "Senior", new EarningPrice(21000, 25000)),
            };
        }

        private record Offer(string CompanyName, List<string> TechStack, string Level, EarningPrice EarningPrice);

        private record EarningPrice(decimal MinValue, decimal MaxValue);
    }
}
