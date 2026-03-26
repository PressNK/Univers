using Univers.Application.Dtos;
using Univers.Domain.Entities;

namespace Univers.Application.UseCases;

public interface IVenteFranchise
{
    StatutVenteFranchise Execute(int franchiseId, string nomProprietaire);
}