using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Localization;
using Moq;
using Univers.Application.Dtos;
using Univers.Application.Dtos.Resources;
using Univers.Application.Dtos.Validateurs;
using Univers.UnitTests.Generateurs;
using Univers.UnitTests.Mocks;

namespace Univers.UnitTests.Validateurs;

public class CreerPersonnageDtoValidateurTests
{
    private readonly CreerPersonnageDtoValidateur _validateur;

    public CreerPersonnageDtoValidateurTests()
    {
        var localizerMock = new PersonnagesLocalizerMock();
        _validateur = new CreerPersonnageDtoValidateur(localizerMock.Object);
    }
    
    [Fact]
    public void SachantQue_NomEstVide_Pour_Valider_Alors_ErreurDeValidation()
    {
        var dto = new CreerPersonnageDto
        {
            Nom = string.Empty,
            IdentiteReelle = "Gabby",
            EstVilain = true,
            DateNaissance = new DateOnly(2000, 1, 1)
        };

        var resultatValidation = _validateur.TestValidate(dto);

        resultatValidation.ShouldHaveValidationErrorFor(p => p.Nom);
        resultatValidation.Errors.Count.Should().Be(1);
    }
    
    [Fact]
    public void SachantQue_NomDepasse100Caracteres_Pour_Valider_Alors_ErreurDeValidation()
    {
        string longNom = new('A', 101); // 101 caractères
        var dto = new CreerPersonnageDto
        {
            Nom = longNom,
            IdentiteReelle = string.Empty,
            EstVilain = true,
            DateNaissance = new DateOnly(2000, 1, 1)
        };

        var resultatValidation = _validateur.TestValidate(dto);

        resultatValidation.ShouldHaveValidationErrorFor(p => p.Nom);
        resultatValidation.Errors.Count.Should().Be(1);
    }

    [Fact]
    public void SachantQue_DateNaissanceEstAvant1900_Pour_Valider_Alors_ErreurDeValidation()
    {
        var dto = new CreerPersonnageDto
        {
            Nom = "Personnage Test",
            DateNaissance = new DateOnly(1899, 12, 31)
        };

        var resultatValidation = _validateur.TestValidate(dto);
    
        resultatValidation.ShouldHaveValidationErrorFor(p => p.DateNaissance);
        resultatValidation.Errors.Count.Should().Be(1);
    }
    
    [Theory]
    [ClassData(typeof(CreerPersonnageDtoDataGenerateur))]
    public void VersionClassData_SachantQue_ToutesLesDonneesSontValides_Pour_Valider_Alors_ValidationReussie(CreerPersonnageDto dto)
    {
        var resultatValidation = _validateur.TestValidate(dto);

        resultatValidation.Errors.Should().BeEmpty();
    }

}