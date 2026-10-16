List<Uppgift> uppgifter = new List<Uppgift>();

while (true)
{
    Console.WriteLine("\n=== To-Do Manager ===");
    Console.WriteLine("1. Lägg till uppgift");
    Console.WriteLine("2. Visa alla uppgifter");
    Console.WriteLine("3. Markera uppgift som klar");
    Console.WriteLine("4. Ta bort klara uppgifter");
    Console.WriteLine("5. Ta bort dubbletter");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange uppgiftens titel: ");
        string titel = Console.ReadLine() ?? "";

        Uppgift nyUppgift = new Uppgift
        {
            Titel = titel,
            ÄrKlar = false
        };

        uppgifter.Add(nyUppgift);

        Console.WriteLine("Uppgiften har lagts till!");
    }
    else if (val == "2")
    {
        Console.WriteLine("\n=== Alla uppgifter ===");

        if (uppgifter.Count > 0)
        {
            uppgifter.ForEach(uppgift =>
                Console.WriteLine(
                    $"{uppgift.Titel} - Klar: {uppgift.ÄrKlar}"
                )
            );
        }
        else
        {
            Console.WriteLine("Det finns inga uppgifter.");
        }
    }
    else if (val == "3")
    {
        Console.Write("Ange titeln på uppgiften som är klar: ");
        string titel = Console.ReadLine() ?? "";

        Uppgift? hittadUppgift = uppgifter.Find(
            uppgift => uppgift.Titel.Equals(
                titel,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (hittadUppgift != null)
        {
            hittadUppgift.ÄrKlar = true;
            Console.WriteLine("Uppgiften är markerad som klar!");
        }
        else
        {
            Console.WriteLine("Uppgiften hittades inte.");
        }
    }
    else if (val == "4")
    {
        int antalBorttagna = uppgifter.RemoveAll(
            uppgift => uppgift.ÄrKlar == true
        );

        Console.WriteLine(
            $"{antalBorttagna} klara uppgifter har tagits bort."
        );
    }
    else if (val == "5")
    {
        int antalFöre = uppgifter.Count;

        var unikaTitlar = uppgifter
            .Select(uppgift => uppgift.Titel)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        List<Uppgift> unikaUppgifter = new List<Uppgift>();

        foreach (string titel in unikaTitlar)
        {
            Uppgift? hittadUppgift = uppgifter.Find(
                uppgift => uppgift.Titel.Equals(
                    titel,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (hittadUppgift != null)
            {
                unikaUppgifter.Add(hittadUppgift);
            }
        }

        uppgifter = unikaUppgifter;

        int antalBorttagna = antalFöre - uppgifter.Count;

        Console.WriteLine(
            $"{antalBorttagna} dubbletter har tagits bort."
        );
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
}