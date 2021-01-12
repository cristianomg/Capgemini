using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Capgemini.Web.Api.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IImportacaoRepository, ImportacaoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
