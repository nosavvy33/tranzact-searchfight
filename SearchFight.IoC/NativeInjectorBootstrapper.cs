using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ApplicationDomain.Services;
using SearchFight.Infrastructure.EngineOptionsConfig;
using SearchFight.Infrastructure.Repository;

namespace SearchFight.IoC
{
    public static class NativeInjectorBootstrapper
    {
        /// <summary>
        /// Register dependencies to Native Net Core container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Search engines options
            services.Configure<GoogleConfig>(configuration.GetSection($"SearchEngines:GoogleConfig"));
            services.Configure<BingConfig>(configuration.GetSection($"SearchEngines:BingConfig"));
            services.Configure<YandexConfig>(configuration.GetSection($"SearchEngines:YandexConfig"));


            // Services
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IWinnerService, WinnerService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IResultPrinter, ResultPrinter>();

            // Repositories
            services.AddTransient<ISearchEngineRepository, GoogleSearchEngineRepository>();
            services.AddTransient<ISearchEngineRepository, BingSearchEngineRepository>();
            services.AddTransient<ISearchEngineRepository, YandexSearchEngineRepository>();

            return services;
        }
    }
}
