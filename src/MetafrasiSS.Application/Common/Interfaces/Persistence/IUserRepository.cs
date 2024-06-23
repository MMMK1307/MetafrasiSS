using ErrorOr;
using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using System.Security.Claims;

namespace MetafrasiSS.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
	Task<ErrorOr<User>> Create(User userData);

	Task<bool> Update(User user);

	Task<ErrorOr<bool>> Login(string username, string password, bool rememberMe);

	Task<bool> Logout();

	Task<User> GetById(UserId userId);

	Task<ErrorOr<User>> GetUserByClaims(ClaimsPrincipal claims);
}