using JobCloud.BE.DB.Repositories;
using JobCloud.BE.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobCloud.BE.DB.IoC
{
    public static class RegisterDbServices
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobCloudDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DummyConnectionString"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
