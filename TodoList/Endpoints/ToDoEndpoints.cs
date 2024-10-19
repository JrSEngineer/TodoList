using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Infra.Context;

namespace TodoList.Endpoints
{
    public static class ToDoEndpoints
    {
        public static void MapToDoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/todos")
                           .WithTags("ToDos")
                           .RequireCors("development-policy");

            group.MapPost("", async (TodoDbContext context, ToDo newTodo) =>
            {
                await context.ToDo.AddAsync(newTodo);
                await context.SaveChangesAsync();

                return Results.Created("todo-api", newTodo);
            });

            group.MapGet("{id}", async (TodoDbContext context, int id) =>
            {
                var currentToDo = await context.ToDo.FindAsync(id);
                if (currentToDo == null)
                {
                    return Results.NotFound($"ToDo not found: {id}");
                }

                return Results.Ok(currentToDo);
            });

            group.MapGet("/search={search}", async (TodoDbContext context, string search) =>
            {
                var currentToDo = context.ToDo.Where(todo => todo.Title.ToLower().Contains(search.ToLower()) || 
                                                     todo.Description.ToLower().Contains(search.ToLower())).ToList();

                if (!currentToDo.Any())
                {
                    return Results.NotFound(new {Message = $"ToDo not found. Searching for: {search}" });
                }

                return Results.Ok(currentToDo);
            });

            group.MapGet("", async (TodoDbContext context) =>
            {
                var ToDos = await context.ToDo.ToListAsync();
                return Results.Ok(ToDos);
            });

            group.MapPatch("{id}", async (TodoDbContext context, int id) =>
            {
                var currentToDo = await context.ToDo.FindAsync(id);
                if (currentToDo == null)
                {
                    return Results.NotFound($"ToDo not found: {id}");
                }

                currentToDo.InProgress= true;

                await context.SaveChangesAsync();

                return Results.Ok(currentToDo);
            });
            
            group.MapPut("{id}", async (TodoDbContext context, int id, ToDo toDo) =>
            {
                var currentToDo = await context.ToDo.FindAsync(id);
                if (currentToDo == null)
                {
                    return Results.NotFound($"ToDo not found: {id}");
                }

                currentToDo.Title = toDo.Title;
                currentToDo.Description = toDo.Description;
                currentToDo.Completed = toDo.Completed;
                currentToDo.InProgress = toDo.InProgress;

                await context.SaveChangesAsync();

                return Results.Ok(currentToDo);
            });

            group.MapDelete("{id}", async (TodoDbContext context, int id) =>
            {
                var currentToDo = await context.ToDo.FindAsync(id);
                if (currentToDo == null)
                {
                    return Results.NotFound($"ToDo not found: {id}");
                }

                context.ToDo.Remove(currentToDo);

                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
