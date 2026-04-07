using FluentValidation;
using Microsoft.Extensions.Localization;
using Univers.Application.Dtos.Resources;

namespace Univers.Application.Dtos.Validateurs;
public class CreerPersonnageDtoValidateur : AbstractValidator<CreerPersonnageDto>
{
    public CreerPersonnageDtoValidateur(IStringLocalizer<Personnages> localizer)
    {
        RuleFor(personnage => personnage.Nom).NotEmpty()
            .MaximumLength(100)
            .WithName(localizer.GetString("Nom"));
        RuleFor(personnage => personnage.DateNaissance).GreaterThanOrEqualTo(new DateOnly(1900, 1, 1))
            .WithName(localizer.GetString("DateNaissance"));
    }
}