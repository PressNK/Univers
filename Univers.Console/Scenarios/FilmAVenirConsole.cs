using Univers.Application.Dtos;
using Univers.Application.Models;
using Univers.Application.UseCases;

namespace Univers.Console.Scenarios;
public class FilmAVenirConsole
{
    private readonly IObtenirFilmsAVenir _obtenirFilmsAVenir;
    private readonly IInsererFilm _insererFilm;

    public FilmAVenirConsole(IObtenirFilmsAVenir obtenirFilmsAVenir, IInsererFilm insererFilm)
    {
        _obtenirFilmsAVenir = obtenirFilmsAVenir;
        _insererFilm = insererFilm;
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

    public async Task AjouterUnFilm()
    {
        InsererFilmDto filmDto = new();

        do
        {
            System.Console.Write("Entrez le titre du film : ");
            filmDto.Titre = System.Console.ReadLine()?.Trim() ?? string.Empty;
        } while (string.IsNullOrEmpty(filmDto.Titre));


        filmDto.DateSortie = AideConsole.DemanderDate("Entrez la date de sortie du film (format AAAA-MM-JJ) : ");
        filmDto.Duree = AideConsole.DemanderEntier("Entrez la durée du film : ");

        await _insererFilm.Execute(filmDto);

        System.Console.WriteLine($"Ajout du film {filmDto.Titre} complété!");
    }
}