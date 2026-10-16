List<Book> books = new List<Book>
{
    new Book { Title = "The Alchemist", Author = "Paulo Coelho", Year = 1988 },
    new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Year = 2008 },
    new Book { Title = "The Fault in Our Stars", Author = "John Green", Year = 2012 },
    new Book { Title = "The Midnight Library", Author = "Matt Haig", Year = 2020 },
    new Book { Title = "A Man Called Ove", Author = "Fredrik Backman", Year = 2012 }
};

Console.WriteLine("=== Alla böcker ===");

foreach (Book book in books)
{
    Console.WriteLine(
        $"{book.Title} - {book.Author} - {book.Year}"
    );
}

// Hitta böcker utgivna efter 2010
Console.WriteLine("\n=== Böcker utgivna efter 2010 ===");

List<Book> nyaBocker = books.FindAll(
    book => book.Year > 2010
);

foreach (Book book in nyaBocker)
{
    Console.WriteLine(
        $"{book.Title} - {book.Author} - {book.Year}"
    );
}
// Sortera böcker alfabetiskt efter titel
Console.WriteLine("\n=== Böcker sorterade alfabetiskt ===");

var sorteradeBocker = books.OrderBy(book => book.Title);

foreach (Book book in sorteradeBocker)
{
    Console.WriteLine(
        $"{book.Title} - {book.Author} - {book.Year}"
    );
}
// Kontrollera om det finns en bok av en viss författare
Console.WriteLine("\n=== Sök efter författare ===");

Console.Write("Ange författarens namn: ");
string forfattare = Console.ReadLine() ?? "";

bool finnsForfattare = books.Any(
    book => book.Author.Equals(
        forfattare,
        StringComparison.OrdinalIgnoreCase
    )
);

if (finnsForfattare)
{
    Console.WriteLine("Det finns en bok av den författaren!");
}
else
{
    Console.WriteLine("Det finns ingen bok av den författaren.");
}
