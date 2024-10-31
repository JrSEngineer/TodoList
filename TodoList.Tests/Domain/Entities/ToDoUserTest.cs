using TodoList.Domain.Entities;
using TodoList.Tests.Mocks;

namespace TodoList.Tests.Domain.Entities;

public class ToDoUserTest
{
    [Fact]
    public void FailToCreateUserDueToShortPasswordValue()
    {
        Assert.Throws<Exception>(ToDoUserMocks.userWithShortPassword);
    }

    [Fact]
    public void FailToCreateUserDueToInvalidEmailFormat()
    {
        Assert.Throws<Exception>(ToDoUserMocks.userWithWrongEmail);
    }

    [Fact]
    public void CreateANewToDoUserSuccessfully()
    {
        Assert.IsType<ToDoUser>(ToDoUserMocks.newUser);

        Assert.Equal("email123@email.com", ToDoUserMocks.newUser.Account.Email);

        Assert.Equal("43423242df45", ToDoUserMocks.newUser.Account.Password);
    }
}
