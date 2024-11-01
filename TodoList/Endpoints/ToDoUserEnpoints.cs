using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Dtos;
using TodoList.Application.Interfaces;

namespace TodoList.Endpoints;

public static class ToDoUserEnpoints
{
    public static void MapToDoUserEnpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/users")
           .WithTags("ToDoUsers")
           .RequireCors("development-policy");

        group.MapPost("", CreateUserAsync);
    }

    public static async Task<IResult> CreateUserAsync(IToDoUserRepository repository, [FromBody] CreateUserDto dto)
    {
        var newUser = await repository.CreateUserAsync(dto);

        if (newUser == null)
        {
            return Results.BadRequest("User not created");
        }

        return Results.Created("toDo-api", new { });
    }
}
