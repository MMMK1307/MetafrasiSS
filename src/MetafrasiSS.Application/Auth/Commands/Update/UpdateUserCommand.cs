using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.UserAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.Auth.Commands.Update;
public record UpdateUserCommand(
	UserId Id,
	string Name,
	string Username,
	string Email) : IRequest<ErrorOr<User>>;