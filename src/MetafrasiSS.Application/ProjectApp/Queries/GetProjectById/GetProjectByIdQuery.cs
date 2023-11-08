using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Application.ProjectApp.Queries.GetProjectById;
public record GetProjectByIdQuery(ProjectId ProjectId) : IRequest<ErrorOr<Project>>;