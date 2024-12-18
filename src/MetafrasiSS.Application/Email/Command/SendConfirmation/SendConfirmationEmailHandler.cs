using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Domain.Services;

namespace MetafrasiSS.Application.Email.Command.SendConfirmation;
internal class SendConfirmationEmailHandler : IRequestHandler<SendConfirmationEmailCommand, ErrorOr<bool>>
{
    private readonly IEmailService _emailService;

    public SendConfirmationEmailHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<ErrorOr<bool>> Handle(SendConfirmationEmailCommand request, CancellationToken cancellationToken)
    {
        var emailData = EmailServiceData.Create(request.Email, "Metafrasi Email Confirmation", "Email body. Email no body");
        return await _emailService.SendEmail(emailData);
    }
}
