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
    public IEnumerable<Product> GetAllProducts()
    {
        // Hämta ut alla produkter från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<Product> products = connection.Query<Product>("SELECT * FROM Product");
        Console.WriteLine();

        // Rubrik med skiljelinje
        Console.WriteLine(
        $"{"Id",-5} {"Artist",-20} {"Album",-20} {"Record Company",-20} {"Release Date",-15} {"Genre",-10} {"Format",-10} " +
        $"{"Sell Price",-12} {"Purchase Price",-15} {"Used",-8} {"Condition",-12} {"Stock",-10} {"Description",-15} "); // TODO bara visa Purchase price i adminläge
        Console.WriteLine(new string('-', 220));

        // Listar upp tabellen med yes/no istället för true/false i begagnad. TODO visa inte inköpspris om inte user är admin
        foreach (Product p in products)
        {
            Console.WriteLine(
            $"{p.Id,-5} {p.ArtistName,-20} {p.AlbumName,-20} {p.RecordLabel,-20} {p.ReleaseDate,-15} {p.Genre,-10} {p.Format,-10} " +
            $"{p.Price,-12:F2} {p.PurchasePrice,-15:F2} {(p.Used ? "Yes" : "No"),-8} {p.Condition,-12} {p.StockBalance,-10} {p.Description,-15} ");
        }
        return products;
    }
    public void GetUser(string userLoggedIn)
{
    using IDbConnection connection = Connect();
    var user = connection.QuerySingleOrDefault<User>(
        @"SELECT FirstName, LastName, Address, ZipCode, City, Country, BirthDate, Email, Username 
          FROM [User] WHERE Username = @Username", new { Username = userLoggedIn });

    if (user != null)
    {
        Console.WriteLine(
        $"{"Id",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Zip code",-10} {"City",-15} {"Country",-15} " + // måste ju ha city
        $"{"Birthdate",-15} {"Email",-25} {"Username",-15}");
        Console.WriteLine(new string('-', 180));

        
            string dateOnlyBirthDate = user.BirthDate.ToString("yyyy-MM-dd");
            Console.WriteLine(
            $"{user.Id,-5} {user.FirstName,-15} {user.LastName,-15} {user.Address,-20} {user.ZipCode,-10} {user.City,-15} {user.Country,-15} " +
            $"{dateOnlyBirthDate,-15} {user.Email,-25} {user.Username,-15}");
        
    }
    else
    {
        Console.WriteLine("User not found.");
    }
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
        return users;
    }
    public void AddUser(string firstName, string lastName, string address, string zipCode, string city, string country, DateTime birthDate, string email, string username, byte[] passwordHash, byte[] passwordSalt)
    {

        using IDbConnection connection = Connect();

        string query = @"INSERT INTO [User] 
        (FirstName, LastName, Address, ZipCode, City, Country, BirthDate, Email, Username, PasswordHash, PasswordSalt) 
        VALUES 
        (@FirstName, @LastName, @Address, @ZipCode, @City, @Country, @BirthDate, @Email, @Username, @PasswordHash, @PasswordSalt)";


        //birthDate.ToString("yyyy-MM-dd")
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
    //testar... ska kunna byta mail
    public void UpdateUser(int id, string LastName, string email, string username)
    {
        using IDbConnection connection = Connect();

        // if {} input = null gör ingenting eller bättre lösning
        // Spara i datbasen
        string query = $" UPDATE [User] SET Name = '{LastName}', Email = '{email}', Username = '{username}' WHERE Id = {id}";
        connection.Execute(query);
    }
    public bool VerifyUser(string inputUsername, string inputPassword, out bool isAdmin)
    {
        using IDbConnection connection = Connect();
        var verify = connection.QuerySingleOrDefault<(bool IsAdmin, byte[] PasswordHash, byte[] PasswordSalt)>("SELECT IsAdmin, PasswordHash, PasswordSalt FROM [User] WHERE Username = @Username", new { Username = inputUsername});
        isAdmin = verify.IsAdmin;
        byte[] passwordHash = verify.PasswordHash;
        byte[] passwordSalt = verify.PasswordSalt;
        byte[] inputHash = Misc.HashPasswordWithSalt(inputPassword, passwordSalt);
        return isAdmin || passwordHash.SequenceEqual(inputHash);
    }
    
    // WORK IN PROGRESS
    public IEnumerable<Product> SearchProducts(string searchOptionChoice, string searchInput)
    {
        using IDbConnection connection = Connect();
        IEnumerable<Product> searchResult = connection.Query<Product>($"SELECT '{searchOptionChoice}' FROM Product where ArtistName = '{searchInput}'");
        Console.WriteLine();
        return searchResult;
    }
}