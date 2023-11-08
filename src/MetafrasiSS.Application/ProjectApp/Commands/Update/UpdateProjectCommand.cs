using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Application.ProjectApp.Commands.Update;
public record UpdateProjectCommand(
	ProjectId ProjectId,
	string Name,
	string Description) : IRequest<ErrorOr<Project>>;