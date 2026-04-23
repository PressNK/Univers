using Univers.Application.Models;
using Univers.Domain.ServicesExternes;

namespace Univers.Application.UseCases.Implementations;
public class ObtenirFilmsAVenir : IObtenirFilmsAVenir
{
    public readonly IFilmsVenirClient _filmsVenirClient;

    public ObtenirFilmsAVenir(IFilmsVenirClient filmsVenirClient)
    {
        _filmsVenirClient = filmsVenirClient;
    }

    public async Task<List<FilmAVenirModel>> Execute() 
    {
        var films = await _filmsVenirClient.ObtenirFilmsVenir();
        return films.ConvertAll(film => new FilmAVenirModel(film.Titre, film.DateSortie, film.Duree));
    }
}