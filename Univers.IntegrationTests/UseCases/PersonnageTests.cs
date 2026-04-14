using FluentAssertions;
using Univers.Application.UseCases;
using Univers.Application.UseCases.Implementations;
using Univers.Domain.Entities;
using Univers.Generateurs.Domain;

namespace Univers.IntegrationTests.UseCases;
public class PersonnageTests
{
    private readonly IAjouterPersonnage _ajouterPersonnage;
    private readonly IObtenirPersonnage _obtenirPersonnage;
    private readonly ISupprimerPersonnage _supprimerPersonnage;
    private readonly UtilitaireBd _utilitaireBd;

    public PersonnageTests(
        IAjouterPersonnage ajouterPersonnage,
        IObtenirPersonnage obtenirPersonnage,
        ISupprimerPersonnage supprimerPersonnage,
        UtilitaireBd utilitaireBd)
    {
        _ajouterPersonnage = ajouterPersonnage;
        _supprimerPersonnage = supprimerPersonnage;
        _obtenirPersonnage = obtenirPersonnage;
        _utilitaireBd = utilitaireBd;

        _utilitaireBd.Initialiser();
    }
    
    [Fact]
    public void Pour_AjouterPersonnage_Alors_PersonnageEstSauvegarde() 
    {
        Franchise franchise = _utilitaireBd.AjouterFranchise();
        Personnage nouveauPersonnage = new PersonnageGenerateur()
            .AjouterFranchises([franchise])
            .Generer();
        
        int personnageId = _ajouterPersonnage.Execute(new Application.Dtos.CreerPersonnageDto() 
        {
            DateNaissance = nouveauPersonnage.DateNaissance,
            EstVilain = nouveauPersonnage.EstVilain,
            FranchiseId = nouveauPersonnage.FranchiseId,
            IdentiteReelle = nouveauPersonnage.IdentiteReelle,
            Nom = nouveauPersonnage.Nom
        });
        
        Personnage personnageSauvegarde = _obtenirPersonnage.Execute(personnageId);

        personnageSauvegarde.Should().BeEquivalentTo(
            nouveauPersonnage, 
            options => options.Excluding(x => x.PersonnageId)
                .Excluding(x => x.Franchise)
                .Excluding(x => x.DistributionListe));
    }
    
    [Fact]
    public void SachantQue_PersonnageExiste_Pour_SupprimerPersonnage_Alors_PersonnageNExistePlus()
    {
        Franchise franchise = _utilitaireBd.AjouterFranchise();
        Personnage personnageASupprimer = new PersonnageGenerateur()
            .AjouterFranchises([franchise])
            .Generer();

        _utilitaireBd.BdContext.Personnages.Add(personnageASupprimer);
        _utilitaireBd.BdContext.SaveChanges();

        _utilitaireBd.BdContext.Personnages
            .Any(x => x.PersonnageId == personnageASupprimer.PersonnageId)
            .Should()
            .BeTrue();

        StatutSuppression statut = _supprimerPersonnage.Execute(personnageASupprimer.PersonnageId);

        statut.Should().Be(StatutSuppression.Completed);
        _utilitaireBd.BdContext.Personnages
            .Any(x => x.PersonnageId == personnageASupprimer.PersonnageId)
            .Should()
            .BeFalse();
    }
}