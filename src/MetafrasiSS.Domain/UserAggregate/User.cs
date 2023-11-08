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
		DateTime updated) : base(id)
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

	public User(UserId id) : base(id)
	{
	}

	public User()
	{
	}

	public string UserName { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string Email { get; set; } = null!;
	public bool ConfirmedEmail { get; set; }
	public string Password { get; set; } = null!;
	public UserStatus Status { get; set; }
	public DateTime Created { get; set; }
	public DateTime Updated { get; set; }
}