using Univers.Domain.Entities;

namespace Univers.Application.UseCases.Implementations;

public interface IObtenirPersonnage
{
    public Personnage Execute(int personnageId);
}