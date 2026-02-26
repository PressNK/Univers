using Univers.Domain.Entities;

namespace Univers.Domain.Repositories;

public interface IPersonnageRepository : IBaseRepo<Personnage>
{
    Personnage Obtenir(int personnageId);
    List<Personnage> ObtenirParFranchise(int franchiseId);
    public Personnage? ObtenirAvecInclude(int personnageId);
}