using FluentValidation;
using Univers.Application.Dtos;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;
public class AjouterPersonnage : IAjouterPersonnage
{
    private readonly IPersonnageRepository _personnageRepository;
    private readonly IValidator<CreerPersonnageDto> _validateurPersonnage;

    public AjouterPersonnage(IPersonnageRepository personnageRepository,
        IValidator<CreerPersonnageDto> validateurPersonnage)
    {
        _personnageRepository = personnageRepository;
        _validateurPersonnage = validateurPersonnage;
    }

    public int Execute(CreerPersonnageDto personnageDto)
    {
        //Validations de CreerPersonnageDto ...
        _validateurPersonnage.ValidateAndThrow(personnageDto);

        Personnage personnage = new()
        {
            Nom = personnageDto.Nom,
            IdentiteReelle = personnageDto.IdentiteReelle,
            DateNaissance = personnageDto.DateNaissance,
            EstVilain = personnageDto.EstVilain,
            FranchiseId = personnageDto.FranchiseId,
        };

        _personnageRepository.Ajouter(personnage, enregistrer: true);
        
        return personnage.PersonnageId;
    }
}