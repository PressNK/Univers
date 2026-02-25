using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Console.Extensions;
using Univers.Data.Context;
using Univers.Data.Repositories;
using Univers.Domain.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<IDistributionRepository, DistributionRepository>();
        services.AddTransient<IFilmRepository, FilmRepository>();
        services.AddTransient<IFranchiseRepository, FranchiseRepository>();
        services.AddTransient<IPersonnageRepository, PersonnageRepository>();
        
        services.AddDbContext<UniversContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
    })
    .Build();

IFranchiseRepository franchiseRepository = host.Services.GetRequiredService<IFranchiseRepository>(); 
franchiseRepository.ObtenirListe().AfficherConsole(); 