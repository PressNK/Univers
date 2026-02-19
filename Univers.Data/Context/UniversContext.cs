using Microsoft.EntityFrameworkCore;
using Univers.Domain.Entities;

namespace Univers.Data.Context;

/// <summary>
/// Contexte pour la base de de données Univers
/// </summary>
public class UniversContext : DbContext
{
    private bool _executerSeed = false;
    
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
                _executerSeed = true;
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
        
        if (_executerSeed == true)
        {
            Seed(modelBuilder);
        }
    }
    
    /// <summary>
    /// Méthode qui s'occupe de la création des données
    /// </summary>
    private void Seed(ModelBuilder modelBuilder)
    {
        //Les données à ajouter
        //Les données à ajouter
        Franchise[] franchises =
        [
            new Franchise()
            {
                FranchiseId = 1,
                Nom = "Marvel",
                AnneeCreation = 1939,
                SiteWeb = "https://www.marvel.com",
                Proprietaire = "Disney"
            },
            new Franchise()
            {
                FranchiseId = 2,
                Nom = "DC Comics",
                AnneeCreation = 1934,
                SiteWeb = "https://www.dc.com",
                Proprietaire = "Warner Bros"
            },
        ];

        Personnage[] personnages =
        [
            new Personnage()
            {
                PersonnageId = 1,
                Nom = "Spiderman",
                IdentiteReelle = "Peter Parker",
                DateNaissance = new DateOnly(1980, 12,01),
                EstVilain = false,
                FranchiseId = 1
            },
            new Personnage()
            {
                PersonnageId = 2,
                Nom = "Iron Man",
                IdentiteReelle = "Tony Stark",
                DateNaissance = new DateOnly(1970,11,12),
                EstVilain = false,
                FranchiseId = 1
            },
            new Personnage()
            {
                PersonnageId = 3,
                Nom = "Batman",
                IdentiteReelle = "Bruce Wayne",
                DateNaissance = new DateOnly(1966,03,04),
                EstVilain = false,
                FranchiseId = 2
            },
        ];
        
        Film[] films =
        [
            new Film()
            {
                FilmId = 1, 
                Titre = "Black Widow",
                DateSortie = new DateOnly(2021, 07, 09),
                Etoile = 3,
                Duree = 121
            },
            new Film()
            {
                FilmId = 2,
                Titre = "Avengers",
                DateSortie =  new DateOnly(2012, 05, 04),
                Etoile = 5, 
                Duree = 98
            },
            new Film()
            {
                FilmId = 3,
                Titre = "Spiderman",
                DateSortie = new DateOnly(2003, 05, 03),
                Etoile = 5,
                Duree = 110
            },
        ];

        //Ajout dans les tables
        modelBuilder.Entity<Franchise>().HasData(franchises);
        modelBuilder.Entity<Personnage>().HasData(personnages);
        modelBuilder.Entity<Film>().HasData(films);
    }

    public DbSet<Personnage> Personnages { get; set; }

    public DbSet<Franchise> Franchises { get; set; }

    public DbSet<Film> Films { get; set; }

    public DbSet<Distribution> Distributions { get; set; } 
}