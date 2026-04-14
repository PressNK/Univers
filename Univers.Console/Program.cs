using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Univers.Application.Dtos;
using Univers.Application.Dtos.Validateurs;
using Univers.Application.Extensions;
using Univers.Application.UseCases;
using Univers.Application.UseCases.Implementations;
using Univers.Console.Extensions;
using Univers.Console.Scenarios;
using Univers.Data.Context;
using Univers.Data.Extensions;
using Univers.Data.Repositories;
using Univers.Domain.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        //Repository
        services.EnregistrerRepositories();

        //Scénarios d'utilisation
        services.AddTransient<AjouterDonnees>();
        services.AddTransient<MiseAJourDonnees>();
        services.AddTransient<SuppressionDonnees>();
        services.AddTransient<ChoisirScenario>();
        services.AddTransient<AjouterPersonnageConsole>();
        services.AddTransient<SupprimerPersonnageConsole>();
        services.AddTransient<VenteFranchiseConsole>();


        //UseCase
        services.EnregistrerUseCases();
        // Autres dépendances 
        services.EnregistrerValidations();

        services.AddDbContext<UniversContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
        
        // .resx
        services.AddLocalization();
    })
    .Build();


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
        case 5:
            var ajouterPersonnageConsole = host.Services.GetRequiredService<AjouterPersonnageConsole>();
            ajouterPersonnageConsole.AjouterUnPersonnage();
            break;
        case 6:
            var supprimerPersonnageConsole = host.Services.GetRequiredService<SupprimerPersonnageConsole>();
            supprimerPersonnageConsole.SupprimerUnPersonnage();
            break;
        case 7:
            var venteFranchiseConsole = host.Services.GetRequiredService<VenteFranchiseConsole>();
            venteFranchiseConsole.VendreUneFranchise();
            break;
        default:
            Console.WriteLine("Scénario non reconnu, veuillez réessayer.");
            break;
    }
} while (optionChoisie != 0);