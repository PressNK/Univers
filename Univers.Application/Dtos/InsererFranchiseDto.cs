namespace Univers.Application.Dtos;

public class InsererFranchiseDto
{
    public int? FranchiseId { get; set; }
    public string Nom { get; set; } = null!;
    public short AnneeCreation { get; set; }
    public string? SiteWeb { get; set; }
    public string? Proprietaire { get; set; }
}