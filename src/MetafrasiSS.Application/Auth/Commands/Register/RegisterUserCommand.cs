using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.UserAggregate;

namespace MetafrasiSS.Application.Auth.Commands.Register;

public record RegisterUserCommand(
	string Name,
	string Username,
	string Email,
	string Password) : IRequest<ErrorOr<User>>;