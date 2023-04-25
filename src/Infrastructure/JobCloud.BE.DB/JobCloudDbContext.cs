using JobCloud.BE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCloud.BE.DB
{
    public class JobCloudDbContext : DbContext
    {
        DbSet<Offer> Offers { get; set; }
        DbSet<Language> Languages { get; set; }
    }
}
