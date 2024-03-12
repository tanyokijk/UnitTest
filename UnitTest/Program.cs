using SQLitePCL;
using System.Text;
using System.Xml.Linq;
using UnitTest;
using Validations;

internal class Program
{
    private static string ConnectionString = "Data Source=users.sqlite;";

    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Batteries.Init();

        UserRepository userRepository = new UserRepository();
        userRepository.CreateUserTable();
        UserService userService = new UserService(userRepository);
        string name;
        do
        {
            Console.WriteLine("Введіть ім'я:");
            name = Console.ReadLine();
            if (!NameValidation.IsValid(name))
            {
                Console.WriteLine("Порожній рядок! Будь ласка, введіть ім'я знову.");
            }
        } while (!NameValidation.IsValid(name));

        string email;
        do
        {
            Console.WriteLine("Введіть email:");
            email = Console.ReadLine();
            if (!EmailValidation.IsValid(email))
            {
                Console.WriteLine("Неправильний email! Будь ласка, введіть email знову.");
            }
        } while (EmailValidation.IsValid(email) != true);

        string password;
        do
        {
            Console.WriteLine("Введіть пароль:");
            password = Console.ReadLine();
            if (!PasswordValidation.IsValid(password))
            {
                Console.WriteLine("Неправильний пароль! Будь ласка, введіть пароль знову.");
            }
        } while (PasswordValidation.IsValid(password) != true);
    }
}