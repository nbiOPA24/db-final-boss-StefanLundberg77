using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ProjektDb;

class DatabaseManager
{
    private IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");

        // anslut till databasen med hjälp av connection string
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

    public IEnumerable<User> GetAllUsers()
    {
        // Hämta ut alla produkter från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<User> users = connection.Query<User>("SELECT * FROM User"); // inte *?
        Console.WriteLine();

        Console.WriteLine(
        $"{"Id",-5} {"First Name",-15} {"Last Name",-15} {"Address",-20} {"Zip code",-10} {"Country",-15} " +
        $"{"Birthdate",-5} {"Email",-25} {"Username",-15}");
        Console.WriteLine(new string('-', 135));

        foreach (User u in users)
        {
            Console.WriteLine(
            $"{u.Id,-5} {u.FirstName,-15} {u.LastName,-15} {u.Address,-20} {u.ZipCode,-10} {u.Country,-15} " +
            $"{u.BirthDate,-5} {u.Email,-25} {u.Username,-15}");
        }
        return users;
    }
    public void AddUser(string firstName, string lastName, string address, string zipCode, DateOnly birthDate, string country, string email, string username, string password)
    {   
        string salt = "abcde"; // Tba
        using IDbConnection connection = Connect();
        string query = $"INSERT INTO User (FirstName, LastName, Address, Birthdate, Country, Email, Username, Password, Salt) VALUES ('{firstName}', '{lastName}', '{birthDate}', '{address}', '{country}', '{zipCode} '{email}', '{username}', '{password}), '{salt}'";
        connection.Execute(query); 
    }
    public IEnumerable<Product> SearchProducts()
    {
        using IDbConnection connection = Connect();
        IEnumerable<Product> searchResult = connection.Query<Product>("SELECT ? FROM Product");
        Console.WriteLine();
        return searchResult;
    }
}