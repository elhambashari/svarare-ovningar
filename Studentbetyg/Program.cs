List<Student> students = new List<Student>
{
    new Student { Name = "Anna", Grade = 85, Passed = true },
    new Student { Name = "Erik", Grade = 45, Passed = false },
    new Student { Name = "Sara", Grade = 95, Passed = true },
    new Student { Name = "Ali", Grade = 70, Passed = true },
    new Student { Name = "Emma", Grade = 55, Passed = true }
};

// Visa alla studenter
Console.WriteLine("=== Alla studenter ===");

foreach (Student student in students)
{
    Console.WriteLine(
        $"{student.Name} - Betyg: {student.Grade} - Godkänd: {student.Passed}"
    );
}

// Hitta alla godkända studenter med FindAll()
Console.WriteLine("\n=== Godkända studenter ===");

List<Student> godkandaStudenter = students.FindAll(
    student => student.Passed == true
);

foreach (Student student in godkandaStudenter)
{
    Console.WriteLine(
        $"{student.Name} - Betyg: {student.Grade}"
    );
}

// Beräkna medelbetyg med Average()
Console.WriteLine("\n=== Medelbetyg ===");

double medelbetyg = students.Average(student => student.Grade);

Console.WriteLine($"Medelbetyg för alla studenter: {medelbetyg}");

// Sortera studenter efter betyg
Console.WriteLine("\n=== Studenter sorterade efter betyg ===");

students.Sort((student1, student2) =>
    student1.Grade.CompareTo(student2.Grade)
);

foreach (Student student in students)
{
    Console.WriteLine($"{student.Name} - Betyg: {student.Grade}");
}

// Visa de 3 bästa studenterna
Console.WriteLine("\n=== Topp 3 studenter ===");

var toppTre = students
    .OrderByDescending(student => student.Grade)
    .Take(3);

foreach (Student student in toppTre)
{
    Console.WriteLine($"{student.Name} - Betyg: {student.Grade}");
}