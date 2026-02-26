using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Console.Scenarios;
public class MiseAJourDonnees
{
    private readonly IPersonnageRepository _personnageRepository;

    public MiseAJourDonnees(IPersonnageRepository personnageRepository)
    {
        _personnageRepository = personnageRepository;
    }

    public void ChangerPersonnages(int franchiseId)
    {
        List<Personnage> personnages = _personnageRepository.ObtenirParFranchise(franchiseId);

        foreach (Personnage personnage in personnages)
        {
            personnage.IdentiteReelle = "Confidentielle";
        }

        _personnageRepository.Enregistrer();
    }
}