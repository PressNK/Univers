using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Application.Extensions;
using Univers.Data.Context;
using Univers.Data.Extensions;
using Univers.Domain.Entities;
using Univers.Domain.ServicesExternes;
using Univers.FilmsService;
using Univers.TravailPeriodique.Scenarios;

Console.WriteLine("Console de traitement périodique du projet Univers");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer();
        
        services.EnregistrerUseCases();
        services.EnregistrerValidations();
        services.EnregistrerRepositories();

        services.AddDbContext<UniversContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

        UniversApiConfiguration config = new();
        context.Configuration.Bind("UniversApi", config);
        services.AddSingleton(config);
        
        // UniversApi Client
        services.AddTransient<IFilmsVenirClient, FilmsVenirClient>();
        
    })
    .Build();

host.Start();

RecurringJob.AddOrUpdate(
    "filmAVenir",
    () => Console.WriteLine($"Obtenir les films à venir - {DateTime.Now}"),
    "*/1 * * * *");

RecurringJob.AddOrUpdate<AfficherFilmAVenirConsole>(
    "filmAVenir2",
    (job) => job.ListerFilmsAVenir(),
    Cron.Daily(3));

//Pour lancer la job tout de suite pour tester
RecurringJob.TriggerJob("filmAVenir2");

host.Run();