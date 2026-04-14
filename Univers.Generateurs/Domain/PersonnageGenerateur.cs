using Bogus;
using Univers.Domain.Entities;

namespace Univers.Generateurs.Domain;
public class PersonnageGenerateur : Faker<Personnage>
{
    private readonly List<Franchise> _franchises = [];
    private List<int> FranchiseIds => _franchises.ConvertAll(x => x.FranchiseId);

    public PersonnageGenerateur()
    {
        RuleFor(p => p.Nom, f => $"{f.Name.FirstName()} {f.Name.LastName()}");
        RuleFor(p => p.IdentiteReelle, f => f.Random.Bool(0.6f) ? f.Name.FullName() : null);
        RuleFor(p => p.DateNaissance, f => DateOnly.FromDateTime(f.Date.Past(100)));
        RuleFor(p => p.EstVilain, f => f.Random.Bool(0.3f));
        RuleFor(p => p.FranchiseId, f => f.PickRandom(FranchiseIds));
    }

    public PersonnageGenerateur AjouterFranchises(IEnumerable<Franchise> franchises)
    {
        _franchises.Clear();
        _franchises.AddRange(franchises);
        return this;
    }

    public Personnage Generer()
    {
        return base.Generate();
    }

    public IEnumerable<Personnage> Generer(int nombre)
    {
        return Generate(nombre);
    }
}