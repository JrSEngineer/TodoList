namespace TodoList.Domain.Entities;

public class ToDo
{
    private ToDo(string title, string description, int userId)
    {
        Title = title;
        Description = description;
        UserId = userId;
    }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Completed { get; set; } = false;

    public int UserId { get; set; }

    public static ToDo Create(string title, string description, int userId)
    {
        if(string.IsNullOrEmpty(title))
        {
            throw new Exception("Please, provide a valid title.");
        }
        
        if (string.IsNullOrEmpty(description))
        {
            throw new Exception("Please, provide a valid description.");
        }

        return new ToDo(title, description, userId);
    }
}
