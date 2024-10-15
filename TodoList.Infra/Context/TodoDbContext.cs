using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Context;

public class TodoDbContext : DbContext
{
    private readonly string? _host = Environment.GetEnvironmentVariable("HOST") ?? "localhost";
    private readonly string? _port = Environment.GetEnvironmentVariable("PORT") ?? "5432";
    private readonly string? _user = Environment.GetEnvironmentVariable("USER") ?? "jradmin";
    private readonly string? _password = Environment.GetEnvironmentVariable("PASSWORD") ?? "12345678";
    private readonly string? _database = Environment.GetEnvironmentVariable("DATABASE") ?? "TodoDb";
    public TodoDbContext()
    {
        bool pendingMigrationsFound = this.Database.GetPendingMigrations().Any();
        if (pendingMigrationsFound) this.Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql($"host={_host}:{_port};userid={_user};password={_password};Database={_database}");
    }

    public DbSet<ToDo> ToDo { get; set; }
}
