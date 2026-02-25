using Univers.Domain.Entities;

namespace Univers.Domain.Repositories;
public interface IFranchiseRepository : IBaseRepo<Franchise>
{
    public Franchise Obtenir(int franchiseId);
    public Franchise ObtenirParNom(string nom);
}