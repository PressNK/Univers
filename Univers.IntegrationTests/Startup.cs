using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Application.Extensions;
using Univers.Data.Context;
using Univers.Data.Extensions;

namespace Univers.IntegrationTests;
public class Startup
{
    /// <summary>
    /// Méhthode qui permet d'enregistrer les services
    /// </summary>
    /// <param name="services">Collection de services</param>
    /// <param name="context">Context de l'application</param>
    public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services.EnregistrerRepositories();
        services.EnregistrerUseCases();
        services.EnregistrerValidations();
        
        services.AddScoped<UtilitaireBd>();

        services.AddDbContext<UniversContext>(
            options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddLocalization();
    }

    public void ConfigureHost(IHostBuilder hostBuilder) =>
        hostBuilder.ConfigureHostConfiguration(builder => {
            builder.AddJsonFile("appsettings.json");
        });
}