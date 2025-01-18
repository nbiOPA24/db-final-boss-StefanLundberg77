using ProjektDb;

DatabaseManager db = new DatabaseManager();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("'Jazzgossens MusikEmporium'");
    Console.WriteLine();
    Console.WriteLine("1. Shop.");
    Console.WriteLine("2. Log in.");
    Console.WriteLine("3. Register.");
    Console.WriteLine("4. View all users.");
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
            string shopChoice = Console.ReadLine();
            bool shopMenu = true;
            while (shopMenu)
            {
                if (shopChoice == "1")
                {
                    db.GetAllProducts();
                    break;
                }
                else if (shopChoice == "2")
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
                            string searchOptionChoice = "ArtistName";
                            Console.Write("Enter Artist name:"); // tex. sökning på första 3 bokstäver
                            string searchInput = Misc.ReadString().ToLower();
                            db.SearchProducts(searchOptionChoice, searchInput);
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
                else if (shopChoice == "3")
                {

                }
                else if (shopChoice == "4")
                {

                }
                else if (shopChoice == "5")
                {

                }
                else if (shopChoice == "6")
                {
                    shopMenu = false;
                }
                else if (shopChoice == "7")
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
            Misc.LogIn();
            Console.WriteLine("1. View profile.");
            Console.WriteLine("2. Edit profile.");
            Console.WriteLine("3. Back.");
            Console.WriteLine("4. Exit.");
            int logInMenuChoice = Misc.ReadInt();
            bool logInMenu = true;
            while (logInMenu)
            {
                if (logInMenuChoice == 1)
                {

                }
                else if (logInMenuChoice == 2)
                {
                    Console.WriteLine();
                }
                else if (logInMenuChoice == 3)
                { }
                else if (logInMenuChoice == 4)
                { }

            }


            break;

        case "3":

            // Lägg till en ny user
            // Läsa in relevant input från user
            Console.Write("Insert first name: ");
            string firstName = Misc.ReadString().ToLower();

            Console.Write("Insert last name: ");
            string lastName = Misc.ReadString().ToLower();

            Console.Write("Insert address: ");
            string address = Misc.ReadString().ToLower(); // commit to lower.. dvs piff

            Console.Write("Insert zip code: ");
            string zipCode = Console.ReadLine().ToLower();

            Console.Write("Insert City: ");
            string city = Console.ReadLine().ToLower();

            Console.Write("Insert country: ");
            string country = Console.ReadLine().ToLower();

            Console.Write("Insert Date of birth (yyyy-MM-dd): "); // lägg till try catch för omvandling
            DateTime birthDate = Misc.ReadDate();

            Console.Write("Insert email: ");
            string email = Console.ReadLine().ToLower();

            Console.Write("Select username: ");
            string username = Console.ReadLine();

            Console.Write("Select password: ");
            string password = Misc.ReadString();

            (byte[] passwordHash, byte[] passwordSalt) = Misc.PasswordEncryption(password);

            db.AddUser(firstName, lastName, address, zipCode, city, country, birthDate, email, username, passwordHash, passwordSalt);
            break;

        case "4":
            db.GetAllUsers();
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


