using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;

namespace Com.Capgemini.Web.Api.Extensions
{
    public static class GlobalHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        object json;
                        if (env.IsDevelopment())
                        {
                            json = new
                            {
                                context.Response.StatusCode,
                                Detailed = exceptionHandlerFeature.Error
                            };
                        }
                        else
                        {
                            json = new
                            {
                                context.Response.StatusCode,
                                Message = "Ops... Ocorreu um erro, tente novamente.",
                            };
                        }
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
                    }
                });
            });

            return app;
        }
    }
}
