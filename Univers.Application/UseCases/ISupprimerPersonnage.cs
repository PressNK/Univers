using Univers.Application.Dtos;
using Univers.Domain.Entities;

namespace Univers.Application.UseCases;

public interface ISupprimerPersonnage
{
    StatutSuppression Execute(int personnageId);
}