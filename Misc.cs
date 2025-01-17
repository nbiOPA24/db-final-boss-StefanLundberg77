using System.Collections;
using System.Security.Cryptography;

namespace ProjektDb;
static class Misc
{
    public static DateTime ReadDate() // dateToString kanske
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
            byte[] salt = new byte[size];
            rng.GetBytes(salt);
            return salt;
        }
    }

    static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(32); // Hashens storlek (32 bytes för SHA-256)
        }
    }
    static (byte[] hashedPassword, byte[] salt) PasswordEncryption(string password)
    {     
        // Slumpa fram salten
        byte[] salt = GenerateSalt(16); // 16 bytes

        // Hasha ihop lösenordet och salten
        byte[] hashedPassword = HashPasswordWithSalt(password, salt);

        // 4. Skriv ut resultatet
        Console.WriteLine("Salt: " + BitConverter.ToString(salt).Replace("-", ""));
        Console.WriteLine("Hashed password: " + BitConverter.ToString(hashedPassword).Replace("-", ""));

        return (hashedPassword, salt);

    }
    static bool VerifyPassword(string inputPassword, byte[] storedHash, byte[] storedSalt)
    {

        byte[] inputHashedPassword = HashPasswordWithSalt(inputpassword, salt);
        if(StructuralComparisons.StructuralEqualityComparer.Equals(hashedPassword, inputHashedPassword))
        {
            Console.WriteLine("Lösenordet är korrekt!");
        }
        else
        {
            Console.WriteLine("Lösenordet är felaktigt!");
        }
        // string inputpassword = Console.ReadLine();
    }
    static bool LogIn()
    {

    }
}
