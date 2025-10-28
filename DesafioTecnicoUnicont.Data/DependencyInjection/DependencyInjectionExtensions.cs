using DesafioTecnicoUnicont.Data.Repository;
using DesafioTecnicoUnicont.Data.Repository.Base;
using DesafioTecnicoUnicont.Domain.Interface.Repository;
using DesafioTecnicoUnicont.Domain.Interface.Repository.Base;
using DesafioTecnicoUnicont.Domain.Interface.Service;
using DesafioTecnicoUnicont.Domain.Interface.Service.Base;
using DesafioTecnicoUnicont.Domain.Service;
using DesafioTecnicoUnicont.Domain.Service.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Data.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adiciona as injeções de dependência para repositórios e serviços.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //registrando Bases
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            //registrando Services
            services.AddScoped<INotaFiscalService, NotaFiscalService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();


            //registrando repositórios
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
            return services;
        }
    }
}
