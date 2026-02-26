using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Console.Extensions;
using Univers.Console.Scenarios;
using Univers.Data.Context;
using Univers.Data.Repositories;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        //Repository
        services.AddTransient<IDistributionRepository, DistributionRepository>();
        services.AddTransient<IFilmRepository, FilmRepository>();
        services.AddTransient<IFranchiseRepository, FranchiseRepository>();
        services.AddTransient<IPersonnageRepository, PersonnageRepository>();
        
        //Scénarios d'utilisation
        services.AddTransient<AjouterDonnees>();
        services.AddTransient<MiseAJourDonnees>();
        services.AddTransient<SuppressionDonnees>();
        services.AddTransient<ChoisirScenario>();
        
        services.AddDbContext<UniversContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
    })
    .Build();


List<Personnage> personnages;

using (UniversContext db = new UniversContext())
{
    personnages =
        (from lqPersonnage in db.Personnages
                .Include(p => p.Franchise) //Indique que la propriété Franchise aura une valeur
                .Include(p => p.DistributionListe) //Indique que la propriété Distribution ne sera pas vide
            select
                lqPersonnage).ToList();
}
//Fin du contexte

foreach (Personnage personnage in personnages)
{
    Console.WriteLine($"Nom personnage : {personnage.Nom}");
    Console.WriteLine($"Nom Franchise : {personnage.Franchise.Nom}");

    foreach (Distribution distribution in personnage.DistributionListe)
    {
        Console.WriteLine($"Acteur : {distribution.Acteur}");
    }
}

//Accueillir l'utilisateur avec les options
//...
int optionChoisie;
do
{
    optionChoisie = host.Services.GetRequiredService<ChoisirScenario>().RecupererScenario();
    switch (optionChoisie)
    {
        case 0:
            Console.WriteLine("Aurevoir!");
            break;
        case 1:
            Console.WriteLine("Compléter l'ajout des données de l'univers!");
            host.Services.GetRequiredService<AjouterDonnees>().CompleterUnivers();
            break;
        case 2:
            Console.WriteLine("Changement des personnes de franchise 1");
            host.Services.GetRequiredService<MiseAJourDonnees>()
                .ChangerPersonnages(1);
            break;
        case 3:
            Console.WriteLine("La franchise Teenage mutant ninja turtles n'est plus nécessaire :D");
            host.Services.GetRequiredService<SuppressionDonnees>()
                .EnleverFranchise("Teenage mutant ninja turtles");
            break;
        case 4:
            IFranchiseRepository franchiseRepository = host.Services.GetRequiredService<IFranchiseRepository>();
            franchiseRepository.ObtenirListe().AfficherConsole();
            break;
        default:
            Console.WriteLine("Scénario non reconnu, veuillez réessayer.");
            break;
    }
} while (optionChoisie != 0);
