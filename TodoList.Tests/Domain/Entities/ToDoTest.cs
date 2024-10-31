using TodoList.Domain.Entities;

namespace TodoList.Tests.Domain.Entities;

public class ToDoTest
{
    [Fact]
    public void FailToCreateNewToDoDueToInvalidTitle()
    {
        Assert.Throws<Exception>(() => ToDo.Create("", "TODO DESCRIPTION", 1));
    }

    [Fact]
    public void FailToCreateNewToDoDueToInvalidDescription()
    {
        Assert.Throws<Exception>(() => ToDo.Create("TODO TITLE", "", 1));
    }

    [Fact]
    public void CreateNewToDoSuccessfully()
    {
        ToDo newToDo = ToDo.Create("TODO TITLE", "TODO DESCRIPTION", 1);

        Assert.IsType<ToDo>(newToDo);

        Assert.NotEqual("todo title", newToDo.Title);

        Assert.Equal("TODO TITLE", newToDo.Title);

        Assert.Equal("TODO DESCRIPTION", newToDo.Description);
    }
}
