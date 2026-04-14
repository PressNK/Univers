using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;

public class ObtenirPersonnage : IObtenirPersonnage
{
    private readonly IPersonnageRepository _personnageRepository;

    public ObtenirPersonnage(IPersonnageRepository personnageRepository)
    {
        _personnageRepository = personnageRepository;
    }

    public Personnage Execute(int personnageId)
    {
        return _personnageRepository.Obtenir(personnageId);
    }
}