using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ProjektDb;
public class DatabaseManager
{
    private IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");

        // anslut till databasen med hjälp av connectionstring.txt
        IDbConnection connection = new SqlConnection(connectionString);
        return connection;
    }
    public IEnumerable<Product> GetAllProducts(bool userLoggedInIsAdmin)
    {
        // Hämta ut alla produkter från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<Product> products = connection.Query<Product>("SELECT * FROM Product");
        Console.WriteLine();

        // Rubrik med skiljelinje och admincheck för inpris
        Console.WriteLine(
        $"{"Id",-5} {"Artist",-20} {"Album",-20} {"Record Company",-20} {"Release Date",-15} {"Genre",-20} {"Format",-10} " +
        $"{"Sell Price",-12} {(userLoggedInIsAdmin ? "Purchase Price" : ""),-15} {"Used",-8} {"Condition",-12} {"Stock",-10} {"Description",-15} "); // TODO bara visa Purchase price i adminläge

        Console.WriteLine(new string('-', 225));

        // Listar upp tabellen med yes/no istället för true/false i begagnad. TODO visa inte inköpspris om inte user är admin
        foreach (Product p in products)
        {
            Console.WriteLine(
            $"{p.Id,-5} {p.ArtistName,-20} {p.AlbumName,-20} {p.RecordLabel,-20} {p.ReleaseDate,-15} {p.Genre,-20} {p.Format,-10} " +
            $"{p.Price,-12:F2} {(userLoggedInIsAdmin ? $"{p.PurchasePrice:F2}" : ""),-15} {(p.Used ? "Yes" : "No"),-8} {p.Condition,-12} {p.StockBalance,-10} {p.Description,-15} ");
        }
        return products;
    }
    public static User? GetUser(string userLoggedIn, DatabaseManager db)
    {
        using IDbConnection connection = db.Connect();
        var user = connection.QuerySingleOrDefault<User>(
            @"SELECT Id, FirstName, LastName, Address, ZipCode, City, Country, BirthDate, Email, Username 
          FROM [User] WHERE Username = @Username", new { Username = userLoggedIn });

        if (user != null)
        {
            Console.WriteLine(
            $"{"Id",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Zip code",-10} {"City",-15} {"Country",-15} " + // måste ju ha city
            $"{"Birthdate",-15} {"Email",-25} {"Username",-15}");
            Console.WriteLine(new string('-', 180));


            string dateOnlyBirthDate = user.BirthDate.ToString("yyyy-MM-dd");

            Console.WriteLine($"{user.Id,-5} {user.FirstName,-15} {user.LastName,-15} {user.Address,-20} {user.ZipCode,-10} {user.City,-15} {user.Country,-15} " +
            $"{dateOnlyBirthDate,-15} {user.Email,-25} {user.Username,-15}");

        }
        else
        {
            Console.WriteLine("Log in required.");
        }
        Console.WriteLine();
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        // Hämta ut alla User från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<User> users = connection.Query<User>("SELECT * FROM [User]"); // inte *?
        Console.WriteLine();

        Console.WriteLine(
        $"{"Id",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Zip code",-10} {"City",-15} {"Country",-15} " + // måste ju ha city
        $"{"Birthdate",-15} {"Email",-25} {"Username",-15}");
        Console.WriteLine(new string('-', 180));

        foreach (User u in users)
        {
            string dateOnlyBirthDate = u.BirthDate.ToString("yyyy-MM-dd");
            Console.WriteLine(
            $"{u.Id,-5} {u.FirstName,-15} {u.LastName,-15} {u.Address,-20} {u.ZipCode,-10} {u.City,-15} {u.Country,-15} " +
            $"{dateOnlyBirthDate,-15} {u.Email,-25} {u.Username,-15}");
        }
        Console.WriteLine();
        return users;
    }
    public void AddUser(string firstName, string lastName, string address, string zipCode, string city, string country, DateTime birthDate, string email, string username, byte[] passwordHash, byte[] passwordSalt)
    {
        using IDbConnection connection = Connect();

        // ev. lägga till transaction
        string query = @"INSERT INTO [User] 
        (FirstName, LastName, Address, ZipCode, City, Country, BirthDate, Email, Username, PasswordHash, PasswordSalt) 
        VALUES 
        (@FirstName, @LastName, @Address, @ZipCode, @City, @Country, @BirthDate, @Email, @Username, @PasswordHash, @PasswordSalt)";
        connection.Execute(query, new
        {
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            ZipCode = zipCode,
            City = city,
            Country = country,
            BirthDate = birthDate,
            Email = email,
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });
        Console.WriteLine("testing testing");
    }
    //testar... ska kunna byta mail osv
    public void EditUser(string userLoggedIn, DatabaseManager db)
    {
        using IDbConnection connection = Connect();
        // plockar upp user från GetUser
        User? user = GetUser(userLoggedIn, db);
        Console.WriteLine("1. First Name:");
        Console.WriteLine("2. Last Name:");
        Console.WriteLine("3. Address:");
        Console.WriteLine("4. Zip Code:");
        Console.WriteLine("5. City:");
        Console.WriteLine("6. Country:");
        Console.WriteLine("7. Email:");
        Console.WriteLine("8. Password");
        Console.Write("What info would you like to change? Enter number: ");
        string choice;

        // Uppdateringsdictionary (lista) kolla grupparbetet..
        var update = new Dictionary<string, object>();
        while ((choice = Console.ReadLine().ToLower()) != "q")
        {
            switch (choice)
            {
                case "1":
                    Console.Write("Enter new First Name: ");
                    update["FirstName"] = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Enter new Last Name: ");
                    update["LastName"] = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Enter new Address: ");
                    update["Address"] = Console.ReadLine();
                    break;

                case "4":
                    Console.Write("Enter new Zip Code: ");
                    update["ZipCode"] = Console.ReadLine();
                    break;

                case "5":
                    Console.Write("Enter new City: ");
                    update["City"] = Console.ReadLine();
                    break;

                case "6":
                    Console.Write("Enter new Country: ");
                    update["Country"] = Console.ReadLine();
                    break;

                case "7":
                    Console.Write("Enter new Email: ");
                    update["Email"] = Console.ReadLine();
                    break;

                case "8":
                    Console.Write("Enter new Password: ");
                    string newPassword = Console.ReadLine();
                    (byte[] passwordHash, byte[] passwordSalt) = Misc.PasswordEncryption(newPassword);
                    update["PasswordHash"] = passwordHash;
                    update["PasswordSalt"] = passwordSalt;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("Enter number to continue editing or 'Q' to finish:");
        }

        // dynamisk uppdatering av tabellrad
        if (update.Count > 0)
        {
            string updateQuery = "UPDATE [User] SET ";
            foreach (var field in update.Keys)
            {
                updateQuery += $"{field} = @{field}, ";
            }
            updateQuery = updateQuery.TrimEnd(',', ' '); // tar bort slutkommat så det inte crashar
            updateQuery += " WHERE Username = @Username";

            update["Username"] = userLoggedIn; // Lägg till Username som parameter
            connection.Execute(updateQuery, update);

            Console.WriteLine("User updated!");
        }
        else
        {
            Console.WriteLine("No changes applied.");
        }
    }
    public bool VerifyUser(string inputUsername, string inputPassword, out bool isAdmin)
    {
        using IDbConnection connection = Connect();
        var verify = connection.QuerySingleOrDefault<(bool IsAdmin, byte[] PasswordHash, byte[] PasswordSalt)>("SELECT IsAdmin, PasswordHash, PasswordSalt FROM [User] WHERE Username = @Username", new { Username = inputUsername });
        isAdmin = verify.IsAdmin;
        byte[] passwordHash = verify.PasswordHash;
        byte[] passwordSalt = verify.PasswordSalt;
        byte[] inputHash = Misc.HashPasswordWithSalt(inputPassword, passwordSalt);
        return isAdmin || passwordHash.SequenceEqual(inputHash);
    }

    // WORK IN PROGRESS
    public IEnumerable<Product> SearchProducts(string searchOptionChoice, string searchInput, bool userLoggedInIsAdmin)
    {
        using IDbConnection connection = Connect();
        // Kontrollera om det är en sökning på nya/begagnade produkter
        string query = $"SELECT Id, ArtistName, AlbumName, RecordLabel, ReleaseDate, Genre, Format, Price, PurchasePrice, Used, StockBalance, Condition, Description " +
                       $"FROM Product WHERE {searchOptionChoice} LIKE @SearchInput";

        IEnumerable<Product> searchResult = connection.Query<Product>(query, new { SearchInput = searchInput + "%" });

        // Kontrollera om inga resultat hittas
        if (!searchResult.Any())
        {
            Console.WriteLine("No products found matching your search.");
            return Enumerable.Empty<Product>();
        }

        // Rubrik med skiljelinje
        Console.WriteLine(
        $"{"Id",-5} {"Artist",-20} {"Album",-20} {"Record Company",-20} {"Release Date",-15} {"Genre",-20} {"Format",-10} " +
        $"{"Sell Price",-12} {(userLoggedInIsAdmin ? "Purchase Price" : ""),-15} {"Used",-8} {"Condition",-12} {"Stock",-10} {"Description",-15} "); // TODO bara visa Purchase price i adminläge

        Console.WriteLine(new string('-', 225));

        // Listar upp tabellen med yes/no istället för true/false i begagnad. TODO visa inte inköpspris om inte user är admin
        foreach (Product p in searchResult)
        {
            Console.WriteLine(
            $"{p.Id,-5} {p.ArtistName,-20} {p.AlbumName,-20} {p.RecordLabel,-20} {p.ReleaseDate,-15} {p.Genre,-20} {p.Format,-10} " +
            $"{p.Price,-12:F2} {(userLoggedInIsAdmin ? $"{p.PurchasePrice:F2}" : ""),-15} {(p.Used ? "Yes" : "No"),-8} {p.Condition,-12} {p.StockBalance,-10} {p.Description,-15} ");
        }
        return searchResult;
    }
}