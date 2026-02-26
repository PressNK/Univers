using Univers.Domain.Entities;

namespace Univers.Console.Extensions;

public static class PersonnageConsoleExtensions
{
    public static void AfficherConsole(this Personnage? personnage)
    {
        if (personnage != null)
        {
            System.Console.WriteLine($"Id : {personnage.PersonnageId}");
            System.Console.WriteLine($"Nom : {personnage.Nom}");

            //Le ?? permet d'indiquer la valeur de remplacement si IdentiteReelle est null
            System.Console.WriteLine($"Identité réelle : {personnage.IdentiteReelle ?? "Inconnue"}");

            //Affiche la date de naissance en d MMM yyyy -> 3 dec 1998
            System.Console.WriteLine($"Date de naissance : {personnage.DateNaissance:d MMM yyyy}");
            
            System.Console.WriteLine($"Est vilain : {(personnage.EstVilain ? "Oui" : "Non")}");
            System.Console.WriteLine($"Franchise Id : {personnage.FranchiseId}");

            if (personnage.Franchise != null)
            {
                System.Console.WriteLine($"Nom franchise : {personnage.Franchise.Nom}");
            } 
            else
            {
                System.Console.WriteLine("Franchise inconnue");
            }
        }
        else
        {
            System.Console.WriteLine("Personnage inexistant.");
        }
    }
}