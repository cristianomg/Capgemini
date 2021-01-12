using Com.Capgemini.Business.Services;
using Com.Capgemini.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Capgemini.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IImportacaoService, ImportacaoService>();
            return services;
        }
    }
}
