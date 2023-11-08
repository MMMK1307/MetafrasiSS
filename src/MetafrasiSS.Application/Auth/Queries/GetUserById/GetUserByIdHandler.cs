using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.Common.Errors;
using MetafrasiSS.Domain.UserAggregate;

namespace MetafrasiSS.Application.Auth.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<User>>
{
	private readonly IUserRepository _userRepository;

	public GetUserByIdHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetById(request.UserId);

		if (string.IsNullOrEmpty(user.Name))
		{
			return Errors.User.NotFound;
		}

		return user;
	}
}