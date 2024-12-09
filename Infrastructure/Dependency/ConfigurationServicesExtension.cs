using Application.Handler;
using Domain.Configuration;
using Domain.Handler;
using Domain.Service;
using Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependency;

public static class ConfigurationServicesExtension
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConfigurations(configuration);
        services.AddScoped<IGoogleTranslateService, GoogleTranslateService>();
        services.AddScoped<ITranslateHandler, TranslateHandler>();
    }

    private static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        AppConfig appConfig = new();
        configuration.GetSection("Configuration:Google").Bind(appConfig.GoogleConfig);
        configuration.Bind(appConfig);
        services.AddSingleton(appConfig);
    }
}