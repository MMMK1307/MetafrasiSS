using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.UserAggregate;
using System.Security.Claims;

namespace MetafrasiSS.Application.Auth.Queries.GetUserByClaims;

public record GetUserByClaimsQuery(ClaimsPrincipal Claims) : IRequest<ErrorOr<User>>;