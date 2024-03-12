using Xunit;
using Validations;

namespace Test;

public class UserTest
{

    public UserTest() 
    {
    }

    [Fact]
    public void UserNameValidationTest_ReturnTrue() => Assert.True(NameValidation.IsValid("Max"));

    [Fact]
    public void UserNameValidationTest_ReturnFalse() => Assert.False(NameValidation.IsValid(""));

    [Fact]
    public void UserEmailValidationTest_ReturnTrue() => Assert.True(EmailValidation.IsValid("ghdbrgjhdbr@gmail.com"));

    [Fact]
    public void UserEmailValidationTest_ReturnFalse() => Assert.False(EmailValidation.IsValid("ghdbrgjhdbr"));

    [Fact]
    public void UserPasswordValidationTest_ReturnTrue() => Assert.True(PasswordValidation.IsValid("ghdbrgjhdbrua"));

    [Fact]
    public void UserPasswordValidationTest_ReturnFalse() => Assert.False(PasswordValidation.IsValid("2333"));

}