using Univers.Application.Models;

namespace Univers.Application.UseCases;

public interface IObtenirFilmsAVenir
{
    Task<List<FilmAVenirModel>> Execute();
}