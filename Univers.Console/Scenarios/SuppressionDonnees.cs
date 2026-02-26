using Univers.Data.Context;
using Univers.Domain.Entities;

namespace Univers.Console.Scenarios;
public class SuppressionDonnees
{
    private readonly UniversContext _universContext;

    public SuppressionDonnees(UniversContext universContext)
    {
        _universContext = universContext;
    }

    public void EnleverFranchise(string nom)
    {
        Franchise franchise = _universContext.Franchises.First(u => u.Nom == nom);

        _universContext.Remove(franchise);
        _universContext.SaveChanges();
    }

    public void EnleverPersonnageDeDistribution(int personnageId)
    {
        List<Distribution> distributions =
            (from lqDistribution in _universContext.Distributions
                where lqDistribution.PersonnageId == personnageId
                select lqDistribution).ToList();

        _universContext.RemoveRange(distributions);
        _universContext.SaveChanges();
    }
}