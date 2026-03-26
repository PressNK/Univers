namespace Univers.Application.Dtos;

public class CreerFranchiseDto
{
    public string Nom { get; set; } = null!;
    public string Proprietaire { get; set; } = null!;
    public short AnneeCreation { get; set; }
    public string? SiteWeb { get; set; }
}