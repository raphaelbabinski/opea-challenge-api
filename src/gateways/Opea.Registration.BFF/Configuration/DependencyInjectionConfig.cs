using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Opea.Registration.BFF.Services.Client;
using Opea.Registration.BFF.Services.Client.Interface;
using Opea.WebAPI.Core.Domain.Notifications;
using Opea.WebAPI.Core.Extensions;
using Polly;
using System;

namespace Opea.Registration.BFF.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IMemoryCache, MemoryCache>();
            
            services.AddHttpClient<IClientService, ClientService>()
                //.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                //.AllowSelfSignedCertificate()
                .AddPolicyHandler(PollyExtensions.WaitTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(1, TimeSpan.FromSeconds(10)));

            services.AddHttpClient<ICompanySizeService, CompanySizeService>()
                //.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                //.AllowSelfSignedCertificate()
                .AddPolicyHandler(PollyExtensions.WaitTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(1, TimeSpan.FromSeconds(10)));
        }
    }
}