using Univers.Data.Context;
using Univers.Domain.Entities;
using Univers.Domain.Repositories; 

namespace Univers.Data.Repositories;

public class FilmRepository : BaseRepo<Film>, IFilmRepository
{
    public FilmRepository(UniversContext dbContext)
        : base(dbContext)
    {
    }

    public Film Obtenir(int filmId)
    {
        Film film = (from lqFilm in _dbContext.Films
                     where lqFilm.FilmId == filmId
                     select lqFilm).First();
        return film;
    }

    public Film ObtenirParTitre(string titre)
    {
        Film film = (from lqFilm in _dbContext.Films
                     where lqFilm.Titre == titre
                     select lqFilm).First();
        return film;
    }
}