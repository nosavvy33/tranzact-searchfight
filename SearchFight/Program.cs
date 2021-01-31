using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchFight.IoC;
using System.IO;
using System.Threading.Tasks;

namespace SearchFight.ConsoleApplication
{
    class Program
    {
        /// <summary>
        /// Run app
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            var host = CreateHostBuilder(args, configuration).Build();
            var app = ActivatorUtilities.CreateInstance<SearchFight>(host.Services);

            await app.RunAsync();
        }

        /// <summary>
        /// Set up configuration builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static IConfiguration BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        /// <summary>
        /// Register dependencies to app
        /// </summary>
        /// <param name="args"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                    services.RegisterDependencies(configuration)
            );
    }
}
