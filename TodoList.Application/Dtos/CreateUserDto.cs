using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.Dtos;

[Display]
public record CreateUserDto(string name, string phoneNumber, CreateUserAccountDto accountDto);