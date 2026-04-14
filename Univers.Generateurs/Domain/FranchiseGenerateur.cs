using Bogus;
using Univers.Domain.Entities;

namespace Univers.Generateurs.Domain;
public class FranchiseGenerateur : Faker<Franchise>
{
    public FranchiseGenerateur()
    {
        RuleFor(f => f.Nom, f => f.Company.CompanyName());
        RuleFor(f => f.AnneeCreation, f => (short)f.Random.Number(1900, DateTime.Now.Year));
        RuleFor(f => f.SiteWeb, f => f.Random.Bool(0.9f) ? f.Internet.Url() : null);
        RuleFor(f => f.Proprietaire, f => f.Random.Bool(0.7f) ? f.Name.FullName() : null);
    }

    public Franchise Generer()
    {
        return base.Generate();
    }

    public IEnumerable<Franchise> Generer(int nombre)
    {
        return Generate(nombre);
    }
}