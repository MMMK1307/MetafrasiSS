using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Application.ProjectApp.Queries.GetProjectById;
using MetafrasiSS.Domain.ProjectAggregate;

namespace MetafrasiSS.Application.ProjectApp.Commands.Update;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ErrorOr<Project>>
{
	private readonly IProjectRepository _projectRepository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly ISender _mediator;

	public UpdateProjectHandler(
		IProjectRepository projectRepository,
		IDateTimeProvider dateTimeProvider,
		ISender mediator)
	{
		_projectRepository = projectRepository;
		_dateTimeProvider = dateTimeProvider;
		_mediator = mediator;
	}

	public async Task<ErrorOr<Project>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetProjectByIdQuery(request.ProjectId), cancellationToken);

		if(result.IsError)
		{
			return result;
		}

		var project = result.Value;

		var newProject = new Project(
			request.ProjectId,
			request.Name,
			request.Description, 
			project.Files.ToList(), 
			project.Created,
			_dateTimeProvider.UtcNow,
			project.UserId);

		await _projectRepository.Update(newProject);

		return newProject;
	}
}