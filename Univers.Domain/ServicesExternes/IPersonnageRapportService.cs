using Univers.Domain.Entities.Importations;

namespace Univers.Domain.ServicesExternes;
public interface IPersonnageRapportService
{
    List<ImportationPersonnage> ExtrairePersonnages(string cheminDuFichier);
}