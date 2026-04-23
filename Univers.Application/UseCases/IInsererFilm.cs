using Univers.Application.Dtos;

namespace Univers.Application.UseCases;
public interface IInsererFilm
{
    Task<int> Execute(InsererFilmDto filmDto);
}