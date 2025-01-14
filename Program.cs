namespace SkolProjekt;
class Program
{
    static void Main()
    {
        DatabaseManager db = new DatabaseManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("'Jazzgossens MusikEmporuim'");
            Console.WriteLine();
            Console.WriteLine("1. Show products.");
            Console.WriteLine("2. Log in.");
            Console.WriteLine("3. Register.");
            Console.WriteLine("4. Buy & sell."); 
            Console.WriteLine("5. Add product."); // skapa adminläge
            Console.WriteLine("6. Delete produkt.");
            Console.WriteLine("7. Add Campain.");
            Console.WriteLine("8. Exit.");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    db.GetAllProducts();

                    // tba menyval köpa, söka, visa alla

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
                    break;

                case "8":

                    return;

                default:

                    Console.WriteLine("Invalid choice");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
