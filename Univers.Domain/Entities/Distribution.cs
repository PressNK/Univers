namespace Univers.Domain.Entities;

public class Distribution
{
    public int PersonnageId { get; set; }
    public int FilmId { get; set; }
    public string Acteur { get; set; } = null!;
    public Personnage Personnage { get; set; } = null!;
    public Film Film { get; set; } = null!;
}