using JobCloud.BE.Application.Repositories;
using JobCloud.BE.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JobCloud.BE.Application.IoC
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
