using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using TodoList.Application.Interfaces;
using TodoList.Endpoints;
using TodoList.Tests.Mocks;

namespace TodoList.Tests.Api;

public class TodoListApiTest
{
    [Fact]
    public async Task FailToReturnStatus201CreatedForUsersPostEnpoint()
    {
        var repository = new Mock<IToDoUserRepository>();

        repository.Setup(r => r.CreateUserAsync(ToDoUserMocks.wrongUserDto)).Returns(async () =>
        {
            await Task.Delay(500);
            return null;
        });

        var nullUserResult = await ToDoUserEnpoints.CreateUserAsync(repository.Object, ToDoUserMocks.wrongUserDto);

        Assert.IsType<Results<Created, BadRequest<string>>>(nullUserResult);
    }
}
