namespace Univers.Application.Models;

public class FilmAVenirModel
{
    public FilmAVenirModel(string titre, DateOnly dateSortie, int duree)
    {
        Titre = titre;
        DateSortie = dateSortie;
        Duree = duree;
    }

    public string Titre { get; set; }
    public DateOnly DateSortie { get; set; }
    public int Duree { get; set; }
}