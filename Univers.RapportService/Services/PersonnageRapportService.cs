using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using Univers.Domain.Entities.Importations;
using Univers.Domain.ServicesExternes;
using Univers.RapportService.Models;

namespace Univers.RapportService.Services;
public class PersonnageRapportService : IPersonnageRapportService
{
    private readonly static CsvConfiguration _config = new(CultureInfo.GetCultureInfo("fr-CA")); // fr-CA est pour forcer le séparateur ;
    
    public List<ImportationPersonnage> ExtrairePersonnages(string cheminDuFichier) 
    {
        using var lecteurDeFichier = new StreamReader(cheminDuFichier);
        using var lecteurCsv = new CsvReader(lecteurDeFichier, _config);

        lecteurCsv.Context.RegisterClassMap<ImportationPersonnageMapper>();
        IEnumerable<ImportationPersonnageModel> importationPersonnages = lecteurCsv.GetRecords<ImportationPersonnageModel>();

        return importationPersonnages.Select(x => x.VersEntite()).ToList();
    }
}