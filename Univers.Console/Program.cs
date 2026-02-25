using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Console.Extensions;
using Univers.Console.Scenarios;
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
        services.AddTransient<AjouterDonnees>();
        
        services.AddDbContext<UniversContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
    })
    .Build();


//Accueillir l'utilisateur avec les options
//...

int optionChoisie = -1;
Console.WriteLine("Veuillez entrer un chiffre");
do
{
    string? optionChoisieATraiter = Console.ReadLine();
    if (string.IsNullOrEmpty(optionChoisieATraiter) || !int.TryParse(optionChoisieATraiter, out optionChoisie))
    {
        Console.WriteLine("Veuillez entrer un chiffre");
    }

} while (optionChoisie < 0);

switch (optionChoisie)
{
    case 1:
        Console.WriteLine("Compléter l'ajout des données de l'univers!");
        host.Services.GetRequiredService<AjouterDonnees>().CompleterUnivers();
        break;
    case 2:
        break;
    case 3:
        break;
    case 4:
        break;
    default:
        break;
}