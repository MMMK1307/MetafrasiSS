using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.UserAggregate;

namespace MetafrasiSS.Application.Auth.Queries.GetUserByClaims;

public class GetUserByClaimsHandler : IRequestHandler<GetUserByClaimsQuery, ErrorOr<User>>
{
	private readonly IUserRepository _userRepository;

	public GetUserByClaimsHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<User>> Handle(GetUserByClaimsQuery request, CancellationToken cancellationToken)
	{
		return await _userRepository.GetUserByClaims(request.Claims);
	}
}