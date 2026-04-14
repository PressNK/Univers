using FluentAssertions;
using Moq;
using Univers.Application.UseCases;
using Univers.Application.UseCases.Implementations;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.UnitTests.UseCases;
public class SupprimerPersonnageTests
{
    private readonly ISupprimerPersonnage _useCase;
    private readonly Mock<IPersonnageRepository> _personnageRepositoryMock;

    public SupprimerPersonnageTests()
    {
        _personnageRepositoryMock = new Mock<IPersonnageRepository>();
        _useCase = new SupprimerPersonnage(_personnageRepositoryMock.Object);
    }
    
    [Fact]
    public void SachantQue_LePersonnageNExistePas_Pour_SupprimerPersonnage_Alors_PersonnageNEstPasSupprime()
    {
        int personnageId = 2;
        _personnageRepositoryMock.Setup(m => m.Chercher(personnageId)).Returns((Personnage?)null);

        StatutSuppression statutActuel = _useCase.Execute(personnageId);
        
        statutActuel.Should().Be(StatutSuppression.NoData);
        _personnageRepositoryMock.VerifyAll();
        _personnageRepositoryMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void SachantQue_LePersonnageExiste_Pour_SupprimerPersonnage_Alors_PersonnageEstSupprime()
    {
        int personnageId = 1;
        Personnage personnage = GenererPersonnage(personnageId);
        _personnageRepositoryMock.Setup(m => m.Chercher(personnage.PersonnageId)).Returns(personnage);
        _personnageRepositoryMock.Setup(m => m.Supprimer(personnage, true));

        StatutSuppression statutActuel = _useCase.Execute(personnageId);
        
        statutActuel.Should().Be(StatutSuppression.Completed);
        _personnageRepositoryMock.VerifyAll();
        _personnageRepositoryMock.VerifyNoOtherCalls();
    }
    
    
    private static Personnage GenererPersonnage(int id) 
    {
        return new Personnage()
        {
            PersonnageId = id,
            Nom = string.Empty,
            EstVilain = true,
            DateNaissance = new DateOnly(2000, 1, 1)
        };
    }
}