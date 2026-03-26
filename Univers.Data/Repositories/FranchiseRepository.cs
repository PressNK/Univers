using Microsoft.EntityFrameworkCore;
using Univers.Data.Context;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Data.Repositories;
public class FranchiseRepository : BaseRepo<Franchise>, IFranchiseRepository
{
    public FranchiseRepository(UniversContext dbContext)
        : base (dbContext)
    {
    }

    public Franchise Obtenir(int franchiseId)
    {
        Franchise franchise =
            (from lqFranchise in _dbContext.Franchises
                where lqFranchise.FranchiseId == franchiseId
                select lqFranchise).First();

        return franchise;
    }
    
    public Franchise? Chercher(int franchiseId)
    {
        Franchise? franchise =
            (from lqFranchise in _dbContext.Franchises
                    .Include(f => f.PersonnageListe) //Indique que la propriété PersonnageListe ne sera pas vide
                where lqFranchise.FranchiseId == franchiseId
                select lqFranchise).FirstOrDefault();

        return franchise;
    }

    public Franchise ObtenirParNom(string nom)
    {
        Franchise franchise =
            (from lqFranchise in _dbContext.Franchises
                where lqFranchise.Nom == nom
                select lqFranchise).First();

        return franchise;
    }
}