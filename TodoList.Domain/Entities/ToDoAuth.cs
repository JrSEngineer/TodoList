namespace TodoList.Domain.Entities;

public class ToDoAuth
{
    public int UserId { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string UserPassword { get; set; } = string.Empty;
    public string UserToken { get; set; } = string.Empty;
}
