using Bogus;
using Univers.Domain.Entities;

namespace Univers.Generateurs.Domain;
public class DistributionGenerateur : Faker<Distribution>
{
    private readonly List<int> _personnageIds = [];
    private readonly List<int> _filmIds = [];

    public DistributionGenerateur()
    {
        RuleFor(d => d.PersonnageId, f => f.PickRandom(_personnageIds));
        RuleFor(d => d.FilmId, f => f.PickRandom(_filmIds));
        RuleFor(d => d.Acteur, f => f.Name.FullName());
    }

    public DistributionGenerateur AjouterPersonnages(List<Personnage> personnages)
    {
        _personnageIds.Clear();
        _personnageIds.AddRange(personnages.Select(p => p.PersonnageId));
        return this;
    }

    public DistributionGenerateur AjouterFilms(List<Film> films)
    {
        _filmIds.Clear();
        _filmIds.AddRange(films.Select(f => f.FilmId));
        return this;
    }

    public Distribution Generer()
    {
        return base.Generate();
    }

    public IEnumerable<Distribution> Generer(int nombre)
    {
        return Generate(nombre);
    }
}