using JobCloud.BE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace JobCloud.BE.DB
{
    public class JobCloudDbContext : DbContext
    {
        public JobCloudDbContext(DbContextOptions<JobCloudDbContext> options) : base(options)
        {
        }
        DbSet<Offer> Offers { get; set; }
        DbSet<Technology> Technologies { get; set; }
    }
}
