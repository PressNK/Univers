using Univers.Domain.Entities;
using static System.Console;

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
        WriteLine($"Id : {franchise.FranchiseId}");
        WriteLine($"Nom : {franchise.Nom}");
        WriteLine($"Année de création : {franchise.AnneeCreation}");
        WriteLine($"Site Web : {franchise.SiteWeb}");
        WriteLine($"Propriétaire : {franchise.Proprietaire}");
    }

    /// <summary>
    /// Méthode qui affiche l'information d'une liste de franchises à la console
    /// </summary>
    /// <param name="franchises"></param>
    public static void AfficherConsole(this List<Franchise> franchises)
    {
        if (franchises.Count > 0)
        {
            foreach (Franchise franchise in franchises)
            {
                franchise.AfficherConsole();
            }
        }
    }
}