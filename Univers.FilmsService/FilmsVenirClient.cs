using Flurl;
using Flurl.Http;
using Univers.FilmsService.Models;
using Univers.Domain.Entities;
using Univers.Domain.ServicesExternes;

namespace Univers.FilmsService;
public class FilmsVenirClient :  IFilmsVenirClient
{
    private readonly UniversApiConfiguration _configuration;
    
    public FilmsVenirClient(UniversApiConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<List<Film>> ObtenirFilmsVenir()
    {
        var reponse = await _configuration.FilmURL.GetAsync();
        
        var films = await reponse.GetJsonAsync<List<FilmAVenirModel>>();
        return films.ConvertAll(film => film.VersFilm());
    }
    
    public async Task<Film> AjouterFilmVenir(Film film) 
    {
        CreerFilmModel model = new(film);

        var reponse = await _configuration.FilmURL.PostJsonAsync(model);
        
        FilmAVenirModel filmAVenir = await reponse.GetJsonAsync<FilmAVenirModel>();
        return filmAVenir.VersFilm();
    }
}