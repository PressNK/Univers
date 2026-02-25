using Univers.Domain.Entities;

namespace Univers.Console.Extensions;
/// <summary>
/// Classe statique qui regroupe les méthodes d'extension pour la console du modèle Franchise
/// </summary>
public static class FranchiseConsoleExtensions
{
    /// <summary>
    /// Méthode qui affiche l'information d'une franchise à la console
    /// </summary>
    /// <param name="franchise">Franchise</param>
    public static void AfficherConsole(this Franchise franchise)
    {
        System.Console.WriteLine($"Id : {franchise.FranchiseId}");
        System.Console.WriteLine($"Nom : {franchise.Nom}");
        System.Console.WriteLine($"Année de création : {franchise.AnneeCreation}");
        System.Console.WriteLine($"Site Web : {franchise.SiteWeb}");
        System.Console.WriteLine($"Propriétaire : {franchise.Proprietaire}");
    }
    
    /// <summary>
    /// Méthode qui affiche l'information d'une liste de franchises à la console
    /// </summary>
    /// <param name="franchises"></param>
    public static void AfficherConsole(this List<Franchise> franchises)
    {
        if(franchises.Count > 0)
        {
            foreach (Franchise franchise in franchises)
            {
                franchise.AfficherConsole();
            }
        }
    }
}