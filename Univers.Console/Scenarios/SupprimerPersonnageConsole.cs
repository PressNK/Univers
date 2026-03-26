using Univers.Application.UseCases;
using Univers.Domain.Entities;

namespace Univers.Console.Scenarios;

public class SupprimerPersonnageConsole
{
    private readonly ISupprimerPersonnage _supprimerPersonnage;

    public SupprimerPersonnageConsole(ISupprimerPersonnage supprimerPersonnage)
    {
        _supprimerPersonnage = supprimerPersonnage;
    }
    
    public void SupprimerUnPersonnage()
    {
	    int personnageId = AideConsole.DemanderEntier("Entrez l'identifiant du personnage : ");
	    StatutSuppression statut = _supprimerPersonnage.Execute(personnageId);
	    switch (statut)
	    {
		    case StatutSuppression.Completed:
			    System.Console.WriteLine($"Personnage supprimé avec succès pour cet ID: {personnageId}.");
			    break;
		    case StatutSuppression.NoData:
			    System.Console.WriteLine($"Aucun personnage trouvé avec cet ID:  {personnageId}.");
			    break;
		    case StatutSuppression.Failed:
			    System.Console.WriteLine($"Une erreur est survenue lors de la suppression du personnage ayant l'ID: {personnageId}.");
			    break;
		    default:
			    throw new NotImplementedException($"La méthode {nameof(SupprimerUnPersonnage)} n'implémente pas la valeur {statut} du type {typeof(StatutSuppression)}");
	    }
	}
}