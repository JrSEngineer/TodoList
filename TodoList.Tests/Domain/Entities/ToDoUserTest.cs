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

    [Fact]
    public void FailToCreateANewToDoForSelectedUser()
    {
        var user = ToDoUserMocks.newUser;

        Assert.Throws<Exception>(() => user.CreateNewTodo("TODO TITLE", ""));

        Assert.Throws<Exception>(() => user.CreateNewTodo("", "TODO DESCRIPTION"));
    }


    [Fact]
    public void CreateANewToDoForSelectedUserSuccessfully()
    {
        var user = ToDoUserMocks.newUser;

        user.CreateNewTodo("TODO TITLE", "TODO DESCRIPTION");

        user.CreateNewTodo("TODO TITLE 2", "TODO DESCRIPTION 2");

        Assert.True(user.ToDos.Count() == 2);

        Assert.Equal("TODO DESCRIPTION", user.ToDos.First().Description);
    }
}
