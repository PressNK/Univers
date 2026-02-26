using Microsoft.EntityFrameworkCore;
using Univers.Data.Context;
using Univers.Domain.Entities;
using Univers.Domain.Repositories; 

namespace Univers.Data.Repositories;

public class PersonnageRepository : BaseRepo<Personnage>, IPersonnageRepository
{
    public PersonnageRepository(UniversContext dbContext)
        : base(dbContext)
    {
    }

    public Personnage Obtenir(int personnageId)
    {
        Personnage personnage =
            (from lqPersonnage in _dbContext.Personnages
                where lqPersonnage.PersonnageId == personnageId
                select lqPersonnage).First();

        return personnage;
    }

    public List<Personnage> ObtenirParFranchise(int franchiseId)
    {
        List<Personnage> personnages =
            (from lqPersonnage in _dbContext.Personnages
                where lqPersonnage.FranchiseId == franchiseId
                select lqPersonnage).ToList();

        return personnages;
    }
    
    public Personnage? ObtenirAvecInclude(int personnageId)
    {
        Personnage? pAvecInclude =
            (from lqPersonnage in _dbContext.Personnages.Include(p => p.Franchise)
                where lqPersonnage.PersonnageId == 1
                select lqPersonnage).FirstOrDefault();
        return pAvecInclude;
    }
}