using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTest;

public class UserRepository : IUserRepository
{
    public static string ConnectionString = "Data Source=users.sqlite;";

    public void CreateUserTable()
    {
        string query = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                Password TEXT NOT NULL
            )";

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public int CreateUser(User user)
    {
        string query = @"
        INSERT INTO Users (Name, Email, Password) 
        VALUES (@Name, @Email, @Password);
        SELECT last_insert_rowid();";

        int userId = -1;

        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();

                userId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        return userId;
    }

    public User GetUserById(int userId)
    {
        User user = null;
        string query = "SELECT Id, Name, Email, Password FROM Users WHERE Id = @Id";
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", userId);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Password = reader.GetString(3)
                    };
                }
            }
        }
        return user;
    }

    public void UpdateUser(User user)
    {
        string query = "UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE Id = @Id";
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteUser(int userId)
    {
        string query = "DELETE FROM Users WHERE Id = @Id";
        using (SqliteConnection connection = new SqliteConnection(ConnectionString))
        {
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
