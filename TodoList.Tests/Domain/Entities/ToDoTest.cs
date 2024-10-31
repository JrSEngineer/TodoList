using TodoList.Domain.Entities;

namespace TodoList.Tests.Domain.Entities;

public class ToDoTest
{
    [Fact]
    public void FailToCreateNewToDoDueToInvalidTitle()
    {
        Assert.Throws<Exception>(() => ToDo.Create("","TODO DESCRIPTION", 1));
    }  
    
    [Fact]
    public void FailToCreateNewToDoDueToInvalidDescription()
    {
        Assert.Throws<Exception>(() => ToDo.Create("TODO TITLE","", 1));
    }
}
