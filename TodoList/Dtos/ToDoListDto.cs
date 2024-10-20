using TodoList.Domain.Entities;

namespace TodoList.Dtos;

public record ToDoListDto(List<ToDo> toDos, ToDoPorcentageDto porcentage);
