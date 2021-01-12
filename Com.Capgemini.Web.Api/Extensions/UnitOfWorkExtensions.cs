using Com.Capgemini.Domain.Interfaces.UnitOfWork;
using Com.Capgemini.Infra.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Capgemini.Web.Api.Extensions
{
    public static class UnitOfWorkExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
