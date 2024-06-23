using ErrorOr;
using MediatR;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Domain.ProjectAggregate;

namespace MetafrasiSS.Application.ProjectApp.Queries.GetProjectByUser;

public class GetProjectByUserHandler : IRequestHandler<GetProjectByUserQuery, ErrorOr<List<Project>>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByUserHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<List<Project>>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
    {
        return await _projectRepository.GetByUser(request.UserId);
    }
}