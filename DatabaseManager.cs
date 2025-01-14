using System.Data;
// using Microsoft.Data;
// using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using Dapper;

namespace SkolProjekt;

class DatabaseManager
{
    private IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");

        // anslut till databasen med hjälp av connection string
        IDbConnection connection = new SqlConnection(connectionString);
        return connection;
    }
    public IEnumerable<Produkt> GetAllProducts()
    {
        // Hämta ut alla produkter från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<Produkt> produkter = connection.Query<Produkt>("SELECT * FROM Produkt");
        Console.WriteLine();

        // Rubrik med skiljelinje
        Console.WriteLine(
        $"{"Id",-5} {"Artist",-20} {"Album",-20} {"Record Company",-20} {"Release Date",-15} {"Genre",-10} {"Format",-10} " +
        $"{"Sell Price",-12} {"Purchase Price",-15} {"Used",-8} {"Condition",-12} {"Stock",-10} {"Description",-15} "); // TODO bara visa Purchase price i adminläge
        Console.WriteLine(new string('-', 220));

        // Listar upp tabellen med yes/no istället för true/false i begagnad
        foreach (Produkt p in produkter)
        {
            Console.WriteLine(
            $"{p.Id,-5} {p.Artistnamn,-20} {p.Albumnamn,-20} {p.Skivbolag,-20} {p.Releasedatum,-15} {p.Genre,-10} {p.Format,-10} " +
            $"{p.Pris,-12:F2} {p.Inköpspris,-15:F2} {(p.Begagnad ? "Yes" : "No"),-8} {p.Skick,-12} {p.Lagersaldo,-10} {p.Beskrivning,-15} ");
        }
        return produkter;
    }
}