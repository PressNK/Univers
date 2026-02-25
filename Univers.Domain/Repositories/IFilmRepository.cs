using Univers.Domain.Entities;

namespace Univers.Domain.Repositories;

public interface IFilmRepository : IBaseRepo<Film>
{
    Film Obtenir(int filmId);
    Film ObtenirParTitre(string titre);
}