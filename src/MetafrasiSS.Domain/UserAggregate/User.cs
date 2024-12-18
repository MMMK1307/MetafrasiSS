using MetafrasiSS.Domain.Common.Enums;
using MetafrasiSS.Domain.Common.Models;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Domain.UserAggregate;

public class User : AggregateRoot<UserId, Guid>
{
    public User(
        UserId id,
        string userName,
        string name,
        string email,
        bool confirmedEmail,
        string password,
        UserStatus status,
        DateTime created,
        DateTime updated)
     : base(id)
    {
        UserName = userName;
        Name = name;
        Email = email;
        ConfirmedEmail = confirmedEmail;
        Password = password;
        Status = status;
        Created = created;
        Updated = updated;
    }

    public User(
    string userName,
    string name,
    string email,
    bool confirmedEmail,
    string password,
    UserStatus status,
    DateTime created,
    DateTime updated)
    {
        UserName = userName;
        Name = name;
        Email = email;
        ConfirmedEmail = confirmedEmail;
        Password = password;
        Status = status;
        Created = created;
        Updated = updated;
    }

    public User(UserId id)
        : base(id)
    {
    }

    private User()
    {
    }

    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool ConfirmedEmail { get; set; }
    public string Password { get; set; }
    public UserStatus Status { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public static User Create(string username, string name, string email, string password, UserStatus status, DateTime created, DateTime updated)
    {
        return new User(
            userName: username,
            name: name,
            email: email,
            confirmedEmail: false,
            password: password,
            status: status,
            created: created,
            updated: updated);
    }
}
