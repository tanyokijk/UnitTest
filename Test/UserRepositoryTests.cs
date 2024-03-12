using Microsoft.Data.Sqlite;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;
namespace Test;

public class UserRepositoryTests
{
    [Fact]
    public void CreateUser_ValidUser_CreatesUserSuccessfully()
    {
        // Arrange
        var userRepository = new UserRepository();
        userRepository.CreateUserTable();
        var user = new User
        {
            Name = "John",
            Email = "john@example.com",
            Password = "password123"
        };

        // Act
        user.Id = userRepository.CreateUser(user);

        // Assert
        var createdUser = userRepository.GetUserById(user.Id);
        Assert.NotNull(createdUser);
        Assert.Equal(user.Name, createdUser.Name);
        Assert.Equal(user.Email, createdUser.Email);
        Assert.Equal(user.Password, createdUser.Password);
    }

    [Fact]
    public void UpdateUser_ValidUser_UpdatesUserSuccessfully()
    {
        // Arrange
        var userRepository = new UserRepository();
        userRepository.CreateUserTable();
        var user = new User
        {
            Name = "John",
            Email = "john@example.com",
            Password = "password123"
        };
        user.Id = userRepository.CreateUser(user);
        user.Name = "Updated Name";
        user.Email = "updated@example.com";
        user.Password = "updatedPassword";

        // Act
        userRepository.UpdateUser(user);

        // Assert
        var updatedUser = userRepository.GetUserById(user.Id);
        Assert.NotNull(updatedUser);
        Assert.Equal(user.Name, updatedUser.Name);
        Assert.Equal(user.Email, updatedUser.Email);
        Assert.Equal(user.Password, updatedUser.Password);
    }

     [Fact]
    public void DeleteUser_ValidUserId_DeletesUserSuccessfully()
    {
        // Arrange
        var userRepository = new UserRepository();
        userRepository.CreateUserTable();
        var user = new User
        {
            Name = "John",
            Email = "john@example.com",
            Password = "password123"
        };
        user.Id = userRepository.CreateUser(user);

        // Act
        userRepository.DeleteUser(user.Id);

        // Assert
        var deletedUser = userRepository.GetUserById(user.Id);
        Assert.Null(deletedUser);
    }

    [Fact]
    public void GetUserById_ValidUserId_ReturnsUserSuccessfully()
    {
        // Arrange
        var userRepository = new UserRepository();
        userRepository.CreateUserTable();
        var user = new User
        {
            Name = "John",
            Email = "john@example.com",
            Password = "password123"
        };
        user.Id = userRepository.CreateUser(user);

        // Act
        var retrievedUser = userRepository.GetUserById(user.Id);

        // Assert
        Assert.NotNull(retrievedUser);
        Assert.Equal(user.Name, retrievedUser.Name);
        Assert.Equal(user.Email, retrievedUser.Email);
        Assert.Equal(user.Password, retrievedUser.Password);
    }

}
