using TodoList.Domain.Entities;

namespace ToDoTests.Mocks;

public class ToDoMocks
{
    public static List<ToDo> GetTestToDos()
    {
        var todos = new List<ToDo>
        {
            new ToDo { Id = 1, Title = "Task 1", Description = "Description 1", Completed = true, InProgress = false },
            new ToDo { Id = 2, Title = "Task 2", Description = "Description 2", Completed = false, InProgress = true },
            new ToDo { Id = 3, Title = "Task 3", Description = "Description 3", Completed = true, InProgress = false },
            new ToDo { Id = 4, Title = "Task 4", Description = "Description 4", Completed = false, InProgress = true },
            new ToDo { Id = 5, Title = "Task 5", Description = "Description 5", Completed = true, InProgress = false },
            new ToDo { Id = 6, Title = "Task 6", Description = "Description 6", Completed = false, InProgress = true },
            new ToDo { Id = 7, Title = "Task 7", Description = "Description 7", Completed = true, InProgress = false },
            new ToDo { Id = 8, Title = "Task 8", Description = "Description 8", Completed = false, InProgress = false },
            new ToDo { Id = 9, Title = "Task 9", Description = "Description 9", Completed = true, InProgress = false },
            new ToDo { Id = 10, Title = "Task 10", Description = "Description 10", Completed = true, InProgress = false },
            new ToDo { Id = 11, Title = "Task 11", Description = "Description 11", Completed = false, InProgress = true },
            new ToDo { Id = 12, Title = "Task 12", Description = "Description 12", Completed = true, InProgress = false },
            new ToDo { Id = 13, Title = "Task 13", Description = "Description 13", Completed = false, InProgress = true },
            new ToDo { Id = 14, Title = "Task 14", Description = "Description 14", Completed = true, InProgress = false },
            new ToDo { Id = 15, Title = "Task 15", Description = "Description 15", Completed = false, InProgress = false },
            new ToDo { Id = 16, Title = "Task 16", Description = "Description 16", Completed = false, InProgress = true },
            new ToDo { Id = 17, Title = "Task 17", Description = "Description 17", Completed = false, InProgress = false },
            new ToDo { Id = 18, Title = "Task 18", Description = "Description 18", Completed = false, InProgress = true },
            new ToDo { Id = 19, Title = "Task 19", Description = "Description 19", Completed = false, InProgress = false },
            new ToDo { Id = 20, Title = "Task 20", Description = "Description 20", Completed = false, InProgress = false },
            new ToDo { Id = 21, Title = "Task 21", Description = "Description 21", Completed = false, InProgress = false },
            new ToDo { Id = 22, Title = "Task 22", Description = "Description 22", Completed = false, InProgress = true },
            new ToDo { Id = 23, Title = "Task 23", Description = "Description 23", Completed = false, InProgress = false },
            new ToDo { Id = 24, Title = "Task 24", Description = "Description 24", Completed = false, InProgress = false }
        };

        return todos;
    }
}
