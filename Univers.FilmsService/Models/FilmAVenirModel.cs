using Univers.Domain.Entities;

namespace Univers.FilmsService.Models;
public class FilmAVenirModel
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public DateTime DateSortie { get; set; }

    public string Franchise { get; set; } = null!;

    public int Duree { get; set; }
    
    public Film VersFilm() 
    {
        return new Film() 
        {
            Titre = Nom,
            DateSortie = DateOnly.FromDateTime(DateSortie),
            Duree = Duree,
        };
    }
}