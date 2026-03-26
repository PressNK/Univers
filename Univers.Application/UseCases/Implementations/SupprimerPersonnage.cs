using Univers.Domain.Entities;
using Univers.Domain.Repositories;

namespace Univers.Application.UseCases.Implementations;

public class SupprimerPersonnage : ISupprimerPersonnage
{
        private readonly IPersonnageRepository _personnageRepository;
    
        public SupprimerPersonnage(IPersonnageRepository personnageRepository)
        {
            _personnageRepository = personnageRepository;
        }
    
        public StatutSuppression Execute(int personnageId)
        {
            var personnage = _personnageRepository.Chercher(personnageId);
            if (personnage == null)
            {
                return  StatutSuppression.NoData;
            }
            try
            {
                _personnageRepository.Supprimer(personnage, enregistrer: true);
                return StatutSuppression.Completed;
            }
            catch
            {
                return StatutSuppression.Failed;
            }
        }
}