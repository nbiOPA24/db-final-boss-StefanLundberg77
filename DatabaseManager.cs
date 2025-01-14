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
        string connectionstring = File.ReadAllText("connectionString.txt");

        // anslut till databasen med hjälp av connection string
        IDbConnection connection = new SqlConnection(connectionstring);
        return connection;
    }
    public IEnumerable<Kund> GetAllProducts()
    {
        // hämta ut alla produkter från databasen till en lista
        using IDbConnection connection = Connect();
        IEnumerable<Kund> produkter = connection.Query<Kund>("SELECT * FROM Produkter");
        return produkter;
    }
}   