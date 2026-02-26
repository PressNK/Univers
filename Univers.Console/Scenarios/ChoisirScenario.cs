using System;
namespace Univers.Console.Scenarios;

public class ChoisirScenario
{
    public int RecupererScenario()
    {
        int optionChoisie = -1;
        do
        {
            System.Console.WriteLine("Veuillez entrer un chiffre positif. Si vous voulez quitter, entrez 0");
            string? optionChoisieATraiter = System.Console.ReadLine();
            if (string.IsNullOrEmpty(optionChoisieATraiter) || !int.TryParse(optionChoisieATraiter, out optionChoisie))
            {
                System.Console.WriteLine("Veuillez entrer un chiffre");
            }

        } while (optionChoisie < 0);
        
        return optionChoisie;
    }
}