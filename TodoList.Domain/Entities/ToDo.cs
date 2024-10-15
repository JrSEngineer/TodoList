using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities;

public class ToDo
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; } = false;

    public ToDo() { }
}
