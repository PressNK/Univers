using Univers.Domain.Entities;

namespace Univers.Application.UseCases;
public interface IObtenirFilm
{
    Film Execute(int filmId);
}