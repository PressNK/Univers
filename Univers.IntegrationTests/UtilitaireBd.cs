using Univers.Data.Context;
using Univers.Domain.Entities;
using Univers.Generateurs.Domain;

namespace Univers.IntegrationTests;

/// <summary>
/// Classe qui permet de gérer la base de données pour les tests
/// </summary>
public class UtilitaireBd
{
    private readonly UniversContext _bd;

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="bd">Contexte de la base de données</param>
    public UtilitaireBd(UniversContext bd)
    {
        _bd = bd;
    }

    /// <summary>
    /// Initialise la base de données Test et applique la migration
    /// </summary>
    public void Initialiser()
    {
        //Supprime la base de données si elle existe
        _bd.Database.EnsureDeleted();

        //Crée la base de données
        _bd.Database.EnsureCreated();        
    }

    public UniversContext BdContext 
    { 
        get 
        { 
            return _bd; 
        } 
    }
    
    public Franchise AjouterFranchise() 
    {
        Franchise franchise = new FranchiseGenerateur().Generer();

        _bd.Franchises.Add(franchise);
        _bd.SaveChanges();

        return franchise;
    }
}