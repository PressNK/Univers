using Bogus;
using Univers.Domain.Entities;

namespace Univers.Generateurs.Domain;

public class FilmGenerateur : Faker<Film>
{
    public FilmGenerateur()
    {
        RuleFor(f => f.Titre, f => f.Commerce.ProductName() + " " + f.Random.Word());
        RuleFor(f => f.DateSortie, f => DateOnly.FromDateTime(f.Date.Past(50)));
        RuleFor(f => f.Etoile, f => (byte)f.Random.Number(1, 5));
        RuleFor(f => f.Duree, f => f.Random.Number(70, 240));
    }

    public Film Generer()
    {
        return base.Generate();
    }

    public IEnumerable<Film> Generer(int nombre)
    {
        return Generate(nombre);
    }
}