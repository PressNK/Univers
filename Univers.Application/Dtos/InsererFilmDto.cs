namespace Univers.Application.Dtos;

public class InsererFilmDto
{
    public int? FilmId { get; set; }
    public string Titre { get; set; } = null!;
    public DateOnly DateSortie { get; set; }
    public byte Etoile { get; set; }
    public int Duree { get; set; }
}