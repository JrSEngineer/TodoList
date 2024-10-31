namespace TodoList.Domain.Entities;

public class UserAccount
{
    private UserAccount(string email, string password, int userId)
    {
        Email = email;
        Password = password;
        UserId = userId;
    }

    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public int UserId { get; private set; }

    public static UserAccount SetUserAccountData(string email, string password, int userId)
    {
        return new UserAccount(email, password, userId);
    }
}
