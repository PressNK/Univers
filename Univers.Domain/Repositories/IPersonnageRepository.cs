using Univers.Domain.Entities;

namespace Univers.Domain.Repositories;

public interface IPersonnageRepository
{
    Personnage Obtenir(int personnageId);
    List<Personnage> ObtenirParFranchise(int franchiseId);
}