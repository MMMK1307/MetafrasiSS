using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;

namespace MetafrasiSS.Application.ProjectApp.Commands.Delete;
public record DeleteProjectCommand(ProjectId ProjectId) : IRequest<ErrorOr<Project>>;