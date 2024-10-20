using TodoList.Domain.Entities;
using ToDoTests.Mocks;

namespace ToDoTests.Domain;

public class ToDoTests
{

    private readonly ToDoList _toDoList;

    public ToDoTests()
    {
        _toDoList = new(ToDoMocks.GetTestToDos());
    }

    [Fact]
    public void Should_Return_Porcentage_Of_Awaiting_ToDos()
    {
        var awaitingToDosPorcentage = _toDoList.GetWaitingToDoPorcentage();

        Assert.IsType<int>(awaitingToDosPorcentage);
        Assert.Equal(33,awaitingToDosPorcentage);
    }
    
    [Fact]
    public void Should_Return_Porcentage_Of_In_Progress_ToDos()
    {
        var inProgressToDosPorcentage = _toDoList.GetInProgressToDoPorcentage();

        Assert.IsType<int>(inProgressToDosPorcentage);
        Assert.Equal(33,inProgressToDosPorcentage);
    }

    [Fact]
    public void Should_Return_Porcentage_Of_Completed_ToDos()
    {
        var completedToDosPorcentage = _toDoList.GetCompletedToDoPorcentage();

        Assert.IsType<int>(completedToDosPorcentage);
        Assert.Equal(33,completedToDosPorcentage);
    }
}
