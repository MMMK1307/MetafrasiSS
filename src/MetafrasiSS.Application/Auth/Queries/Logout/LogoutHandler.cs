using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;

namespace MetafrasiSS.Application.Auth.Queries.Logout;

public class LogoutHandler : IRequestHandler<LogoutQuery, ErrorOr<bool>>
{
    private readonly IUserRepository _userRepository;

    public LogoutHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<bool>> Handle(LogoutQuery request, CancellationToken cancellationToken)
    {
        _ = request;
        return await _userRepository.Logout();
    }
}