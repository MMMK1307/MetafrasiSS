using FluentValidation;

namespace MetafrasiSS.Application.Email.Command.SendConfirmation;
public class SendConfirmationEmailValidator : AbstractValidator<SendConfirmationEmailCommand>
{
    public SendConfirmationEmailValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Email).NotEmpty();
    }
}
