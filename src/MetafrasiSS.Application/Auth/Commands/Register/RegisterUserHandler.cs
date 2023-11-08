using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Domain.Common.Enums;
using MetafrasiSS.Domain.UserAggregate;

namespace MetafrasiSS.Application.Auth.Commands.Register;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ErrorOr<User>>
{
	private readonly IUserRepository _userRepository;
	private readonly IDateTimeProvider _dateTimeProvider;

	public RegisterUserHandler(IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
	{
		_userRepository = userRepository;
		_dateTimeProvider = dateTimeProvider;
	}

	public async Task<ErrorOr<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User(
			request.Username,
			request.Name,
			request.Email,
			false,
			request.Password,
			UserStatus.Active,
			_dateTimeProvider.UtcNow, 
			_dateTimeProvider.UtcNow);

		await _userRepository.Create(user);

		return user;
	}
}