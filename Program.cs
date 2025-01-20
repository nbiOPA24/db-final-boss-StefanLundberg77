namespace ProjektDb; // using namespace ? va i hela
class Program
{
    public static DatabaseManager db = new DatabaseManager();
    public static string? userLoggedIn = null;
    public static bool userLoggedInIsAdmin = false;
    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("'Jazzgossens MusikEmporium'");
            Console.WriteLine();
            Console.WriteLine("1. Shop");
            Console.WriteLine("2. Profile (Register, log in or manage account)");
            if (userLoggedIn != null && userLoggedInIsAdmin)
            {
                Console.WriteLine("3. ?");
                Console.WriteLine("4. View all users");
                Console.WriteLine("5. Add product"); // skapa adminläge eller en adminmeny?
                Console.WriteLine("6. Delete produkt");
                Console.WriteLine("7. Discounts");
                Console.WriteLine("8. Manage orders");
            }
            Console.WriteLine("Q. Exit");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "1":

                    bool shopMenu = true;
                    while (shopMenu)
                    {
                        Console.WriteLine();
                        Console.WriteLine("'Shop Menu'");
                        Console.WriteLine("1. View all products");
                        Console.WriteLine("2. Search products");
                        Console.WriteLine("3. Sort by");
                        Console.WriteLine("4. Purchase");
                        Console.WriteLine("5. Sell");
                        Console.WriteLine("6. Back");
                        Console.WriteLine("Q. Exit");
                        // tba menyval köpa, söka, visa alla, sortera
                        string shopChoice = Console.ReadLine().ToUpper();
                        if (shopChoice == "1")
                        {
                            db.GetAllProducts(userLoggedInIsAdmin);
                        }
                        else if (shopChoice == "2")
                        {
                            bool searchMenu = true;
                            while (searchMenu)
                            {
                                Console.WriteLine();
                                Console.WriteLine("'Search Menu'");
                                Console.WriteLine("Search by:");
                                Console.WriteLine("1. Artist.");
                                Console.WriteLine("2. Album.");
                                Console.WriteLine("3. Label.");
                                Console.WriteLine("4. Format.");
                                Console.WriteLine("5. Used.");
                                Console.WriteLine("6. Back.");
                                Console.WriteLine("Q. Exit.");
                                string searchOption = Console.ReadLine().ToUpper();
                                if (searchOption == "1")
                                {
                                    // Todo skapa metod
                                    string searchOptionChoice = "ArtistName";
                                    Console.Write("Enter Artist name:"); // tex. sökning på första 3 bokstäver
                                    string searchInput = Misc.ReadString().ToLower();
                                    db.SearchProducts(searchOptionChoice, searchInput, userLoggedInIsAdmin);
                                }
                                else if (searchOption == "2")
                                {
                                    string searchOptionChoice = "AlbumName";
                                    Console.Write("Enter album name:"); // tex. sökning på första 3 bokstäver
                                    string searchInput = Misc.ReadString().ToLower();
                                    db.SearchProducts(searchOptionChoice, searchInput, userLoggedInIsAdmin);
                                }
                                else if (searchOption == "3")
                                {
                                    string searchOptionChoice = "RecordLabel";
                                    Console.Write("Enter label name:"); // tex. sökning på första 3 bokstäver
                                    string searchInput = Misc.ReadString().ToLower();
                                    db.SearchProducts(searchOptionChoice, searchInput, userLoggedInIsAdmin);;
                                }
                                else if (searchOption == "4")
                                {
                                    string searchOptionChoice = "Format";
                                    Console.Write("Enter format:"); // tex. sökning på första 3 bokstäver
                                    string searchInput = Misc.ReadString().ToLower();
                                    db.SearchProducts(searchOptionChoice, searchInput, userLoggedInIsAdmin);
                                }
                                else if (searchOption == "5")
                                {
                                    string searchOptionChoice = "Used";
                                    Console.Write("Enter '1. = new' or '2. = used':"); // Behöver omvandla till bool
                                    string searchInput = Console.ReadLine();
                                    db.SearchProducts(searchOptionChoice, searchInput, userLoggedInIsAdmin);
                                  
                                }
                                else if (searchOption == "6")
                                {
                                    searchMenu = false;
                                }
                                else if (searchOption == "Q")
                                {
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice");
                                }
                            }

                        }
                        else if (shopChoice == "3")
                            { }
                            else if (shopChoice == "4")
                            { }
                            else if (shopChoice == "5")
                            { }
                            else if (shopChoice == "6")
                            {
                                shopMenu = false;
                            }
                            else if (shopChoice == "Q")
                            {
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                        }
                        break;

                case "2":
                            bool profileMenu = true;
                            while (profileMenu)
                            {
                                Console.WriteLine();
                                Console.WriteLine("'Profile Menu'");
                                Console.WriteLine("1. Register");
                                Console.WriteLine("2. Log in");
                                Console.WriteLine("3. View profile");
                                Console.WriteLine("4. Edit profile");
                                Console.WriteLine("5. Back");
                                Console.WriteLine("Q. Exit");
                                string profileChoice = Console.ReadLine().ToUpper();

                                if (profileChoice == "1")
                                {
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

                                    // hash' n salt av lösen och pass
                                    (byte[] passwordHash, byte[] passwordSalt) = Misc.PasswordEncryption(password);

                                    db.AddUser(firstName, lastName, address, zipCode, city, country, birthDate, email, username, passwordHash, passwordSalt);
                                }
                                else if (profileChoice == "2")
                                {
                                    Misc.LogIn(db);
                                }
                                else if (profileChoice == "3")
                                {
                                    DatabaseManager.GetUser(userLoggedIn, db);
                                }
                                else if (profileChoice == "4")
                                {
                                    db.EditUser(userLoggedIn, db);
                                    Console.WriteLine("Log in to continue!");
                                    Misc.LogIn(db);
                                }
                                else if (profileChoice == "5")
                                {
                                    profileMenu = false;
                                }
                                else if (profileChoice == "Q")
                                {
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice");
                                }
                            }
                            break;

                        case "3":
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

                        case "Q":

                            return;

                        default:

                            Console.WriteLine("Invalid choice");
                            Console.ReadLine();
                            break;
                        }
                    }
            }
        }





