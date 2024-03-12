using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace Test;

public class UserServiceTests
{
    [Fact]
    public void AddNewUser_ValidInput_CreatesUser()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>()));
        var userService = new UserService(userRepositoryMock.Object);

        // Act
        userService.AddNewUser("John", "john@example.com", "password123");

        // Assert
        userRepositoryMock.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void AddNewUser_ValidInput_UpdatesUser()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.UpdateUser(It.IsAny<User>()));
        var userService = new UserService(userRepositoryMock.Object);
        
        // Act
        userService.UpdateUser(1, "Johnie", "john@example.com", "password123");

        // Assert
        userRepositoryMock.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Once);
    }


    [Fact]
    public void AddNewUser_ValidInput_DeletesUser()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.DeleteUser(1));
        var userService = new UserService(userRepositoryMock.Object);

        // Act
        userService.DeleteUser(1);

        // Assert
        userRepositoryMock.Verify(repo => repo.DeleteUser(1), Times.Once);
    }

}
