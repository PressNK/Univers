using FluentValidation;
using Univers.Application.Dtos;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;
using Univers.Domain.ServicesExternes;

namespace Univers.Application.UseCases.Implementations;
public class InsererFilm : IInsererFilm
{
    private readonly IFilmRepository _filmRepository;
    private readonly IValidator<InsererFilmDto> _validateurFilm;
    private readonly IFilmsVenirClient _filmsVenirClient;

    public InsererFilm(IFilmRepository filmRepository, IValidator<InsererFilmDto> validateurFilm, IFilmsVenirClient filmsVenirClient)
    {
        _filmRepository = filmRepository;
        _validateurFilm = validateurFilm;
        _filmsVenirClient = filmsVenirClient;
    }

    public async Task<int> Execute(InsererFilmDto filmDto)
    {
        _validateurFilm.ValidateAndThrow(filmDto);

        if (filmDto.FilmId.HasValue)
        {
            Film filmAModifier = _filmRepository.Obtenir(filmDto.FilmId.Value);
            filmAModifier.Duree = filmDto.Duree;
            filmAModifier.DateSortie = filmDto.DateSortie;
            filmAModifier.Etoile = filmDto.Etoile;
            filmAModifier.Titre = filmDto.Titre;

            _filmRepository.Enregistrer();
            return filmAModifier.FilmId;
        }
        else
        {
            Film film = new()
            {
                Duree = filmDto.Duree,
                DateSortie = filmDto.DateSortie,
                Etoile = filmDto.Etoile,
                Titre = filmDto.Titre
            };

            _filmRepository.Ajouter(film, enregistrer: true);

            if(film.DateSortie > DateOnly.FromDateTime(DateTime.Now)) 
            {
                await _filmsVenirClient.AjouterFilmVenir(film);
            }

            return film.FilmId;
        }
    }
}