namespace TodoList.Domain.Entities;
public class ToDoList
{
    public ToDoList(List<ToDo> toDos)
    {
        ToDos = toDos;
    }
    public List<ToDo> ToDos { get; set; }

    public int GetWaitingToDoPorcentage()
    {
        var waitingToDos = ToDos.Where(t => !t.InProgress && !t.Completed).ToList();
        int toDosAwaitingPresentation = (int)waitingToDos.Count() * (int)100;
        int porcentage = toDosAwaitingPresentation / (int)ToDos.Count();

        return ((int)porcentage);
    }
    
    public int GetInProgressToDoPorcentage()
    {
        var inProgressToDos = ToDos.Where(t => t.InProgress).ToList();
        int toDosInProgressPresentation = (int)inProgressToDos.Count() * (int)100;
        int porcentage = toDosInProgressPresentation / (int)ToDos.Count();

        return ((int)porcentage);
    }
    
    public int GetCompletedToDoPorcentage()
    {
        var completedToDos = ToDos.Where(t => t.Completed).ToList();
        int toDosInProgressPresentation = (int)completedToDos.Count() * (int)100;
        int porcentage = toDosInProgressPresentation / (int)ToDos.Count();

        return ((int)porcentage);
    }
}
