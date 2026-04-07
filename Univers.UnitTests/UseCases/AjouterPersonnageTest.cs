using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Moq;
using Univers.Application.Dtos;
using Univers.Application.Dtos.Resources;
using Univers.Application.Dtos.Validateurs;
using Univers.Application.UseCases;
using Univers.Application.UseCases.Implementations;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;
using Univers.UnitTests.Generateurs;
using Univers.UnitTests.Mocks;

namespace Univers.UnitTests.UseCases;
public class AjouterPersonnageTests
{
    private readonly IAjouterPersonnage _useCase;
    private readonly Mock<IPersonnageRepository> _personnageRepositoryMock;
    private readonly CreerPersonnageDtoValidateur _creerPersonnageDtoValidateur;

    public AjouterPersonnageTests()
    {
        _personnageRepositoryMock = new Mock<IPersonnageRepository>();

        var localizerMock = new PersonnagesLocalizerMock();
        _creerPersonnageDtoValidateur = new CreerPersonnageDtoValidateur(localizerMock.Object);

        _useCase = new AjouterPersonnage(_personnageRepositoryMock.Object, _creerPersonnageDtoValidateur);
    }
    
    [Fact]
    public void SachantQue_LePersonnageEstValide_Pour_AjouterPersonnage_Alors_LePersonnageEstAjoute() 
    {
        CreerPersonnageDto dto = new CreerPersonnageDtoGenerateur().Generer();
        _personnageRepositoryMock.Setup(m => m.Ajouter(It.Is<Personnage>(
                actual => TestHelper.VerifierAssertion(
                    () => actual.Should().BeEquivalentTo(dto, string.Empty))),
            true));
        
        _useCase.Execute(dto);

        _personnageRepositoryMock.VerifyAll();
        _personnageRepositoryMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void SachantQue_LePersonnageNeRespectePasLesCriteres_Pour_AjouterPersonnage_Alors_UneExceptionEstLancee()
    {
        CreerPersonnageDto dto = new()
        {
            Nom = string.Empty,
            DateNaissance = new DateOnly(1800, 12, 1),
            EstVilain = true,
            IdentiteReelle = "Bob Gratton"
        };
        
        Assert.Throws<ValidationException>(() => _useCase.Execute(dto));

        _personnageRepositoryMock.VerifyNoOtherCalls();
    }
}