using MetafrasiSS.Domain.Common.Enums;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MetafrasiSS.Web.Models.UserModels;

public class ListUserModel
{
    public ListUserModel(
        UserId id,
        string name,
        string username,
        string email,
        UserStatus status,
        bool confirmedEmail,
        DateTime created,
        DateTime updated)
    {
        Id = id;
        Name = name;
        Username = username;
        Email = email;
        Status = status;
        ConfirmedEmail = confirmedEmail;
        Created = created;
        Updated = updated;
    }

    public UserId Id { get; set; }

    [MaxLength(300)]
    [Required]
    public string Name { get; set; }

    [MaxLength(256)]
    [Required]
    public string Username { get; set; }

    [MaxLength(256)]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public UserStatus Status { get; set; }

    public bool ConfirmedEmail { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}