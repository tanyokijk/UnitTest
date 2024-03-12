using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest;

public interface IUserRepository
{
    public void CreateUserTable();
    public int CreateUser(User user);
    public User GetUserById(int userId);
    public void UpdateUser(User user);
    public void DeleteUser(int userId);
}
