using Univers.Domain.Entities;

namespace Univers.Domain.Repositories;

public interface IDistributionRepository : IBaseRepo<Distribution>
{
    List<Distribution> ObtenirParFilm(int filmId);
    List<Distribution> ObtenirParPersonnage(int personnageId);
}