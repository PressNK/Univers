using System.Globalization;
using Univers.Application.Dtos;
using Univers.Application.UseCases;

namespace Univers.Console.Scenarios;

internal class AjouterPersonnageConsole
{
    private readonly IAjouterPersonnage _ajouterPersonnage;

    public AjouterPersonnageConsole(IAjouterPersonnage ajouterPersonnage)
    {
        _ajouterPersonnage = ajouterPersonnage;
    }

    public void AjouterUnPersonnage()
    {
        CreerPersonnageDto personnage = new();

        personnage.Nom = AideConsole.DemanderString("Entrez le nom du personnage : ", true)!;
        personnage.IdentiteReelle = AideConsole.DemanderString("Entrez l'identité réelle du personnage (appuyez sur Entrée si inconnue) : ", false);
        personnage.DateNaissance = AideConsole.DemanderDate("Entrez la date de naissance (format AAAA-MM-JJ) : ");
        personnage.EstVilain = AideConsole.DemanderBooleen("Est-ce un vilain ? (O/N) : ");
        personnage.FranchiseId = AideConsole.DemanderEntier("Entrez l'ID de la franchise : ");

        _ajouterPersonnage.Execute(personnage);

        System.Console.WriteLine($"Ajout du personnage {personnage.Nom} complété!");
    }
}