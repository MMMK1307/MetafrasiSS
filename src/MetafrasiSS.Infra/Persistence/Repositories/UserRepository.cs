using ErrorOr;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.Common.Errors;
using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;
using MetafrasiSS.Infra.Common.Mapping;
using MetafrasiSS.Infra.DataModels.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MetafrasiSS.Infra.Persistence.Repositories;

public class UserRepository : IUserRepository
{
	private readonly UserManager<DataUserModel> _userManager;
	private readonly SignInManager<DataUserModel> _signInManager;
	private readonly IdDataContext _dbContext;

	public UserRepository(
		UserManager<DataUserModel> userManager,
		SignInManager<DataUserModel> signInManager,
		IdDataContext dbContext)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_dbContext = dbContext;
	}

	public async Task<bool> Create(User userData)
	{
		var user = Activator.CreateInstance<DataUserModel>();

		user.UserName = userData.UserName;
		user.Email = userData.Email;
		user.Name = userData.Name;
		user.Created = userData.Created;
		user.Updated = userData.Updated;

		var result = await _userManager.CreateAsync(user, userData.Password);

		await _userManager.SetLockoutEnabledAsync(user, false);

		return result.Succeeded;
	}

	public async Task<bool> Update(User user)
	{
		var dbUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id.Value);

		if (dbUser == null)
		{
			return false;
		}

		dbUser.Name = user.Name;
		dbUser.UserName = user.UserName;
		dbUser.Email = user.Email;
		dbUser.Updated = user.Updated;

		_dbContext.Users.Update(dbUser);
		await _dbContext.SaveChangesAsync();

		return true;
	}

	public async Task<ErrorOr<bool>> Login(string username, string password, bool rememberMe)
	{
		_ = await Logout();

		var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

		if (result.Succeeded)
		{
			return true;
		}

		if (result.IsLockedOut)
		{
			return Errors.Auth.LockedOut;
		}

		return Errors.Auth.InvalidCredentials;
	}

	public async Task<bool> Logout()
	{
		await _signInManager.SignOutAsync();
		return true;
	}

	public async Task<User> GetById(UserId userId)
	{
		var id = userId.Value;

		var dbUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

		if (dbUser == null)
		{
			return default!;
		}

		return dbUser.ToDomainUser();
	}

	public async Task<ErrorOr<User>> GetUserByClaims(ClaimsPrincipal claims)
	{
		var user = await _userManager.GetUserAsync(claims);

		if (user is null)
		{
			return Errors.Auth.NotFound;
		}

		return user.ToDomainUser();
	}
}