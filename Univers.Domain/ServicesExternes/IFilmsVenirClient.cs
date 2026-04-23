using Univers.Domain.Entities;

namespace Univers.Domain.ServicesExternes;

public interface IFilmsVenirClient
{
    Task<List<Film>> ObtenirFilmsVenir();

    Task<Film> AjouterFilmVenir(Film film);
}