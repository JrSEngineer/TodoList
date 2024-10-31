using System.Text.RegularExpressions;

namespace TodoList.Domain.Entities;

public class ToDoUser
{

    private ToDoUser(string name, string phoneNumber, UserAccount account)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Account = account;
    }

    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string PhoneNumber { get; private set; } = string.Empty;

    public UserAccount Account { get; private set; } = null!;

    public List<ToDo> ToDos { get; private set; } = [];

    public static ToDoUser Create(string name, string phoneNumber, UserAccount account)
    {
        int passwordLength = 8;

        if (account.Password.Count() < passwordLength)
        {
            throw new Exception($"Your password is too short. Please, provide at least {passwordLength} caracters.");
        }

        if (!Regex.IsMatch(account.Email, "^[A-Za-z0-9]+@[a-z]+.[a-z]+(.[a-z]*)$"))
        {
            throw new Exception($"Please, provide an e-mail in a valid format.");
        }

        return new ToDoUser(name, phoneNumber, account);
    }

    public void CreateNewTodo(ToDo newTodo)
    {

    }
}
