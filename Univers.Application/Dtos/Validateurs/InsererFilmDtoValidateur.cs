using FluentValidation;
using Microsoft.Extensions.Localization;
using Univers.Application.Dtos.Resources;

namespace Univers.Application.Dtos.Validateurs;

public class InsererFilmDtoValidateur : AbstractValidator<InsererFilmDto>
{
    public InsererFilmDtoValidateur(IStringLocalizer<Films> localizer)
    {
        RuleFor(film => film.Titre).NotEmpty()
            .MaximumLength(100)
            .WithName(localizer.GetString("Titre"));
        RuleFor(film => film.DateSortie).GreaterThanOrEqualTo(new DateOnly(1890, 1, 1))
            .WithName(localizer.GetString("DateSortie"));
        RuleFor(film => film.Etoile).InclusiveBetween((byte)0, (byte)5)
            .WithName(localizer.GetString("Etoile"));
        RuleFor(film => film.Duree).InclusiveBetween(0, 400)
            .WithName(localizer.GetString("Duree"));
    }
}