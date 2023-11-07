using ErrorOr;
using MediatR;
using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.UserAggregate.ValueObjects;

namespace MetafrasiSS.Application.ProjectApp.Commands.Create;
public record CreateProjectCommand(
	string Name,
	string Description,
	string FileName,
	string FileContent,
	UserId UserId
	) : IRequest<ErrorOr<Project>>;