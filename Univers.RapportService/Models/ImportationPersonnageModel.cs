using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Univers.Domain.Entities.Importations;

namespace Univers.RapportService.Models;
public class ImportationPersonnageModel
{
    public string Nom { get; set; }

    public bool EstVilain { get; set; }

    public string FranchiseNom { get; set; }

    public DateTime? DateNaissance { get; set; }

    public ImportationPersonnage VersEntite() 
    {
        return new ImportationPersonnage(Nom, EstVilain, FranchiseNom, DateNaissance);
    }
}

public class ImportationPersonnageMapper : ClassMap<ImportationPersonnageModel>
{
    public ImportationPersonnageMapper()
    {
        Map(m => m.Nom).Name("Nom");
        Map(m => m.EstVilain).Name("Est un vilain");
        Map(m => m.FranchiseNom).Name("Nom de la franchise");
        Map(m => m.DateNaissance).Name("Date de naissance").TypeConverter<DateConvertisseur>();
    }
}

public class DateConvertisseur : DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text)) 
        {
            return null;
        }

        if(DateTime.TryParseExact(text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)) 
        {
            return date;
        }
        else 
        {
            return null;
        }
    }
}