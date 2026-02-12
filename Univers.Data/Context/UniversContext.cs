using Microsoft.EntityFrameworkCore;
using Univers.Domain.Entities;

namespace Univers.Data.Context;

/// <summary>
/// Contexte pour la base de de données Univers
/// </summary>
public class UniversContext : DbContext
{
    /// <summary>
    /// Constructeur pour la migration
    /// </summary>
	public UniversContext() : base()
    {

    }

    /// <summary>
    /// Constructeur pour l'utilisation en programme
    /// </summary>
    /// <param name="options">Option de la base de données</param>
    public UniversContext(DbContextOptions<UniversContext> options)
        : base(options)
    {
    }

#if DEBUG //Permet d'inclure cette méthode uniquement si l'application est en mode DEBUG
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Vérifie si la configuration n'a pas été spécifiée par un fichier de configuration
        if (optionsBuilder.IsConfigured == false)
        {
            //Aucune configuration à partir d'un fichier de configuration
            //Option de base pour la migration
            string? chaineConnexion = Environment.GetEnvironmentVariable("MIGRATION_CONNECTION_STRING");
            //Vérifie si la variable n'est pas vide
            if (string.IsNullOrEmpty(chaineConnexion) == false)
            {
                //La variable n'est pas vide, la chaine de connexion est appliquée
                optionsBuilder.UseSqlServer(chaineConnexion);
            }
            else
            {
                //Il n'y a aucune chaine de connexion.
                throw new Exception("La variable MIGRATION_CONNECTION_STRING n'est pas spécifiée. Effectuez la commande suivante dans la Console du Gestionnaire de package : $env:MIGRATION_CONNECTION_STRING=\"[ma chaine de connexion]\" ");
            }
        }
    }
#endif

    /// <summary>
    /// Configuration spécifique de la base de données
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personnage>(entity =>
        {
            entity.Property(t => t.Nom)
                .IsUnicode(false) //VARCHAR ou CHAR
                .HasMaxLength(100); //VARCHAR(100)  

            entity.Property(t => t.IdentiteReelle)
                .IsUnicode(false) //VARCHAR ou CHAR
                .HasMaxLength(100); //VARCHAR(100)  
        });

        modelBuilder.Entity<Franchise>(entity =>
        {
            entity.Property(t => t.Nom)
                .IsUnicode(false) 
                .HasMaxLength(100);   

            entity.Property(t => t.SiteWeb)
                .IsUnicode(false) 
                .HasMaxLength(200);

            entity.Property(t => t.Proprietaire)
                .IsUnicode(false)
                .HasMaxLength(250); 
            
            entity.HasIndex(t => t.Nom).IsUnique();
            entity.ToTable(b => b.HasCheckConstraint("CK_Franchises_AnneeCreation", "AnneeCreation > 1890")); 
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.Property(t => t.Titre)
                .IsUnicode(false) 
                .HasMaxLength(100);  
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            //spécifie la clé primaire
            entity.HasKey(t => new {t.PersonnageId, t.FilmId});

            entity.Property(t => t.Acteur)
                .IsUnicode(false)
                .HasMaxLength(100);
        });
    }

    public DbSet<Personnage> Personnages { get; set; }

    public DbSet<Franchise> Franchises { get; set; }

    public DbSet<Film> Films { get; set; }

    public DbSet<Distribution> Distributions { get; set; } 
}