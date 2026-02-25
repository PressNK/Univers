using Univers.Data.Context;
using Univers.Domain.Entities;
using Univers.Domain.Repositories; 

namespace Univers.Data.Repositories;

public class DistributionRepository : BaseRepo<Distribution>, IDistributionRepository
{
    public DistributionRepository(UniversContext dbContext)
        : base(dbContext)
    {
    }

    public List<Distribution> ObtenirParFilm(int filmId)
    {
        List<Distribution> distributions = (from lqDistribution in _dbContext.Distributions
                                     where lqDistribution.FilmId == filmId
                                     select lqDistribution).ToList();
        return distributions;
    }

    public List<Distribution> ObtenirParPersonnage(int personnageId)
    {
        List<Distribution> distributions = (from lqDistribution in _dbContext.Distributions
                                     where lqDistribution.PersonnageId == personnageId
                                     select lqDistribution).ToList();
        return distributions;
    }
}