using FluentAssertions;
using Univers.Application.Dtos;
using Univers.Application.UseCases;
using Univers.Domain.Entities;
using Univers.Generateurs.Domain;

namespace Univers.IntegrationTests.UseCases;
public class FilmTests
{
    private readonly IInsererFilm _insererFilm;
    private readonly IObtenirFilm _obtenirFilm;
    private readonly UtilitaireBd _utilitaireBD;

    public FilmTests(IInsererFilm insererFilm, IObtenirFilm obtenirFilm, UtilitaireBd utilitaireBD)
    {
        _insererFilm = insererFilm;
        _obtenirFilm = obtenirFilm;
        _utilitaireBD = utilitaireBD;

        _utilitaireBD.Initialiser();
    }

    [Fact]
    public async Task SachantQue_NouveauFilm_Pour_InsererFilm_Alors_LeFilmEstCree() 
    {
        Film film = new FilmGenerateur().Generer();

        int filmId = await _insererFilm.Execute(new Application.Dtos.InsererFilmDto() 
        {
            FilmId = null,
            DateSortie = film.DateSortie,
            Duree = film.Duree,
            Etoile = film.Etoile,
            Titre = film.Titre,
        });

        Film filmCree = _obtenirFilm.Execute(filmId);

        filmCree.Should().BeEquivalentTo(filmCree,
            options => options.Excluding(x => x.DistributionListe)
                .Excluding(x => x.FilmId));
    }

    [Fact]
    public async Task SachantQue_FilmExistant_Pour_InsererFilm_Alors_LeFilmEstModifie()
    {
        Film film = new FilmGenerateur().Generer();

        InsererFilmDto insererFilmDto = new()
        {
            FilmId = film.FilmId,
            DateSortie = film.DateSortie,
            Duree = 30,
            Etoile = 0,
            Titre = "Un nouveau titre",
        };
        int filmId = await _insererFilm.Execute(insererFilmDto);

        Film filmModifie = _obtenirFilm.Execute(filmId);

        filmModifie.Should().BeEquivalentTo(insererFilmDto);
    }
}