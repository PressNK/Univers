using FluentValidation;
using Univers.Application.Dtos;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;

public class InsererFilm
{
    private readonly IFilmRepository _filmRepository;
    private readonly IValidator<InsererFilmDto> _validateurFilm;

    public InsererFilm(IFilmRepository filmRepository,
        IValidator<InsererFilmDto> validateurFilm)
    {
        _filmRepository = filmRepository;
        _validateurFilm = validateurFilm;
    }

    public int Execute(InsererFilmDto filmDto)
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
            return film.FilmId;
        }
    }
}