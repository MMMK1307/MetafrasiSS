using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.Common.Errors;
using MetafrasiSS.Domain.ProjectAggregate;

namespace MetafrasiSS.Application.ProjectApp.Queries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ErrorOr<Project>>
{
	private readonly IProjectRepository _projectRepository;

	public GetProjectByIdHandler(IProjectRepository projectRepository)
	{
		_projectRepository = projectRepository;
	}

	public async Task<ErrorOr<Project>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
	{
		var project = await _projectRepository.GetById(request.ProjectId);

		if (project is null)
		{
			return Errors.Project.NotFound;
		}

		return project;
	}
}