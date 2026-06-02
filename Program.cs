// Velkomstbeskjed
Console.WriteLine("Velkommen til butikken! Vi har disse produktene:   ");

// matvare : rabattprosent : pris (kr)
object[,] produkter = new object[3, 3] { { "ost", 1.0, 50 }, { "skinke", 0.9, 35 }, { "brød", 0.7, 20 } };

bool ferdigÅHandle = false;

// Liste for brukerens handlekurv
List<string> handlekurv = new List<string> { };

// Setter opp en loop for å handle som kun brytes når ferdigÅHandle endres
while (!ferdigÅHandle)
{
    Console.Clear();

    // Viser alle produktene butikken har til brukeren
    for (int index = 0; index < produkter.GetLength(0); index++)
    {
        Console.Write($"{index + 1}:");
        Console.WriteLine(produkter[index, 0]);
    }
    // Lar brukeren legge til produkter i handlekurven
    Console.WriteLine("Legg et produkt i handlekurven. Velg ved å skrive tallet ved siden av produktet:     ");
    int valg = int.Parse(Console.ReadLine()!) - 1;
    handlekurv.Add((string)produkter[valg, 0]);

    // Viser brukeren hva som er i handlekurven
    Console.WriteLine("I handlekurven: ");
    handlekurv.ForEach(Console.WriteLine);

    // Sjekker om brukeren vil handle mer
    Console.WriteLine("Er du ferdig å handle? 'ja' eller 'nei' :     ");
    string ferdig = Console.ReadLine()!;
    if (ferdig == "ja")
        ferdigÅHandle = true;
}
// Legger sammen produktene i handlekurven og sjekker opp mot prisene og rabattene i produkter-arrayet
double kalkulerPris()
{
    double total = 0;
    foreach (string ting in handlekurv)
    {
        for (int i = 0; i < produkter.GetLength(0); i++)
        {
            if ((string)produkter[i, 0] == ting)
            {
                var prisMedRabatt = (int)produkter[i, 2] * (double)produkter[i, 1];
                total += prisMedRabatt;
            }
        }

    }
    return total;
}

// Gir totalprisen til brukeren
Console.WriteLine($"Totalen din blir kr {kalkulerPris()},-");