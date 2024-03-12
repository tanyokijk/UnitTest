using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations;
namespace UnitTest;

public class UserService
{
    public IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
       this.userRepository = userRepository;
    }

    public void AddNewUser(string name, string email, string password)
    {
        /*string name;
        do
        {
            Console.WriteLine("Введіть ім'я:");
            name = Console.ReadLine();
        } while (NameValidation.IsValid(name)!=true);

        string email;
        do
        {
            Console.WriteLine("Введіть email:");
            email = Console.ReadLine();
        } while (EmailValidation.IsValid(email) != true);

        string password;
        do
        {
            Console.WriteLine("Введіть пароль:");
            password = Console.ReadLine();
        } while (PasswordValidation.IsValid(password) != true);
        */
        User user = new User{ Name = name, Email = email, Password = password};
        user.Id = userRepository.CreateUser(user);
    }

    public void UpdateUser(int id, string newname, string newemail, string newpassword)
    {
        User user =new User { Name = newname, Id = id, Email = newemail, Password = newpassword};

            userRepository.UpdateUser(user);
        
    }

    public void DeleteUser(int id) 
    {
        userRepository.DeleteUser(id);
    }
}
