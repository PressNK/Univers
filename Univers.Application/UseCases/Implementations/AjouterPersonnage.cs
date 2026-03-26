using Univers.Application.Dtos;
using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;
public class AjouterPersonnage : IAjouterPersonnage
{
    private readonly IPersonnageRepository _personnageRepository;

    public AjouterPersonnage(IPersonnageRepository personnageRepository)
    {
        _personnageRepository = personnageRepository;
    }

    public void Execute(CreerPersonnageDto personnageDto)
    {
        //Validations de CreerPersonnageDto ...

        Personnage personnage = new()
        {
            Nom = personnageDto.Nom,
            IdentiteReelle = personnageDto.IdentiteReelle,
            DateNaissance = personnageDto.DateNaissance,
            EstVilain = personnageDto.EstVilain,
            FranchiseId = personnageDto.FranchiseId,
        };
        
        _personnageRepository.Ajouter(personnage, enregistrer: true);
    }
}