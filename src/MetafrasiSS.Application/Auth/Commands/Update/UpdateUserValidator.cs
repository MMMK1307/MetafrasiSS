using FluentValidation;
using MetafrasiSS.Application.Auth.Commands.Register;

namespace MetafrasiSS.Application.Auth.Commands.Update;

public class UpdateUserValidator : AbstractValidator<RegisterUserCommand>
{
	public UpdateUserValidator()
	{
		RuleFor(x => x.Name).NotEmpty();
		RuleFor(x => x.Name.Length).LessThan(300);
		RuleFor(x => x.Username).NotEmpty();
		RuleFor(x => x.Username.Length).LessThan(256);
		RuleFor(x => x.Email).NotEmpty();
		RuleFor(x => x.Email).EmailAddress();
		RuleFor(x => x.Email.Length).LessThan(256);
	}
}