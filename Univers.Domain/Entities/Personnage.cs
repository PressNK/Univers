namespace Univers.Domain.Entities;
public class Personnage
{
    public int PersonnageId { get; set; }
    public String Nom { get; set; } = null!;
    public String? IdentiteReelle { get; set; }
    public DateOnly DateNaissance { get; set; }
    public bool EstVilain { get; set; }
    public int FranchiseId { get; set; }
    public Franchise Franchise { get; set; } = null!;
    public ICollection<Distribution> DistributionListe { get; set; } = new List<Distribution>();
}