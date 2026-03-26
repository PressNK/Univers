using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;

public class VenteFranchise : IVenteFranchise
{
    private readonly IFranchiseRepository _franchiseRepository;
    private readonly IPersonnageRepository _personnageRepository;

    public VenteFranchise(IFranchiseRepository franchiseRepository, IPersonnageRepository  personnageRepository)
    {
        _franchiseRepository = franchiseRepository;
        _personnageRepository = personnageRepository;
    }

    public StatutVenteFranchise Execute(int franchiseId, string nomProprietaire)
    {
        var franchiseVendue = _franchiseRepository.Chercher(franchiseId);
        if (franchiseVendue == null)
        {
            return StatutVenteFranchise.NoData; // Franchise non trouvée
        }

        string nomFranchiseVendu = franchiseVendue.Nom;
        franchiseVendue.Nom += " vendu";

        Franchise franchise = new()
        {
            Nom = nomFranchiseVendu,
            AnneeCreation = franchiseVendue.AnneeCreation,
            SiteWeb = franchiseVendue.SiteWeb,
            Proprietaire = nomProprietaire,
        };
        try
        {
            _franchiseRepository.Ajouter(franchise, enregistrer: true);

            foreach (var personnage in franchiseVendue.PersonnageListe)
            {
                personnage.FranchiseId = franchise.FranchiseId;
            }
            _personnageRepository.Enregistrer();
            _franchiseRepository.Supprimer(franchiseVendue, enregistrer: true);
            return StatutVenteFranchise.Completed;
        }
        catch
        {
            return StatutVenteFranchise.Failed;
        }
    }
}