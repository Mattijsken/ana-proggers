using KrokusTaak.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace KrokusTaak
{
    public class AppCommands
    {
        public WerknemerBestand werknemerRepo = new WerknemerBestand();
        public KlantenBestand klantenRepo = new KlantenBestand();
        public ReceptenBestand ReceptenRepo = new ReceptenBestand();
        public BestellingBestand bestellingenRepo = new BestellingBestand();
        public DrankenBestand drankenRepo = new DrankenBestand();

        public bool Execute(string input)
        {
            bool doExit = false;
            try
            {
                string[] args = input?.Split(' ') ?? new string[] { };
                if (args.Length > 0)
                {
                    switch (args[0]?.ToLower().Trim())
                    {
                        case "exit": //Het programma beëindigen
                        case "stop":
                            Console.WriteLine("Stopping...");
                            Thread.Sleep(600);
                            doExit = true;
                            break;
                        case "help": //Alle commando's weergeven
                            showHelp();
                            break;
                        case "exportcsv": //Exporteren naar CSV
                            ExportToCSV();
                            break;
                        case "importcsv": //Importeren naar CSV
                            ImportFromCSV();
                            break;
                        case "clear": //Console leegmaken
                            Console.Clear();
                            break;
                        case "addw": //Werknemer toevoegen    
                            addWerknemer();
                            break;
                        case "removew": //Werknemer verwijderen
                            removeWerknemer();
                            break;
                        case "addk": //Klant toevoegen
                            addKlant();
                            break;
                        case "removek": //Klant verwijderen
                            removeKlant();
                            break;
                        case "werknemers": //Werknemers printen
                            printWerknemers();
                            break;
                        case "klanten": //Klanten printen
                            printKlanten();
                            break;
                        case "addr": //Recept toevoegen
                            addRecept();
                            break;
                        case "remover": //Recept verwijderen
                            removeRecept();
                            break;
                        case "recepten": //Recepten printen
                            printRecepts();
                            break;
                        case "addb": //Bestelling plaatsen
                            addBestelling();
                            break;
                        case "removeb": //Bestelling verwijderen
                            removeBestelling();
                            break;
                        case "bestellingen": //Bestellingen printen
                            printBestellingen();
                            break;
                        case "addd": //Drank toevoegen
                            addDrank();
                            break;
                        case "removed": //Drank verwijderen
                            removeDrank();
                            break;
                        case "dranken": //Dranken printen
                            printDranken();
                            break;
                        case "menu": //Menu printen
                            printMenu();
                            break;
                        default:
                            Console.WriteLine("Onbekend commando.");
                            break;
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
            return doExit;
        }

        private void printMenu()
        {
            Console.WriteLine("\nMenu : ");
            Console.WriteLine("\n\tDranken : \n");
            foreach (Drank drank in drankenRepo.alleDranken)
            {
                Console.WriteLine($"\t\t{drank.Naam}");
            }
            Console.WriteLine("\n\tMaaltijden : \n");
            foreach (Recept recept in ReceptenRepo.alleRecepten)
            {
                Console.WriteLine($"\t\t{recept.Naam}");
            }
        }

        private void ExportToCSV()
        {

            CSVHandler.GenerateCSVFromList(this.werknemerRepo.alleWerknemers, Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Werknemers.csv");
            CSVHandler.GenerateCSVFromList(this.ReceptenRepo.alleRecepten, Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Recepten.csv");
            CSVHandler.GenerateCSVFromList(this.klantenRepo.alleKlanten, Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Klanten.csv");
          
        }

        private void ImportFromCSV()
        {
            
            foreach (var werknemer in CSVHandler.FromCSVToList<Werknemer>(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Werknemers.csv"))
            {
                this.werknemerRepo.Add(werknemer);
            }

            foreach (var recept in CSVHandler.FromCSVToList<Recept>(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Recepten.csv"))
            {
                this.ReceptenRepo.Add(recept);
            }

            foreach (var klant in CSVHandler.FromCSVToList<Klant>(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\CSV\output\", "Klanten.csv"))
            {
                this.klantenRepo.Add(klant);
            }
        }

        private void printDranken()
        {
            foreach (Drank drank in drankenRepo.alleDranken)
            {
                Console.WriteLine($@"
Naam : {drank.Naam}
Type : {drank.DrankType}");
            }
        }

        private void removeDrank()
        {
            Drank deleteD = new Drank();
            Console.Write("Naam drank : ");
            drankenRepo.alleDranken.Remove(drankenRepo.Find(Console.ReadLine()));
            Console.WriteLine("Drank is verwijderd uit het bestand.");
        }

        private void addDrank()
        {
            Drank nieuweD = new Drank();
            Console.Write("Naam drank : ");
            nieuweD.Naam = Console.ReadLine();

            bool valid = false;
            while (valid == false)
            {
                Console.Write("Dranktype (Frisdrank, Alcoholisch, Water) : ");
                string inputtype = Console.ReadLine();
                if (inputtype == "Frisdrank")
                {
                    nieuweD.DrankType = Drank.DrankTypes.Frisdrank;
                    valid = true;
                    break;
                }
                else if (inputtype == "Alcoholisch")
                {
                    nieuweD.DrankType = Drank.DrankTypes.Alcoholisch;
                    valid = true;
                    break;
                }
                else if (inputtype == "Warm")
                {
                    nieuweD.DrankType = Drank.DrankTypes.Warm;
                    valid = true;
                    break;
                }
                else if (inputtype == "Water")
                {
                    nieuweD.DrankType = Drank.DrankTypes.Water;
                    valid = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Dit is geen geldig type drank.");
                    valid = false;
                }
            }
            drankenRepo.alleDranken.Add(nieuweD);
        }

        private void printBestellingen()
        {
            foreach (Bestelling bestelling in bestellingenRepo.alleBestellingen)
            {
                Console.WriteLine($@"
ID : {bestelling.ID}
Naam : {bestelling.Naam} "
);
            }
        }

        private void removeBestelling()
        {
            Bestelling DeleteB = new Bestelling();
            Console.Write("Bestelling ID : ");
            string DeleteID = Console.ReadLine();
            bestellingenRepo.Remove(bestellingenRepo.Find(Convert.ToInt32(DeleteID)));
            Console.WriteLine($"Bestelling {DeleteID} is verwijderd.");
        }

        private void showHelp()
        {
            Console.WriteLine(@"

Commands :

exit            - Stop het programma.
clear           - Maak de console leeg.

werknemers      - Geeft alle werknemers weer.
addw            - Voegt een werknemer toe aan het bestand.
removew         - Verwijdert een werknemer van het bestand.

klanten         - Geeft alle klanten weer.
addk            - Voegt een klant toe aan het bestand.
removek         - Verwijdert een klant van het bestand.

recepten        - Geeft alle recepten weer.
addr            - Voegt een recept toe aan het bestand.
remover         - Verwijdert een recept van het bestand.

bestellingen    - Geeft alle bestellingen weer.
addb            - Creëert een nieuwe bestelling.
remover         - Verwijdert een bestelling van het bestand.

exportcsv       - Schrijft alle gegevens weg naar CSV bestanden.
importcsv       - Laadt alle gegevens van een CSV bestand.

");
        }

        private void removeRecept()
        {
            Recept DeleteR = new Recept();
            Console.Write("Naam recept : ");
            string deleteRecept = Console.ReadLine();
            ReceptenRepo.Remove(ReceptenRepo.Find(deleteRecept));
        }

        private void removeKlant()
        {
            Klant DeleteK = new Klant();
            Console.Write("Achternaam klant : ");
            string deleteKlant = Console.ReadLine();
            klantenRepo.Remove(klantenRepo.Find(deleteKlant));
        }

        private void removeWerknemer()
        {
            Werknemer DeleteW = new Werknemer();
            Console.WriteLine("Achternaam werknemer : ");
            string deleteWerknemer = Console.ReadLine();
            werknemerRepo.Remove(werknemerRepo.Find(deleteWerknemer));
        }

        private void addBestelling()
        {
            Bestelling nieuweB = new Bestelling();
            Console.Write("Naam gerecht : ");
            nieuweB.Naam = Console.ReadLine();

            int recept = ReceptenRepo.alleRecepten.FindIndex(r => r.Naam == nieuweB.Naam);

            if (recept >= 0)
            {
                bestellingenRepo.alleBestellingen.Add(nieuweB);
                nieuweB.ID = bestellingenRepo.alleBestellingen.Count;
                Console.WriteLine($"Bestelling {nieuweB.ID} is toegevoegd.");
            }
            else
            {
                Console.WriteLine("Dit is geen geldig gerecht");
            }
        }

        private void printRecepts()
        {
            foreach (Recept recept in ReceptenRepo.alleRecepten)
            {
                Console.WriteLine($@"
Naam        :    {recept.Naam} 
Type        :    {recept.ReceptType.ToString()} 
Werkwijze   :    {recept.Werkwijze}");
                Console.WriteLine("\nIngrediënten: ");
                foreach (var ingrediënt in recept.Ingredients)
                {
                    Console.WriteLine($"- {ingrediënt.Name}");
                }
            }
        }

        private void addRecept()
        {
            Recept nieuweR = new Recept();
            Console.Write("Naam : ");
            nieuweR.Naam = Console.ReadLine();
            bool valid = false;
            while (valid == false)
            {
                Console.Write("Recepttype : ");
                string inputType = Console.ReadLine();
                if (inputType == "Voorgerecht")
                {
                    nieuweR.ReceptType = Recept.ReceptTypes.Voorgerecht;
                    valid = true;
                    break;
                }
                else if (inputType == "Soep")
                {
                    nieuweR.ReceptType = Recept.ReceptTypes.Soep;
                    valid = true;
                    break;
                }
                else if (inputType == "Hoofdgerecht")
                {
                    nieuweR.ReceptType = Recept.ReceptTypes.Hoofdgerecht;
                    valid = true;
                    break;
                }
                else if (inputType == "Dessert")
                {
                    nieuweR.ReceptType = Recept.ReceptTypes.Dessert;
                    valid = true;
                    break;
                }
                else
                    Console.WriteLine("Onbekend recepttype.");
                valid = false;
            }
            Console.Write("Ingrediënten : ");
            string input = Console.ReadLine();
            string[] ingredients = input.Split(',');
            nieuweR.Ingredients = new List<Ingredient>();
            foreach (var ingredient in ingredients)
            {
                Ingredient ingrediëntToAdd = new Ingredient();
                ingrediëntToAdd.Name = ingredient;
                nieuweR.Ingredients.Add(ingrediëntToAdd);
            }
            Console.Write("Werkwijze : ");
            nieuweR.Werkwijze = Console.ReadLine();
            ReceptenRepo.alleRecepten.Add(nieuweR);
        }

        private void printKlanten()
        {
            foreach (Klant klant in klantenRepo.alleKlanten)
            {
                Console.WriteLine($@"
Naam        :    {klant.AchterNaam}, {klant.VoorNaam}
Adres       :    {klant.Adres}
Email       :    {klant.Email}
Telefoon    :    {klant.Telefoon}
Korting     :    {klant.KortingsCode}");

                Console.WriteLine("\nAllergieën  :");
                foreach (var a in klant.Allergieen)
                {
                    Console.WriteLine($"- {a.Name.ToUpper()}");
                }
            }
        }

        private void printWerknemers()
        {
            foreach (Werknemer werknemer in werknemerRepo.alleWerknemers)
            {
                Console.WriteLine($@"
Naam        :    {werknemer.AchterNaam}, {werknemer.VoorNaam}
Adres       :    {werknemer.Adres}
Email       :    {werknemer.Email}
Telefoon    :    {werknemer.Telefoon}");
            }
        }

        private void addKlant()
        {
            Klant nieuweK = new Klant();
            Console.Write("Voornaam : ");
            nieuweK.VoorNaam = Console.ReadLine();
            Console.Write("Achternaam : ");
            nieuweK.AchterNaam = Console.ReadLine();
            Console.Write("Adres : ");
            nieuweK.Adres = Console.ReadLine();
            Console.Write("Email : ");
            nieuweK.Email = Console.ReadLine();
            Console.Write("Telefoon : ");
            nieuweK.Telefoon = Console.ReadLine();
            Console.Write("Allergieën : ");

            nieuweK.Allergieen = new List<Ingredient>();
            string allergieinput = Console.ReadLine();
            string[] allergieën = allergieinput.Split(',');

            foreach (var allergie in allergieën)
            {
                Ingredient allergieToAdd = new Ingredient();
                allergieToAdd.Name = allergie;
                nieuweK.Allergieen.Add(allergieToAdd);
            }

            Console.Write("Korting : ");
            nieuweK.KortingsCode = Console.ReadLine();
            klantenRepo.alleKlanten.Add(nieuweK);
        }

        private void addWerknemer()
        {
            Werknemer nieuweW = new Werknemer();
            Console.Write("Voornaam : ");
            nieuweW.VoorNaam = Console.ReadLine();
            Console.Write("Achternaam : ");
            nieuweW.AchterNaam = Console.ReadLine();
            Console.Write("Adres : ");
            nieuweW.Adres = Console.ReadLine();
            Console.Write("Email : ");
            nieuweW.Email = Console.ReadLine();
            Console.Write("Telefoon : ");
            nieuweW.Telefoon = Console.ReadLine();
            werknemerRepo.alleWerknemers.Add(nieuweW);
        }
    }
}