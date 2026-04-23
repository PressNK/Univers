using Univers.Domain.Entities;

namespace Univers.FilmsService.Models;
public class CreerFilmModel
{
    public CreerFilmModel(Film film)
        :this(film.Titre, film.DateSortie.ToDateTime(TimeOnly.MinValue), film.Titre, film.Duree)
    {
    }
    
    public CreerFilmModel(string nom, DateTime dateSortie, string franchise, int duree)
    {
        Nom = nom;
        DateSortie = dateSortie;
        Franchise = franchise;
        Duree = duree;
    }

    public string Nom { get; set; }

    public DateTime DateSortie { get; set; }

    public string Franchise { get; set; }

    public int Duree { get; set; }
}