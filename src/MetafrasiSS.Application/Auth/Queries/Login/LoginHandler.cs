using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;

namespace MetafrasiSS.Application.Auth.Queries.Login;

public class LoginHandler : IRequestHandler<LoginQuery, ErrorOr<bool>>
{
    private readonly IUserRepository _userRepository;

    public LoginHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<bool>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.Login(request.UserName, request.Password, request.RememberMe);

        return result;
    }
}