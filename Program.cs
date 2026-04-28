using System.Globalization;

namespace HeurePourAssistantVocal;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Saisissez l'heure au format HH:MM :");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                Console.WriteLine(TraduireHeure(time));
                break;
            }

            Console.WriteLine("Format invalide. Exemple : 07:00");
        }
    }

    static string TraduireHeure(DateTime dateTime)
    {
        int heure = dateTime.Hour;
        int minute = dateTime.Minute;

        if (heure == 0 && minute == 0)
            return "minuit";

        if (heure == 12 && minute == 0)
            return "midi";

        if (minute == 0)
            return NomHeure(heure) + PeriodeJour(heure);

        if (minute == 15)
            return NomHeure(heure) + " et quart" + PeriodeJour(heure);

        if (minute == 30)
            return NomHeure(heure) + " et demie" + PeriodeJour(heure);

        if (minute == 45)
            return NomHeure(heure) + " moins le quart" + PeriodeJour(heure);

        if (minute == 50)
            return NomHeure(heure) + " moins dix" + PeriodeJour(heure);

        if (minute == 55)
            return NomHeure(heure) + " moins cinq" + PeriodeJour(heure);

        if (minute < 45)
            return NomHeure(heure) + " " + NomMinute(minute) + PeriodeJour(heure);


        int minutesRestantes = 60 - minute;
        int prochainHeure = (heure + 1) % 24;

        if (minutesRestantes == 15)
            return NomHeure(prochainHeure) + " moins le quart" + PeriodeJour(prochainHeure);

        return NomHeure(prochainHeure) + " moins " + NomMinute(minutesRestantes) + PeriodeJour(prochainHeure);
    }

    static string NomHeure(int heure)
    {
        return heure switch
        {
            0 => "minuit",
            1 => "une heure",
            2 => "deux heures",
            3 => "trois heures",
            4 => "quatre heures",
            5 => "cinq heures",
            6 => "six heures",
            7 => "sept heures",
            8 => "huit heures",
            9 => "neuf heures",
            10 => "dix heures",
            11 => "onze heures",
            12 => "midi",
            13 => "une heure",
            14 => "deux heures",
            15 => "trois heures",
            16 => "quatre heures",
            17 => "cinq heures",
            18 => "six heures",
            19 => "sept heures",
            20 => "huit heures",
            21 => "neuf heures",
            22 => "dix heures",
            23 => "onze heures",
            _ => "inconnu"
        };
    }

    static string NomMinute(int minute)
    {
        string[] nombres = new string[]
        {
            "zéro", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf",
            "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf",
            "vingt", "vingt-et-un", "vingt-deux", "vingt-trois", "vingt-quatre", "vingt-cinq", "vingt-six", "vingt-sept", "vingt-huit", "vingt-neuf",
            "trente", "trente-et-un", "trente-deux", "trente-trois", "trente-quatre", "trente-cinq", "trente-six", "trente-sept", "trente-huit", "trente-neuf",
            "quarante", "quarante-et-un", "quarante-deux", "quarante-trois", "quarante-quatre", "quarante-cinq", "quarante-six", "quarante-sept", "quarante-huit", "quarante-neuf",
            "cinquante", "cinquante-et-un", "cinquante-deux", "cinquante-trois", "cinquante-quatre", "cinquante-cinq", "cinquante-six", "cinquante-sept", "cinquante-huit", "cinquante-neuf"
        };

        if (minute >= 0 && minute < nombres.Length)
            return nombres[minute];

        return "inconnu";
    }

    static string PeriodeJour(int heure)
    {
        if (heure == 0 || heure == 12)
            return "";

        if (heure < 12)
            return " du matin";
        
        if (heure < 18)
        return " de l'après-midi";

        return " du soir";
    }
}