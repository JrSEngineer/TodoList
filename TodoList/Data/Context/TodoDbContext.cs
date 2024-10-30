using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Data.Context;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        bool pendingMigrationsFound = this.Database.GetPendingMigrations().Any();
        if (pendingMigrationsFound) this.Database.Migrate();
    }

    public DbSet<ToDo> ToDo { get; set; }
}
