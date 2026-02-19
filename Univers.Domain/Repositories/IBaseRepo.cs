namespace Univers.Domain.Repositories;

/// <summary>
/// Interface générique qui contient les opérations de base des tables de la base de données
/// </summary>
/// <typeparam name="TData">Type du modèle de données / table</typeparam>
public interface IBaseRepo<TData> where TData : class
{
    /// <summary>
    /// Obtenir la liste de tous les items en asynchrone.
    /// </summary>
    /// <returns>Liste des items</returns>
    Task<List<TData>> ObtenirListeAsync();

    /// <summary>
    /// Obtenir la liste de tous les items.
    /// </summary>
    /// <returns>Liste des items</returns>
    List<TData> ObtenirListe();

    /// <summary>
    /// Ajouter une liste d'items dans la base de données en asynchrone.
    /// </summary>
    /// <param name="items">Liste des items à ajouter</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    Task AjouterAsync(List<TData> items, bool enregistrer);

    /// <summary>
    /// Ajouter une liste d'items dans la base de données.
    /// </summary>
    /// <param name="items">Liste des items à ajouter</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    void Ajouter(List<TData> items, bool enregistrer);

    /// <summary>
    /// Ajouter un item dans la base de données en asynchrone.
    /// </summary>
    /// <param name="item">L'item à ajouter</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    Task AjouterAsync(TData item, bool enregistrer);

    /// <summary>
    /// Ajouter un item dans la base de données.
    /// </summary>
    /// <param name="item">L'item à ajouter</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    void Ajouter(TData item, bool enregistrer);

    /// <summary>
    /// Supprimer une liste d'items dans la base de données en asynchrone.
    /// </summary>
    /// <param name="items">Liste des items à supprimer</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    Task SupprimerAsync(List<TData> items, bool enregistrer);

    /// <summary>
    /// Supprimer une liste d'items dans la base de données.
    /// </summary>
    /// <param name="items">Liste des items à supprimer</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    void Supprimer(List<TData> items, bool enregistrer);

    /// <summary>
    /// Supprimer un item dans la base de données en asynchrone.
    /// </summary>
    /// <param name="item">L'item à supprimer</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    Task SupprimerAsync(TData item, bool enregistrer);

    /// <summary>
    /// Supprimer un item dans la base de données.
    /// </summary>
    /// <param name="item">L'item à supprimer</param>
    /// <param name="enregistrer">Enregistrer immédiatement ou non dans la base de données</param>
    void Supprimer(TData item, bool enregistrer);

    /// <summary>
    /// Enregistrer l'état actuel du contexte dans la base de données en asynchrone.
    /// </summary>
    Task EnregistrerAsync();

    /// <summary>
    /// Enregistrer l'état actuel du contexte dans la base de données.
    /// </summary>
    void Enregistrer();
}