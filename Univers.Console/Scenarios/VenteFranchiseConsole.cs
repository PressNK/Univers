using Univers.Application.Dtos;
using Univers.Application.UseCases;
using Univers.Domain.Entities;

namespace Univers.Console.Scenarios;

public class VenteFranchiseConsole
{
    private readonly IVenteFranchise _venteFranchise;

    public VenteFranchiseConsole(IVenteFranchise venteFranchise)
    {
        _venteFranchise = venteFranchise;
    }
    
    public void VendreUneFranchise()
    {
        System.Console.WriteLine("------ VENDRE UNE FRANCHISE ------");
        System.Console.WriteLine();
        
        int franchideVenduId = AideConsole.DemanderEntier("Entrez l'ID de la franchise à vendre :");
        string nomProprietaire = AideConsole.DemanderString("Entrez le nom du propriétaire de la nouvelle franchise :", true)!;
        
        StatutVenteFranchise statut = _venteFranchise.Execute(franchideVenduId, nomProprietaire);
        switch (statut)
        {
            case StatutVenteFranchise.Completed:
                System.Console.WriteLine($"Vente de la franchise complété pour cet ID: {franchideVenduId} acheté par {nomProprietaire}.");
                break;
            case StatutVenteFranchise.NoData:
                System.Console.WriteLine($"Aucun personnage trouvé avec cet ID:  {franchideVenduId}.");
                break;
            case StatutVenteFranchise.Failed:
                System.Console.WriteLine($"Une erreur est survenue lors de la vente de la franchise ayant l'ID: {franchideVenduId}.");
                break;
            default:
                throw new NotImplementedException($"La méthode {nameof(VendreUneFranchise)} n'implémente pas la valeur {statut} du type {typeof(StatutVenteFranchise)}");
        }
        
        
    }
}