using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.Auth.Queries.Logout;

public record LogoutQuery(UserId UserId) : IRequest<ErrorOr<bool>>;