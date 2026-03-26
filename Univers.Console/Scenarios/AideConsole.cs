using System.Globalization;

namespace Univers.Console.Scenarios;
internal class AideConsole
{
    public static DateOnly DemanderDate(string message)
    {
        DateOnly? dateNaissance = null;
        do
        {
            System.Console.Write(message);
            if (DateOnly.TryParseExact(
                    System.Console.ReadLine(),
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateOnly dateNaissanceUtilisateur))
            {
                dateNaissance = dateNaissanceUtilisateur;
            }
            else
            {
                System.Console.WriteLine("Format de date invalide. Veuillez réessayer.");
            }
        } while (!dateNaissance.HasValue);

        return dateNaissance.Value;
    }
    
    public static string? DemanderString(string message, bool needValue)
    {
        string? result;

        if (needValue)
        {
            do
            {
                System.Console.Write(message);
                result = System.Console.ReadLine()?.Trim() ?? string.Empty;
            } while (string.IsNullOrEmpty(result));
        }
        else
        {
            var r = System.Console.ReadLine()?.Trim();
            result = string.IsNullOrEmpty(r) ? null : r;
        }
        
        return result;
    }

    public static bool DemanderBooleen(string message)
    {
        bool? estVilain = null;
        do
        {
            System.Console.Write(message);
            string? reponse = System.Console.ReadLine()?.Trim().ToUpper();

            if (reponse == "O" || reponse == "OUI")
            {
                estVilain = true;
            }
            else if (reponse == "N" || reponse == "NON")
            {
                estVilain = false;
            }
            else
            {
                System.Console.WriteLine("Veuillez répondre par O ou N.");
            }
        } while (!estVilain.HasValue);

        return estVilain.Value;
    }

    public static int DemanderEntier(string message)
    {
        bool idValide;
        int franchiseId;
        do
        {
            System.Console.Write(message);
            idValide = int.TryParse(System.Console.ReadLine(), out franchiseId);

            if (!idValide || franchiseId <= 0)
            {
                System.Console.WriteLine("L'ID doit être un nombre entier positif. Veuillez réessayer.");
            }
        } while (!idValide);

        return franchiseId;
    }
    
    public static short DemanderShort(string message)
    {
        bool idValide;
        short franchiseId;
        do
        {
            System.Console.Write(message);
            idValide = short.TryParse(System.Console.ReadLine(), out franchiseId);

            if (!idValide || franchiseId <= 0)
            {
                System.Console.WriteLine("L'ID doit être un nombre entier positif. Veuillez réessayer.");
            }
        } while (!idValide);

        return franchiseId;
    }
}