namespace Univers.Domain.Entities;
public class Film
{
    public int FilmId { get; set; }
    public String Titre { get; set; } = null!;
    public DateOnly DateSortie { get; set; }
    public byte Etoile { get; set; }
    public int Duree { get; set; }
    public ICollection<Distribution> DistributionListe { get; set; } = new List<Distribution>();  
}