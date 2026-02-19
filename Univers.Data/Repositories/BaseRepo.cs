using Microsoft.EntityFrameworkCore;
using Univers.Data.Context;
using Univers.Domain.Repositories;

namespace Univers.Data.Repositories;

/// <summary>
/// Classe abstraite générique qui contient les opérations de base des tables de la base de données
/// </summary>
/// <typeparam name="TData">Type du modèle de données / table</typeparam>
public class BaseRepo<TData> : IBaseRepo<TData> where TData : class
{
    protected readonly UniversContext _dbContext;

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="dbContext">Contexte de la base de données</param>
    public BaseRepo(UniversContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TData>> ObtenirListeAsync()
    {
        //Équivalent à _db.TData.ToListAsync();
        return await _dbContext.Set<TData>().ToListAsync();
    }

    public List<TData> ObtenirListe()
    {
        //Équivalent à _db.TData.ToList();
        return _dbContext.Set<TData>().ToList();
    }

    public async Task AjouterAsync(TData item, bool enregistrer)
    {
        //Add est déjà générique.
        //Sa définition réelle est _dbContext.Add<TData>().
        _dbContext.Add(item);

        //Vérifie si l'ajout doit être appliqué dans la base de données immédiatement
        if (enregistrer == true)
        {
            //L'ajout doit être appliqué dans la base de données immédiatement
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            //L'ajout est seulement en mémoire
            await Task.CompletedTask;
        }
    }

    public void Ajouter(TData item, bool enregistrer)
    {
        //Add est déjà générique.
        //Sa définition réelle est _dbContext.Add<TData>().
        _dbContext.Add(item);

        //Vérifie si l'ajout doit être appliqué dans la base de données immédiatement
        if (enregistrer == true)
        {
            //L'ajout doit être appliqué dans la base de données immédiatement
            _dbContext.SaveChanges();
        }
    }

    public async Task AjouterAsync(List<TData> items, bool enregistrer)
    {
        //AddRange est déjà générique.
        //Sa définition réelle est _dbContext.AddRange<TData>().
        _dbContext.AddRange(items);

        //Vérifie si l'ajout doit être appliqué dans la base de données immédiatement
        if (enregistrer == true)
        {
            //L'ajout doit être appliqué dans la base de données immédiatement
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            //L'ajout est seulement en mémoire
            await Task.CompletedTask;
        }
    }

    public void Ajouter(List<TData> items, bool enregistrer)
    {
        //AddRange est déjà générique.
        //Sa définition réelle est _dbContext.AddRange<TData>().
        _dbContext.AddRange(items);

        //Vérifie si l'ajout doit être appliqué dans la base de données immédiatement
        if (enregistrer == true)
        {
            //L'ajout doit être appliqué dans la base de données immédiatement
            _dbContext.SaveChanges();
        }
    }

    public async Task SupprimerAsync(TData item, bool enregistrer)
    {
        //Remove est déjà générique.
        //Sa définition réelle est _dbContext.Remove<TData>().
        _dbContext.Remove(item);

        //Vérifie si la suppression doit être appliquée dans la base de données immédiatement
        if (enregistrer == true)
        {
            //La suppression doit être appliquée dans la base de données immédiatement
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            //La suppression est seulement en mémoire
            await Task.CompletedTask;
        }
    }

    public void Supprimer(TData item, bool enregistrer)
    {
        //Remove est déjà générique.
        //Sa définition réelle est _dbContext.Remove<TData>().
        _dbContext.Remove(item);

        //Vérifie si la suppression doit être appliquée dans la base de données immédiatement
        if (enregistrer == true)
        {
            //La suppression doit être appliquée dans la base de données immédiatement
            _dbContext.SaveChanges();
        }
    }

    public async Task SupprimerAsync(List<TData> items, bool enregistrer)
    {
        //RemoveRange est déjà générique.
        //Sa définition réelle est _dbContext.RemoveRange<TData>().        
        _dbContext.RemoveRange(items);

        //Vérifie si la suppression doit être appliquée dans la base de données immédiatement
        if (enregistrer == true)
        {
            //La suppression doit être appliquée dans la base de données immédiatement
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            //La suppression est seulement en mémoire
            await Task.CompletedTask;
        }
    }

    public void Supprimer(List<TData> items, bool enregistrer)
    {
        //RemoveRange est déjà générique.
        //Sa définition réelle est _dbContext.RemoveRange<TData>().        
        _dbContext.RemoveRange(items);

        //Vérifie si la suppression doit être appliquée dans la base de données immédiatement
        if (enregistrer == true)
        {
            //La suppression doit être appliquée dans la base de données immédiatement
            _dbContext.SaveChanges();
        }
    }
    public async Task EnregistrerAsync()
    {
        //Enregistre les ajouts, modifications et suppression en attente dans la mémoire du contexte
        await _dbContext.SaveChangesAsync();
    }

    public void Enregistrer()
    {
        //Enregistre les ajouts, modifications et suppressions en attente dans la mémoire du contexte
        _dbContext.SaveChanges();
    }
}