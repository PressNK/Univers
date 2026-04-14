using Univers.Application.Dtos;

namespace Univers.Application.UseCases;

public interface IAjouterPersonnage
{
    int Execute(CreerPersonnageDto personnageDto);
}