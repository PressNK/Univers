using Bogus;
using Univers.Application.Dtos;

namespace Univers.UnitTests.Generateurs;
public class CreerPersonnageDtoGenerateur : Faker<CreerPersonnageDto>
{
    public CreerPersonnageDtoGenerateur()
    {
        RuleFor(p => p.Nom, f => f.Name.FullName());
        RuleFor(p => p.IdentiteReelle, f => f.Random.Bool(0.4f) ? f.Name.FullName() : null);
        RuleFor(p => p.DateNaissance, f => DateOnly.FromDateTime(f.Date.Past(100, DateTime.Now.AddYears(-10))));
        RuleFor(p => p.EstVilain, f => f.Random.Bool(0.4f));
        RuleFor(p => p.FranchiseId, f => f.Random.Number(1, 10));
    }

    public CreerPersonnageDto Generer()
    {
        return base.Generate();
    }

    public List<CreerPersonnageDto> Generer(int nombre)
    {
        return base.Generate(nombre);
    }
}