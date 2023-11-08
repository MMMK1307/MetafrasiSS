using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.Common.Errors;
using MetafrasiSS.Domain.ProjectAggregate;

namespace MetafrasiSS.Application.ProjectApp.Commands.Delete;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, ErrorOr<Project>>
{
	private readonly IProjectRepository _projectRepository;

	public DeleteProjectHandler(IProjectRepository projectRepository)
	{
		_projectRepository = projectRepository;
	}

	public async Task<ErrorOr<Project>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
	{
		var project = await _projectRepository.GetById(request.ProjectId);

		if (project is null)
		{
			return Errors.Project.NotFound;
		}

		return await _projectRepository.Delete(project);
	}
}