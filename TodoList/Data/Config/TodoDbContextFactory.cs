using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using TodoList.Data.Context;

namespace TodoList.Data.Config;

public class TodoDbContextFactory : IDbContextFactory<TodoDbContext>
{
    private readonly DbContextOptions<TodoDbContext> _options;

    public TodoDbContextFactory(DbContextOptions<TodoDbContext> options)
    {
        _options = options;
    }

    public TodoDbContext CreateDbContext()
    {
        return new TodoDbContext(_options);

    }
}
