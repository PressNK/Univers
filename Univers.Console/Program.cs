global using Univers.Domain.Entities; //Les classes du modèle du contexte
global using Univers.Data.Context; // La classe du contexte
global using System;
global using System.Collections.Generic;
global using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using (UniversContext db = new ())
{
    Franchise marvel = db.Franchises.First(f => f.Nom == "Marvel");
    Franchise dc = db.Franchises.First(f => f.Nom == "DC Comics");

    Personnage joker = new ()
    {
        Nom = "Joker",
        IdentiteReelle = null,
        DateNaissance = new DateOnly(1966, 01, 01),
        EstVilain = true,
        FranchiseId = dc.FranchiseId,

    };

    Personnage thor = new ()
    {
        Nom = "Thor",
        IdentiteReelle = "Thor",
        DateNaissance = new DateOnly(01, 01, 01),
        EstVilain = false,
        FranchiseId = marvel.FranchiseId,

    };
    Personnage blackwidow = new ()
    {
        Nom = "Black Widow",
        IdentiteReelle = "Nathasha Romanoff",
        DateNaissance = new DateOnly(1985, 08, 31),
        EstVilain = false,
        FranchiseId = marvel.FranchiseId,

    };

    db.Add(joker);
    db.Add(thor);
    db.Add(blackwidow);

    //il est important de faire la sauvegarde afin d'avoir des id pour les 3
    // personnages ajoutés. 
    db.SaveChanges();

    Film darkknight = new ()
    {
        Titre = "The Dark Knight",
        DateSortie = new DateOnly(2008, 07, 18),
        Etoile = 5, 
        Duree = 142,
    };
    Film endgame = new ()
    {
        Titre = "Avengers : Endgame",
        DateSortie = new DateOnly(2019, 04, 26),
        Etoile = 4,
        Duree = 132,
    };
    Film ironman = new ()
    {
        Titre = "Iron Man",
        DateSortie = new DateOnly(2008, 05, 02),
        Etoile = 4,
        Duree = 96,
    };

    Film jokerf = new ()
    {
        Titre = "Joker",
        DateSortie = new DateOnly(2019, 10, 04),
        Etoile = 4,
        Duree = 99,
    };

    db.Add(darkknight);
    db.Add(endgame);
    db.Add(ironman); 
    db.Add(jokerf);

    db.SaveChanges();
    
    //Pour compléter l'inventaire des personnages et films qui sont déjà dans la bd
    Personnage spidey = db.Personnages.Where(p => p.Nom == "Spiderman").First();
    Personnage ironmanP = db.Personnages.Where(p => p.Nom == "Iron Man").First();
    Personnage batman = db.Personnages.Where(p => p.Nom == "Batman").First();

    Film spidermanF = db.Films.Where(f => f.Titre == "Spiderman").First();
    Film ironmanF  = db.Films.Where(f => f.Titre == "Iron Man").First();
    Film batmanF = db.Films.Where(f => f.Titre == "The Dark Knight").First();
    Film avenger = db.Films.Where(f => f.Titre == "The Avengers").First();
    Film blackwidowF = db.Films.Where(f => f.Titre == "Black Widow").First();

    List<Distribution> distributions =
    [
        new Distribution()
        {
            PersonnageId = spidey.PersonnageId,
            FilmId = spidermanF.FilmId,
            Acteur = "Tobey Maguire"
        },
        new Distribution()
        {
            PersonnageId = spidey.PersonnageId,
            FilmId = endgame.FilmId,
            Acteur = "Tom Holland"
        },
        new Distribution()
        {
            PersonnageId=ironmanP.PersonnageId,
            FilmId = ironmanF.FilmId,
            Acteur = "Robert Downey Jr"
        },
        new Distribution()
        {
            PersonnageId=ironmanP.PersonnageId,
            FilmId = endgame.FilmId,
            Acteur = "Robert Downey Jr"
        },
        new Distribution()
        {
            PersonnageId=batman.PersonnageId,
            FilmId = darkknight.FilmId,
            Acteur = "Christian Bale"
        },
        new Distribution()
        {
            PersonnageId=joker.PersonnageId,
            FilmId = darkknight.FilmId,
            Acteur = "Heath Ledger"
        },
        new Distribution()
        {
            PersonnageId=joker.PersonnageId,
            FilmId = jokerf.FilmId,
            Acteur = "Joaquin Phoenix"
        },
        new Distribution()
        {
            PersonnageId=thor.PersonnageId,
            FilmId = endgame.FilmId,
            Acteur = "Chris Hemsworth"
        },
        new Distribution()
        {
            PersonnageId=thor.PersonnageId,
            FilmId = avenger.FilmId,
            Acteur = "Chris Hemsworth"
        },
        new Distribution()
        {
            PersonnageId=blackwidow.PersonnageId,
            FilmId = endgame.FilmId,
            Acteur = "Scarlett Johansson"
        },
        new Distribution()
        {
            PersonnageId=blackwidow.PersonnageId,
            FilmId = avenger.FilmId,
            Acteur = "Scarlett Johansson"
        },
        new Distribution()
        {
            PersonnageId=blackwidow.PersonnageId,
            FilmId = blackwidowF.FilmId,
            Acteur = "Scarlett Johansson"
        }
    ];

	//Il es possible de faire une boucle, mais c'est plus optimal côté performance
	//de faire un .AddRange pour ajouter un "batch"
	//foreach (Distribution d in distributions)
	//{
	//	db.Add(d);
	//}
	db.AddRange(distributions);

    db.SaveChanges();
}