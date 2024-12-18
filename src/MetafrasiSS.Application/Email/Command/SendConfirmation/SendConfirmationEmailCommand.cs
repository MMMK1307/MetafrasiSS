using ErrorOr;
using MediatR;

namespace MetafrasiSS.Application.Email.Command.SendConfirmation;
public record SendConfirmationEmailCommand(
    string Email) : IRequest<ErrorOr<bool>>;
