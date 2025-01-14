namespace SkolProjekt;
class Program
{
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Välkommen till Jazzgossens MusikEmporuim");
            Console.WriteLine();
            Console.WriteLine("1. Visa produkter.");
            Console.WriteLine("2. köp & sälj.");
            Console.WriteLine("3. Logga in.");
            Console.WriteLine("4. Registrera dig.");
            Console.WriteLine("5. Lägg till produkt.");
            Console.WriteLine("6. Ta bort produkt.");
            Console.WriteLine("7. Avsluta.");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":
                    break;

                case "7":

                    return;

                default:

                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
