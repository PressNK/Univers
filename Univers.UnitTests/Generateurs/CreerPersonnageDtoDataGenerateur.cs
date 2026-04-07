using Univers.Application.Dtos;

namespace Univers.UnitTests.Generateurs;
public class CreerPersonnageDtoDataGenerateur : TheoryData<CreerPersonnageDto>
{
    private readonly CreerPersonnageDtoGenerateur _generateur;

    public CreerPersonnageDtoDataGenerateur() 
    {
        _generateur = new CreerPersonnageDtoGenerateur();

        AddRange([.. _generateur.Generate(10)]);
    }
}