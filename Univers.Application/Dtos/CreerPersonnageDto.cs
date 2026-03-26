namespace Univers.Application.Dtos;
public class CreerPersonnageDto
{
    public string Nom { get; set; } = null!;
    public string? IdentiteReelle { get; set; }

    public DateOnly DateNaissance { get; set; }
    public bool EstVilain { get; set; }
    public int FranchiseId { get; set; }
}