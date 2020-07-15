using Conta.Domain.Interfaces;
using Conta.Domain.Notificacoes;
using Conta.Domain.Services;
using Conta.Infrastructure.Context;
using Conta.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ILancamentoPorContaRepository, LancamentoPorContaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<ILancamentosPorContaService, LancamentosPorContaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
