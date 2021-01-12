using AutoMapper;
using Com.Capgemini.Business.Objetos;
using Com.Capgemini.Domain.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Capgemini.Web.Api.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoExcel, Produto>()
                .ReverseMap();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
