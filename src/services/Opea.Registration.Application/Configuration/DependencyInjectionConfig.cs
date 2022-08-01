using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Opea.Registration.Application.Services.Client;
using Opea.Registration.Application.Services.Client.Interface;
using Opea.Registration.Business.Domain.Client.Interface;
using Opea.Registration.Data.Context;
using Opea.Registration.Data.Repository;
using Opea.Registration.Data.Repository.Client;
using Opea.WebAPI.Core.Domain.Notifications;

namespace Opea.Registration.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Config
            services.AddScoped<ServicesContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotifier, Notifier>();


            //Service
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICompanySizeService, CompanySizeService>();

            //Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompanySizeRepository, CompanySizeRepository>();
        }
    }
}