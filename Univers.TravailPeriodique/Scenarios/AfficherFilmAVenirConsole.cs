using Univers.Application.Models;
using Univers.Application.UseCases;

namespace Univers.TravailPeriodique.Scenarios;
public class AfficherFilmAVenirConsole
{
    private readonly IObtenirFilmsAVenir _obtenirFilmsAVenir;

    public AfficherFilmAVenirConsole(IObtenirFilmsAVenir obtenirFilmsAVenir)
    {
        _obtenirFilmsAVenir = obtenirFilmsAVenir;
    }

    public async Task ListerFilmsAVenir()
    {
        List<FilmAVenirModel> films = await _obtenirFilmsAVenir.Execute();

        System.Console.WriteLine("Voici les films à venir :");
        foreach (var film in films)
        {
            System.Console.WriteLine($"{film.DateSortie:d MMM yyyy} - {film.Titre}");
        }
    }
}