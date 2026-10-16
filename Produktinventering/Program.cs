List<Product> produkter = new List<Product>
{
    new Product
    {
        Name = "Mjölk",
        Price = 25,
        Category = "Mejeri"
    },
    new Product
    {
        Name = "Ost",
        Price = 85,
        Category = "Mejeri"
    },
    new Product
    {
        Name = "Bröd",
        Price = 35,
        Category = "Bageri"
    },
    new Product
    {
        Name = "Kaffe",
        Price = 70,
        Category = "Dryck"
    },
    new Product
    {
        Name = "Smör",
        Price = 55,
        Category = "Mejeri"
    }
};

// Visa alla produkter
Console.WriteLine("=== Alla produkter ===");

foreach (Product produkt in produkter)
{
    Console.WriteLine(
        $"{produkt.Name} - {produkt.Price} kr - {produkt.Category}"
    );
}

// Ta bort produkter under ett visst pris
Console.Write("\nAnge lägsta pris: ");

if (double.TryParse(Console.ReadLine(), out double minPris))
{
    int antalBorttagna = produkter.RemoveAll(
        produkt => produkt.Price < minPris
    );

    Console.WriteLine(
        $"{antalBorttagna} produkter har tagits bort."
    );

    Console.WriteLine("\n=== Produkter som finns kvar ===");

    foreach (Product produkt in produkter)
    {
        Console.WriteLine(
            $"{produkt.Name} - {produkt.Price} kr - {produkt.Category}"
        );
    }
}
else
{
    Console.WriteLine("Ogiltigt pris.");
}

// Gruppera produkter efter kategori
Console.WriteLine("\n=== Produkter grupperade efter kategori ===");

var grupper = produkter.GroupBy(
    produkt => produkt.Category
);

foreach (var grupp in grupper)
{
    Console.WriteLine($"\nKategori: {grupp.Key}");

    foreach (Product produkt in grupp)
    {
        Console.WriteLine(
            $"{produkt.Name} - {produkt.Price} kr"
        );
    }
}

// Sortera produkter efter pris
Console.WriteLine("\n=== Produkter sorterade efter pris ===");

List<Product> sorteradeProdukter = produkter
    .OrderBy(produkt => produkt.Price)
    .ToList();

foreach (Product produkt in sorteradeProdukter)
{
    Console.WriteLine(
        $"{produkt.Name} - {produkt.Price} kr"
    );
}

// Kontrollera att alla priser är positiva
Console.WriteLine("\n=== Kontrollera produktpriser ===");

bool allaPriserPositiva = produkter.All(
    produkt => produkt.Price > 0
);

if (allaPriserPositiva)
{
    Console.WriteLine("Alla produkter har positiva priser.");
}
else
{
    Console.WriteLine("Det finns produkter med ogiltiga priser.");
}
