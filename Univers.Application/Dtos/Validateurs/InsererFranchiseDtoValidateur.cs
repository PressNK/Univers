using FluentValidation;
using Microsoft.Extensions.Localization;
using Univers.Domain.Entities;

namespace Univers.Application.Dtos.Validateurs;

public class InsererFranchiseDtoValidateur : AbstractValidator<InsererFranchiseDto>
{
    public InsererFranchiseDtoValidateur(IStringLocalizer<Franchise> localizer)
    {
        RuleFor(film => film.Nom).NotEmpty()
            .MaximumLength(100)
            .WithName(localizer.GetString("Nom"));
        RuleFor(film => film.AnneeCreation).GreaterThanOrEqualTo((short)1890)
            .WithName(localizer.GetString("AnneeCreation"));
        RuleFor(film => film.SiteWeb).MaximumLength(200)
            .WithName(localizer.GetString("SiteWeb"));
        RuleFor(film => film.Proprietaire).MaximumLength(250)
            .WithName(localizer.GetString("Proprietaire"));
    }
}