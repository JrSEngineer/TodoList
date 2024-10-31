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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserAccount>().HasKey(a => new {a.UserId, a.Email});

        builder.Entity<UserAccount>().HasIndex(a => a.Email).IsUnique();

        builder.Entity<ToDoUser>().HasMany(u => u.ToDos);
    }

    public DbSet<ToDoUser> User { get; set; }
    public DbSet<UserAccount> Account { get; set; }
    public DbSet<ToDo> ToDo { get; set; }
}
