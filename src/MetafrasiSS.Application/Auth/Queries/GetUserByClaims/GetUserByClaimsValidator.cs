using FluentValidation;

namespace MetafrasiSS.Application.Auth.Queries.GetUserByClaims;

public class GetUserByClaimsValidator : AbstractValidator<GetUserByClaimsQuery>
{
	public GetUserByClaimsValidator()
	{
		RuleFor(x => x.Claims).NotEmpty();
	}
}