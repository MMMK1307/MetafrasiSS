using ErrorOr;
using MediatR;

namespace MetafrasiSS.Application.Auth.Queries.Login;

public record LoginQuery(
    string UserName,
    string Password,
    bool RememberMe) : IRequest<ErrorOr<bool>>;