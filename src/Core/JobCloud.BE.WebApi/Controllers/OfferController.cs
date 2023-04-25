using JobCloud.BE.Application;
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
            return await MockResponses.GetMockedOffers();
        }
    }
}
