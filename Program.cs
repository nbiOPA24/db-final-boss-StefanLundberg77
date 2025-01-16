namespace ProjektDb;
class Program
{
    static void Main()
    {
        DatabaseManager db = new DatabaseManager();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("'Jazzgossens MusikEmporium'");
            Console.WriteLine();
            Console.WriteLine("1. Shop.");
            Console.WriteLine("2. Log in.");
            Console.WriteLine("3. Register.");
            Console.WriteLine("5. Add product."); // skapa adminläge eller en adminmeny?
            Console.WriteLine("6. Delete produkt.");
            Console.WriteLine("7. Add Campaign.");
            Console.WriteLine("8. Exit.");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Console.WriteLine("1. View all products.");
                    Console.WriteLine("2. Search products.");
                    Console.WriteLine("3. Sort by.");
                    Console.WriteLine("4. Purchase.");
                    Console.WriteLine("5. Sell.");
                    Console.WriteLine("6. Back.");
                    Console.WriteLine("7. Exit.");
                    // tba menyval köpa, söka, visa alla, sortera
                    string input = Console.ReadLine();
                    bool shopMenu = true;
                    while (shopMenu)
                    {
                        if (input == "1")
                        {
                            db.GetAllProducts();
                            //break;
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Search by:");
                            Console.WriteLine("1. Artist.");
                            Console.WriteLine("2. Album.");
                            Console.WriteLine("3. Record Company.");
                            Console.WriteLine("4. Format.");
                            Console.WriteLine("5. Used.");
                            Console.WriteLine("6. Back.");
                            Console.WriteLine("7. Exit.");
                            string searchOption = Console.ReadLine();
                            bool searchMenu = true;
                            while (searchMenu)
                            {
                                if (searchOption == "1")
                                {
                                    Console.Write("Enter Artist name:"); // tex. sökning på första 3 bokstäver
                                    db.SearchProducts();
                                }
                                else if (searchOption == "2")
                                {

                                }
                                else if (searchOption == "3")
                                {

                                }
                                else if (searchOption == "4")
                                {

                                }
                                else if (searchOption == "5")
                                {

                                }
                                else if (searchOption == "6")
                                {
                                    searchMenu = false;
                                }
                                else if (searchOption == "7")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice");
                                }
                            }
                        }
                        else if (input == "3")
                        {

                        }
                        else if (input == "4")
                        {

                        }
                        else if (input == "5")
                        {

                        }
                        else if (input == "6")
                        {
                            shopMenu = false;
                        }
                        else if (input == "7")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                    }
                    break;
                case "2":
                    // search by ex. artistname
                    break;

                case "3":

                    // Lägg till en ny user
                    // Läsa in relevant input från user
                    Console.Write("Insert first name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Insert last name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Insert address: ");
                    string address = Console.ReadLine();

                    Console.Write("Insert zip code: ");
                    string zipCode = Console.ReadLine();

                    Console.Write("Insert country: ");
                    string country = Console.ReadLine();

                    Console.Write("Insert Date of birth (yyyy-MM-dd): "); // lägg till try catch för omvandling
                    DateOnly birthDate = Misc.ReadDate();

                    Console.Write("Insert email: ");
                    string email = Console.ReadLine();

                    Console.Write("Select username: ");
                    string username = Console.ReadLine();

                    Console.Write("Select password: ");
                    string password = Console.ReadLine();

                    db.AddUser(firstName, lastName, address, zipCode, birthDate, country, email, username, password);
                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":
                    break;

                case "7":

                    break;

                case "":

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


