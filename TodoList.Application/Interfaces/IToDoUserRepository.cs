using TodoList.Application.Dtos;
using TodoList.Domain.Entities;

namespace TodoList.Application.Interfaces;

public interface IToDoUserRepository
{
    public Task<ToDoUser?> CreateUserAsync(CreateUserDto dto);
}
