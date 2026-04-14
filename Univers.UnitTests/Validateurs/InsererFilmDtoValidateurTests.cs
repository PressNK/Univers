﻿using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Localization;
using Moq;
using Univers.Application.Dtos;
using Univers.Application.Dtos.Resources;
using Univers.Application.Dtos.Validateurs;

namespace Univers.UnitTests.Validateurs;
public class InsererFilmDtoValidateurTests
{
	private readonly InsererFilmDtoValidateur _validateur;

	public InsererFilmDtoValidateurTests()
	{
		var localizerMock = new Mock<IStringLocalizer<Films>>();
		localizerMock.SetupGet(l => l["Titre"]).Returns(new LocalizedString("Titre", "Titre"));
		localizerMock.SetupGet(l => l["DateSortie"]).Returns(new LocalizedString("DateSortie", "Date de sortie"));
		localizerMock.SetupGet(l => l["Etoile"]).Returns(new LocalizedString("Etoile", "Étoile"));
		localizerMock.SetupGet(l => l["Duree"]).Returns(new LocalizedString("Duree", "Durée"));

		_validateur = new InsererFilmDtoValidateur(localizerMock.Object);
	}

	[Fact]
	public void SachantQue_TitreEstVide_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = string.Empty,
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = 3,
			Duree = 120
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Titre);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_TitreDepasse100Caracteres_Pour_Valider_Alors_ErreurDeValidation()
	{
		string longTitre = new('A', 101);
		var dto = new InsererFilmDto
		{
			Titre = longTitre,
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = 3,
			Duree = 120
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Titre);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_DateSortieEstAvant1890_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = "Film Ancien",
			DateSortie = new DateOnly(1889, 12, 31),
			Etoile = 3,
			Duree = 60
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.DateSortie);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_EtoileEstInferieurA0_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = "Film Test",
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = unchecked((byte)-1), // Force une valeur négative
			Duree = 120
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Etoile);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_EtoileEstSuperieurA5_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = "Film Test",
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = 6,
			Duree = 120
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Etoile);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_DureeEstNegative_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = "Film Test",
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = 3,
			Duree = -1
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Duree);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Fact]
	public void SachantQue_DureeEstSuperieurA400_Pour_Valider_Alors_ErreurDeValidation()
	{
		var dto = new InsererFilmDto
		{
			Titre = "Film Très Long",
			DateSortie = new DateOnly(2000, 1, 1),
			Etoile = 3,
			Duree = 401
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.ShouldHaveValidationErrorFor(f => f.Duree);
		resultatValidation.Errors.Count.Should().Be(1);
	}

	[Theory]
	[InlineData("Inception", 2010, 3, 148)]
	[InlineData("Test", 2025, 0, 0)]
	[InlineData("Le Voyage dans la Lune", 1902, 5, 13)]
	[InlineData("Film Moderne", 2023, 0, 400)]
	public void SachantQue_ToutesLesDonneesSontValides_Pour_Valider_Alors_ValidationReussie(
		string titre, int anneeSortie, byte etoile, int duree)
	{
		var dto = new InsererFilmDto
		{
			Titre = titre,
			DateSortie = new DateOnly(anneeSortie, 1, 1),
			Etoile = etoile,
			Duree = duree
		};

		var resultatValidation = _validateur.TestValidate(dto);

		resultatValidation.Errors.Should().BeEmpty();
	}
}
