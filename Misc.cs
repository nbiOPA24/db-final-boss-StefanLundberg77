
using System.Data.Common;
using System.Security.Cryptography;

using ProjektDb;
public static class Misc
{
    public static DateTime ReadDate()
    {
        DateTime input;
        while (!DateTime.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltigt datumformat, försök igen (åååå-mm-dd):");
        }
        return input;
    }
    public static int ReadInt()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltig inmatning, försök igen:");
        }
        return input;
    }
    public static string ReadString()
    {
        string input;
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Ogiltig inmatning, försök igen:");
        }
        return input;
    }
    public static string UpperCaseFirst(string str) // oklart behov
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }
    static byte[] GenerateSalt(int size)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] passwordSalt = new byte[size];
            rng.GetBytes(passwordSalt);
            return passwordSalt;
        }
    }
    public static byte[] HashPasswordWithSalt(string password, byte[] passwordSalt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, 100000, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(32); // Hashens storlek (32 bytes för SHA-256)
        }
    }
    public static (byte[] passwordHash, byte[] passwordSalt) PasswordEncryption(string password)
    {
        // Slumpa fram salten
        byte[] passwordSalt = GenerateSalt(16); // 16 bytes
        // Hasha ihop lösenordet och salten
        byte[] passwordHash = HashPasswordWithSalt(password, passwordSalt);
        return (passwordHash, passwordSalt);

    }
    public static void LogIn(DatabaseManager db)
    {
        
        while (true)
        {
            Console.Write("Enter username: ");
            string inputUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string inputPassword = Console.ReadLine();
            try
            {
                if (db.VerifyUser(inputUsername, inputPassword, out bool isAdmin))
                {
                    Program.userLoggedIn = inputUsername;
                    Program.userLoggedInIsAdmin = isAdmin;
                    Console.WriteLine($"Welcome, {inputUsername}! You are logged in {(isAdmin ? "as admin" : "as user")}.");
                    return;
                }
                else
                {
                    Console.WriteLine("Username or password incorrect!");
                }
            }
            catch
            {
                Console.WriteLine("Login failedUsername or password incorrect!"); //"Login failed"
            }
            Console.WriteLine("Press 'ENTER' to try again or 'Q' to return to profile menu.");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Q")
            {
                return;
            }
        }
    }
}


