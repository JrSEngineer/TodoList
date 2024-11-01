using TodoList.Application.Dtos;
using TodoList.Domain.Entities;

namespace TodoList.Tests.Mocks;

internal class ToDoUserMocks
{
    public static Func<ToDoUser> userWithShortPassword = () =>
        ToDoUser.Create(
            "Jr",
            "48329472934",
            UserAccount.SetUserAccountData(
                "email@email.com",
                "4345",
                1
               )
            );

    public static Func<ToDoUser> userWithWrongEmail = () =>
        ToDoUser.Create(
            "Jr",
            "48329472934",
            UserAccount.SetUserAccountData(
                 "emailemail.com",
                 "43423242df45",
                 1
                )
            );

    public static ToDoUser newUser = ToDoUser.Create(
            "Jr",
            "48329472934",
            UserAccount.SetUserAccountData(
                 "email123@email.com",
                 "43423242df45",
                 1
                )
            );

    public static CreateUserDto wrongUserDto = new CreateUserDto(
        "",
        "",
        new CreateUserAccountDto(
            "",
            "",
            1)
        );
}
