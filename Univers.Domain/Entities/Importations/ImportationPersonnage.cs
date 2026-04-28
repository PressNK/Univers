namespace Univers.Domain.Entities.Importations;
public class ImportationPersonnage
{
    public ImportationPersonnage(string nom, bool estVilain, string franchiseNom, DateTime? dateNaissance)
    {
        Nom = nom;
        EstVilain = estVilain;
        FranchiseNom = franchiseNom;
        DateNaissance = dateNaissance;
    }

    public string Nom { get; set; }

    public bool EstVilain { get; set; }

    public string FranchiseNom { get; set; }

    public DateTime? DateNaissance { get; set; }
}