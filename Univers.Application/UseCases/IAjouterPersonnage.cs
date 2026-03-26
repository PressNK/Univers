using Univers.Application.Dtos;

namespace Univers.Application.UseCases;

public interface IAjouterPersonnage
{
    void Execute(CreerPersonnageDto personnageDto);
}