using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.ProjectApp.Queries.GetProjectByUser;
public record GetProjectByUserQuery(UserId UserId) : IRequest<ErrorOr<List<Project>>>;