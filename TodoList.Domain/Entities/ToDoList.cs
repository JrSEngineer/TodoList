namespace TodoList.Domain.Entities;
public class ToDoList
{
    public ToDoList(List<ToDo> toDos)
    {
        ToDos = toDos;
    }
    public List<ToDo> ToDos { get; set; }

    public double GetWaitingToDoPorcentage()
    {
        var waitingToDos = ToDos.Where(t => !t.InProgress && !t.Completed).ToList();
        double toDosAwaitingPresentation = (double)waitingToDos.Count() * (double)100;
        double porcentage = toDosAwaitingPresentation / (double)ToDos.Count();

        return ((int)porcentage);
    }
    
    public double GetInProgressToDoPorcentage()
    {
        var inProgressToDos = ToDos.Where(t => t.InProgress).ToList();
        double toDosInProgressPresentation = (double)inProgressToDos.Count() * (double)100;
        double porcentage = toDosInProgressPresentation / (double)ToDos.Count();

        return ((int)porcentage);
    }
    
    public double GetCompletedToDoPorcentage()
    {
        var completedToDos = ToDos.Where(t => t.Completed).ToList();
        double toDosInProgressPresentation = (double)completedToDos.Count() * (double)100;
        double porcentage = toDosInProgressPresentation / (double)ToDos.Count();

        return ((int)porcentage);
    }
}
