using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;
public class ObtenirFilm : IObtenirFilm
{
    private readonly IFilmRepository _filmRepository;

    public ObtenirFilm(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    public Film Execute(int filmId)
    {
        return _filmRepository.Obtenir(filmId);
    }
}