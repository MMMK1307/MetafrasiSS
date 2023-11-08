using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.Auth.Queries.GetUserById;
public record GetUserByIdQuery(UserId UserId) : IRequest<ErrorOr<User>>;