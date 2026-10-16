List<string> latar = new List<string>();

while (true)
{
    Console.WriteLine("\n=== Spellista ===");
    Console.WriteLine("1. Lägg till låt");
    Console.WriteLine("2. Visa alla låtar");
    Console.WriteLine("3. Ta bort dubbletter");
    Console.WriteLine("4. Sök låtar efter första bokstaven");
    Console.WriteLine("5. Gör alla låttitlar till versaler");
    Console.WriteLine("6. Vänd ordningen på låtarna");
    Console.WriteLine("0. Avsluta");

    Console.Write("Välj ett alternativ: ");
    string val = Console.ReadLine() ?? "";

    if (val == "1")
    {
        Console.Write("Ange låtens titel: ");
        string titel = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(titel))
        {
            latar.Add(titel);
            Console.WriteLine("Låten har lagts till!");
        }
        else
        {
            Console.WriteLine("Titeln får inte vara tom.");
        }
    }
    else if (val == "2")
    {
        Console.WriteLine("\n=== Alla låtar ===");

        if (latar.Count > 0)
        {
            foreach (string lat in latar)
            {
                Console.WriteLine(lat);
            }
        }
        else
        {
            Console.WriteLine("Spellistan är tom.");
        }
    }
    else if (val == "3")
    {
        int antalFore = latar.Count;

        latar = latar
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        int antalBorttagna = antalFore - latar.Count;

        Console.WriteLine(
            $"{antalBorttagna} dubbletter har tagits bort."
        );
    }
    else if (val == "4")
    {
        Console.Write("Ange första bokstaven: ");
        string bokstav = Console.ReadLine() ?? "";

        if (bokstav.Length != 1 || !char.IsLetter(bokstav[0]))
        {
            Console.WriteLine("Du måste ange exakt en bokstav.");
        }
        else
        {
            List<string> hittadeLatar = latar.FindAll(
                lat => lat.StartsWith(
                    bokstav,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            Console.WriteLine("\n=== Hittade låtar ===");

            if (hittadeLatar.Count > 0)
            {
                foreach (string lat in hittadeLatar)
                {
                    Console.WriteLine(lat);
                }
            }
            else
            {
                Console.WriteLine("Inga låtar hittades.");
            }
        }
    }
    else if (val == "5")
    {
        latar = latar.ConvertAll(lat => lat.ToUpper());

        Console.WriteLine(
            "Alla låttitlar har ändrats till versaler!"
        );
    }
    else if (val == "6")
    {
        latar.Reverse();

        Console.WriteLine(
            "Ordningen på låtarna har vänts!"
        );
    }
    else if (val == "0")
    {
        Console.WriteLine("Programmet avslutas.");
        break;
    }
    else
    {
        Console.WriteLine("Ogiltigt alternativ.");
    }
}